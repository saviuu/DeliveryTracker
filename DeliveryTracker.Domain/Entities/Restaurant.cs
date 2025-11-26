using DeliveryTracker.Domain.Common;

namespace DeliveryTracker.Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string AddressLine { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public Guid OwnerId { get; set; }

        // Navigation properties
        public User Owner { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
