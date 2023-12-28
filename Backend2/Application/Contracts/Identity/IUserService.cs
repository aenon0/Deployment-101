using Application.DTO.Identity;

namespace Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetStudents();
    Task<User> GetStudent(string userId);
    public string UserId { get; }
}