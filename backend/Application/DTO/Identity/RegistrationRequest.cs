using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Identity;

public class RegistrationRequest
{
    [Required] 
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string UserName { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
    public string? CodeforcesHandle { get; set; }
    public string? groupName { get; set; }
}