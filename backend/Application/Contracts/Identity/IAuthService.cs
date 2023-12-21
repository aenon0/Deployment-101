using Application.Models;

namespace Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> LogIn(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
  
}

