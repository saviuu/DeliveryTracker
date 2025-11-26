using DeliveryTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryTracker.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Subtotal)
                .HasPrecision(18, 2);

            builder.Property(o => o.DeliveryFee)
                .HasPrecision(18, 2);

            // Total is computed in code, not stored in DB
            builder.Ignore(o => o.Total);

            builder.HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<Delivery>(d => d.OrderId);
        }
    }
}
