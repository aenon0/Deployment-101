using Domain;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasData(
                new Group
                {
                  GroupId = 1,
                  Name = "G41"

                },
                new Group
                {
                    GroupId = 2,
                    Name = "G42"

                },
                new Group
                {
                    GroupId = 3,
                    Name = "G43"

                },
                new Group
                {
                    GroupId = 4,
                    Name = "G43"

                }
            );
        }
    }
}
