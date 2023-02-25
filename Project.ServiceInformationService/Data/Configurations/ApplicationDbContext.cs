using Microsoft.EntityFrameworkCore;

namespace Project.ServiceInformationService.Data.Configurations;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<MedicalPackage> MedicalPackages { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceItem> ServiceItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalPackageConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceItemConfiguration());

    }
}