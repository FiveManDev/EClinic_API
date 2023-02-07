using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ProfileService.Data;
using System.Reflection.Emit;

namespace Project.IdentityService.Data.Configurations
{
    public class PatientProfileConfiguration : IEntityTypeConfiguration<PatientProfile>
    {
        public void Configure(EntityTypeBuilder<PatientProfile> builder)
        {
            builder.HasKey(p => p.UserID);
            builder.Property(p => p.UserID).IsRequired();
            builder.Property(p => p.BloodType).IsRequired();
            builder.Property(p => p.Height).IsRequired();
            builder.Property(p => p.Weight).IsRequired();
            builder.HasOne(p => p.Profile)
                   .WithOne(pp => pp.PatientProfile)
                   .HasForeignKey<PatientProfile>(p => p.UserID)
                   .HasConstraintName("PK_Profile_One_To_One_PatientProfile")
                   .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("PatientProfiles");
        }
    }
}
