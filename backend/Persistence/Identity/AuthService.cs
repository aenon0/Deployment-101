using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Identity;
using Application.Exceptions;
using Application.Models;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace Persistence.Identity;

public class AuthService : IAuthService
{
    private readonly UserManager<MainUser> _userManager;
    private readonly SignInManager<MainUser> _signInManager;
    private readonly JwtSettings _jwtSettings;
    private readonly ServerSettings _serverSettings;
    public AuthService(UserManager<MainUser> userManager, SignInManager<MainUser> signInManager, IOptions<JwtSettings> jwtSettings, IOptions<ServerSettings> serverSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
        _serverSettings = serverSettings.Value;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.Email);
        if (user != null)
        {
            throw new ValidationException($"{user} : This user is already registered");
        }

        var newUser = new MainUser
        {
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            EmailConfirmed = false
        };

        var result = await _userManager.CreateAsync(newUser, request.Password);
        if (result.Succeeded == false)
        {
            Console.WriteLine("Surafel");
            throw new InternalServerErrorException("Unable to create the user; please try agian");
        }

        await _userManager.AddToRoleAsync(newUser, "User");

        return new RegistrationResponse()
        {
            UserID = newUser.Id
        };

    }

    public async Task<AuthResponse> LogIn(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new NotFoundException("User not registered");
        }

        // if (!user.EmailConfirmed)
        // {
        //     throw new ValidationException("User email not verified : please verify your email address");
        // }

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            throw new ValidationException($"User add invalid credentials");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        AuthResponse response = new AuthResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName
        };

        return response;
    }

    public async Task<bool> ConfirmEmail(string email, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        if (user.EmailConfirmed)
        {
            throw new ValidationException("User already registered");
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
        {
            throw new InternalServerErrorException("Failed to confirm the server due to server failure");
        }

        return true;
    }

    public async Task<JwtSecurityToken> GenerateToken(MainUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var userRoles = await _userManager.GetRolesAsync(user);

        List<Claim> claims = new();

        for (int i = 0; i < userRoles.Count; i++)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRoles[i]));
        }
        foreach (var claim in userClaims)
        {
            claims.Add(claim);
        }

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName!));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));

        var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.Key);

        var symmetricSecurityKey = new SymmetricSecurityKey(secretKey);
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
        );

        return jwtSecurityToken;
    }
}

