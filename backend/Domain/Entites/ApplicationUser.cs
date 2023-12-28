using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Common;
using Domain.Entites;


namespace Domain;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? CodeforcesHandle { get; set; }
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
    public ICollection<UserContest>? UserContests { set; get; }
}