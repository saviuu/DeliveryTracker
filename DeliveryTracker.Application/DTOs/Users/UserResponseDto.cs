using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Application.DTOs.Users
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
