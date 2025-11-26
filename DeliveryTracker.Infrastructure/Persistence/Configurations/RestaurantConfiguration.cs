using DeliveryTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryTracker.Infrastructure.Persistence.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(r => r.AddressLine)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(r => r.Orders)
                .WithOne(o => o.Restaurant)
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
