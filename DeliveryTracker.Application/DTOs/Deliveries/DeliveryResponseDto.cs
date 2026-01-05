using System;
using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Application.DTOs.Deliveries
{
    public class DeliveryResponseDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? CourierId { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AcceptedAt { get; set; }
        public DateTime? PickedUpAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}