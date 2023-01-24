using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.IdentityService.Data.Configurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(token => token.TokenID);
            builder.Property(token => token.TokenID).HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(token => token.AccessToken).IsRequired();
            builder.Property(token => token.RefreshToken).IsRequired();
            builder.Property(token => token.CreateAt).IsRequired();
            builder.Property(token => token.UpdateAt).IsRequired();
            builder.HasOne(token => token.User)
                    .WithOne(user => user.Token)
                    .HasForeignKey<Token>(token => token.UserID)
                    .HasConstraintName("PK_User_One_To_One_Token")
                    .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Tokens");
        }
    }
}
