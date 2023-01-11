using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.IdentityService.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.RoleID);
            builder.Property(role => role.RoleID).IsRequired();
            builder.Property(role => role.RoleName).IsRequired();
            builder.Property(role => role.CreateAt).IsRequired();
            builder.Property(role => role.UpdateAt).IsRequired();
            builder.HasMany(auth => auth.User)
                   .WithOne(user => user.Role)
                   .HasForeignKey(user => user.RoleID)
                   .HasConstraintName("PK_User_Many_To_One_Role")
                   .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Users");

        }
    }
}
