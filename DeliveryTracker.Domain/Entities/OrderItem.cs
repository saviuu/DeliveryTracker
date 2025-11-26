using DeliveryTracker.Domain.Common;

namespace DeliveryTracker.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }

        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal LineTotal => Quantity * UnitPrice;

        // Navigation
        public Order Order { get; set; } = null!;
    }
}
