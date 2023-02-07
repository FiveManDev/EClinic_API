using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.ProfileService.Data.Configurations
{
    public class FamilyProfileConfiguration : IEntityTypeConfiguration<FamilyProfile>
    {
        public void Configure(EntityTypeBuilder<FamilyProfile> builder)
        {
            builder.HasKey(fp => new { fp.UserID, fp.PatientID });
            builder.Property(p => p.UserID).IsRequired();
            builder.Property(p => p.PatientID).IsRequired();
            builder.Property(p => p.Relationship).IsRequired();
            builder.HasOne(x => x.MyProfile)
                    .WithMany(x => x.FamilyProfile)
                    .HasForeignKey(x => x.UserID)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.OtherProfile)
                    .WithMany(x => x.FamilyRelationshipProfile)
                    .HasForeignKey(x => x.PatientID)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("FamilyProfiles");
        }
    }
}
