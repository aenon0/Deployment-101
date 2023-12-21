using Microsoft.AspNetCore.Identity;

namespace Domain.Entites;

public class MainUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
