namespace DeliveryTracker.Application.DTOs.Orders
{
    public class OrderItemResponseDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
