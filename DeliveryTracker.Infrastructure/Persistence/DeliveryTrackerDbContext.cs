using DeliveryTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTracker.Infrastructure.Persistence
{
    public class DeliveryTrackerDbContext(DbContextOptions<DeliveryTrackerDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Delivery> Deliveries => Set<Delivery>();
        public DbSet<CourierLocation> CourierLocations => Set<CourierLocation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryTrackerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
