using System.Security.Claims;
using Application.Contracts.Identity;
using Application.DTO.Identity;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
    }

    public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

    public async Task<User> GetStudent(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);
        return new User
        {
            Email = employee.Email,
            Id = employee.Id,
            Firstname = employee.FirstName,
            Lastname = employee.LastName
        };
    }

    public async Task<List<User>> GetStudents()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Student");
        return employees.Select(q => new User
        {
            Id = q.Id,
            Email = q.Email,
            Firstname = q.FirstName,
            Lastname = q.LastName
        }).ToList();
    }
}