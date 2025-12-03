namespace DeliveryTracker.Application.DTOs.Restaurants
{
    public class RestaurantResponseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        public string AddressLine { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
