using DeliveryTracker.Domain.Common;

namespace DeliveryTracker.Domain.Entities
{
    public class CourierLocation : BaseEntity
    {
        public Guid CourierId { get; set; }
        public Guid DeliveryId { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Navigation
        public User Courier { get; set; } = null!;
        public Delivery Delivery { get; set; } = null!;
    }
}
