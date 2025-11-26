using DeliveryTracker.Domain.Common;
using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Domain.Entities
{
    public class Delivery : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid CourierId { get; set; }

        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;

        public DateTime? AcceptedAt { get; set; }
        public DateTime? PickedUpAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        // Navigation to locations (position history)
        public ICollection<CourierLocation> Locations { get; set; } = new List<CourierLocation>();

        // Navigation
        public Order Order { get; set; } = null!;
        public User Courier { get; set; } = null!;
    }
}
