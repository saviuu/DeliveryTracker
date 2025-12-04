using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Application.DTOs.Orders
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }
        public Guid RestaurantId { get; set; }

        public decimal DeliveryFee { get; set; }

        public string? Notes { get; set; }

        public List<CreateOrderItemDto> Items { get; set; } = [];
    }
}
