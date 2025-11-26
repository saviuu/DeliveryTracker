using DeliveryTracker.Domain.Common;
using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        // Navigation properties
        public ICollection<Order> CustomerOrders { get; set; } = new List<Order>();
        public ICollection<Restaurant> OwnedRestaurants { get; set; } = new List<Restaurant>();
        public ICollection<Delivery> CourierDeliveries { get; set; } = new List<Delivery>();
        public ICollection<CourierLocation> CourierLocations { get; set; } = new List<CourierLocation>();

    }
}
