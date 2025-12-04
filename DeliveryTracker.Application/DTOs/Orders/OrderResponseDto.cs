using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Application.DTOs.Orders
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        public Guid RestaurantId { get; set; }

        public OrderStatus Status { get; set; }

        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Total { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<OrderItemResponseDto> Items { get; set; } = [];
    }
}
