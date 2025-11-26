using DeliveryTracker.Domain.Common;
using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid RestaurantId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }

        // Not mapped to DB, only computed in memory
        public decimal Total => Subtotal + DeliveryFee;
        public string? Notes { get; set; }

        // Navigation properties
        public User Customer { get; set; } = null!;
        public Restaurant Restaurant { get; set; } = null!;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Delivery? Delivery { get; set; }
    }
}
