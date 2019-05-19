namespace Enigma.Domain.Model
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Entities;

    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<EnigmaConfiguration> EnigmaConfigurations { get; }
        public DbSet<RotorsConfiguration> RotorsConfigurations { get; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
