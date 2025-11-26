using DeliveryTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryTracker.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.HasMany(u => u.CustomerOrders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.OwnedRestaurants)
                .WithOne(r => r.Owner)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.CourierDeliveries)
                .WithOne(d => d.Courier)
                .HasForeignKey(d => d.CourierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CourierLocations)
                .WithOne(cl => cl.Courier)
                .HasForeignKey(cl => cl.CourierId);
        }
    }
}
