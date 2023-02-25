using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.ServiceInformationService.Data.Configurations;

public class MedicalPackageConfiguration : IEntityTypeConfiguration<MedicalPackage>
{
    public void Configure(EntityTypeBuilder<MedicalPackage> builder)
    {
        builder.HasKey(package => package.PackageID);
        builder.Property(package => package.PackageID).HasDefaultValueSql("NEWID()").IsRequired();
        builder.Property(package => package.PackageName).IsRequired();
        builder.Property(package => package.Description).IsRequired();
        builder.Property(package => package.Price).IsRequired();
        builder.Property(package => package.EstimatedTime).IsRequired();
        builder.Property(package => package.SpecializationID).IsRequired();
        // Relationship
        builder.HasMany(package => package.ServiceItems)
               .WithOne(serviceItem => serviceItem.MedicalPackage)
               .HasForeignKey(serviceItem => serviceItem.PackageID)
               .HasConstraintName("PK_MedicalPackage_One_To_Many_ServiceItems")
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("MedicalPackages");

    }
}
