using Domain;
using Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ContestCentralDbContext : IdentityDbContext<ApplicationUser>
{

        public DbSet<Contest> Contests { get; set; }
        public DbSet<Problem> Problems { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<UserContest> UserContests {get; set; }
        public DbSet<GroupContest> GroupContests { get; set; }

    public ContestCentralDbContext(DbContextOptions<ContestCentralDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ContestCentralDbContext).Assembly);
        }
    
}