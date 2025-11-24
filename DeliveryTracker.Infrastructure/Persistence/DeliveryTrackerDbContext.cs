using Microsoft.EntityFrameworkCore;

namespace DeliveryTracker.Infrastructure.Persistence
{
    public class DeliveryTrackerDbContext(DbContextOptions<DeliveryTrackerDbContext> options) : DbContext(options)
    {

        // DbSets vão entrar depois, exemplo:
        // public DbSet<Order> Orders { get; set; } = null!;
    }
}
