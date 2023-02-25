using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.ServiceInformationService.Data.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(service => service.ServiceID);
        builder.Property(service => service.ServiceID).HasDefaultValueSql("NEWID()").IsRequired();
        builder.Property(service => service.ServiceName).IsRequired();
        builder.Property(service => service.Title).IsRequired();
        builder.Property(service => service.Image).IsRequired();
        builder.Property(service => service.Price).IsRequired();
        builder.Property(service => service.TotalOrder).IsRequired();
        builder.Property(service => service.EstimatedTime).IsRequired();
        builder.Property(service => service.Description).IsRequired();
        // Relationship
        builder.HasMany(service => service.ServiceItems)
               .WithOne(serviceItem => serviceItem.Service)
               .HasForeignKey(serviceItem => serviceItem.ServiceID)
               .HasConstraintName("PK_Service_One_To_Many_ServiceItems")
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Services");

    }
}