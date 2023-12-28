using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "c3fbff24-adc7-4d1a-92d1-d9541a43060a",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "800a4fe7-76d5-4299-9890-5520b909e299",
                Name = "Student",
                NormalizedName = "STUDENT"
            },
            new IdentityRole
            {
                Id = "b3180adc-cb16-4443-9090-0f85d800dc9e",
                Name = "HOEAcademy",
                NormalizedName = "HOEACADEMY"
            }, 
            new IdentityRole
            {
                Id = "c10cdcad-ee69-48b7-9aee-a66544219517",
                Name = "LeadHOE",
                NormalizedName = "LEADHOE"
            }, 
            new IdentityRole
            {
                Id = "af8f93a5-9502-4e92-b8c0-e85b64c49431",
                Name = "ContestCreator",
                NormalizedName = "CONTESTCREATOR"
            }
            
        );
    }
    
}