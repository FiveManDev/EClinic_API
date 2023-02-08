using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ProfileService.Data;
using System.Reflection.Emit;

namespace Project.IdentityService.Data.Configurations
{
    public class SupporterProfileConfiguration : IEntityTypeConfiguration<SupporterProfile>
    {
        public void Configure(EntityTypeBuilder<SupporterProfile> builder)
        {
            builder.HasKey(p => p.ProfileID);
            builder.Property(p => p.ProfileID).IsRequired();
            builder.Property(p => p.WorkStart).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.HasOne(p => p.Profile)
                  .WithOne(sp => sp.SupporterProfile)
                  .HasForeignKey<SupporterProfile>(p => p.ProfileID)
                  .HasConstraintName("PK_Profile_One_To_One_SupporterProfile")
                  .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("SupporterProfiles");
        }
    }
}
