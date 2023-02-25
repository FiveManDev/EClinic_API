using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.ServiceInformationService.Data.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(specialization => specialization.SpecializationID);
        builder.Property(specialization => specialization.SpecializationID).HasDefaultValueSql("NEWID()").IsRequired();
        builder.Property(specialization => specialization.SpecializationName).IsRequired();
        builder.HasMany(specialization => specialization.MedicalPackages)
               .WithOne(medicalPackage => medicalPackage.Specialization)
               .HasForeignKey(medicalPackage => medicalPackage.SpecializationID)
               .HasConstraintName("PK_Specialization_One_To_Many_MedicalPackages")
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Specializations");

    }
}


