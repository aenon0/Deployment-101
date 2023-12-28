

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserRoleConfiguration  : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c3fbff24-adc7-4d1a-92d1-d9541a43060a",
                UserId = "bb37e344-b856-4ac3-83d1-0031e32bbee3"
            }
        );
    }
}