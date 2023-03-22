using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.CommunicateService.Data.Configurations
{
    public class VideoCallConfiguration : IEntityTypeConfiguration<VideoCall>
    {
        public void Configure(EntityTypeBuilder<VideoCall> builder)
        {
            builder.HasKey(v => v.VideoCallID);
            builder.Property(v => v.VideoCallID).HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(v => v.StartTime).IsRequired();
            builder.Property(v => v.EndTime).IsRequired();
            builder.Property(r => r.VideoUrl).IsRequired();
            builder.HasOne(v => v.Room)
                .WithMany(c => c.VideoCalls)
                .HasForeignKey(x=>x.RoomID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("PK_ChatRoom_One_To_One_VideoCall");
            builder.ToTable("VideoCalls");
        }
    }
}
