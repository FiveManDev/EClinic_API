using Microsoft.EntityFrameworkCore;
using Project.IdentityService.Data.Configurations;

namespace Project.ProfileService.Data.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<DoctorProfile> DoctorProfiles { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<SupporterProfile> SupporterProfiles { get; set; }
        public DbSet<FamilyProfile> FamilyProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorProfileConfiguration());
            modelBuilder.ApplyConfiguration(new SupporterProfileConfiguration());
            modelBuilder.ApplyConfiguration(new PatientProfileConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyProfileConfiguration());
        }
    }
}
