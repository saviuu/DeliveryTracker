using DeliveryTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryTracker.Infrastructure.Persistence.Configurations
{
    public class CourierLocationConfiguration : IEntityTypeConfiguration<CourierLocation>
    {
        public void Configure(EntityTypeBuilder<CourierLocation> builder)
        {
            builder.ToTable("CourierLocations");

            builder.HasKey(cl => cl.Id);

            builder.Property(cl => cl.Latitude)
                .IsRequired();

            builder.Property(cl => cl.Longitude)
                .IsRequired();

            builder.Property(cl => cl.Timestamp)
                .IsRequired();

            builder.HasOne(cl => cl.Courier)
                .WithMany(u => u.CourierLocations)
                .HasForeignKey(cl => cl.CourierId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(cl => cl.Delivery)
                .WithMany(d => d.Locations)
                .HasForeignKey(cl => cl.DeliveryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
