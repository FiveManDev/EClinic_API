using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ProfileService.Data;
using System.Reflection.Emit;

namespace Project.IdentityService.Data.Configurations
{
    public class EmployeeProfileConfiguration : IEntityTypeConfiguration<EmployeeProfile>
    {
        public void Configure(EntityTypeBuilder<EmployeeProfile> builder)
        {
            builder.HasKey(p => p.ProfileID);
            builder.Property(p => p.ProfileID).IsRequired();
            builder.Property(p => p.WorkStart).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.HasOne(p => p.Profile)
                  .WithOne(sp => sp.SupporterProfile)
                  .HasForeignKey<EmployeeProfile>(p => p.ProfileID)
                  .HasConstraintName("PK_Profile_One_To_One_SupporterProfile")
                  .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("EmployeeProfiles");
        }
    }
}
