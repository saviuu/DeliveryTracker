using DeliveryTracker.Domain.Enums;

namespace DeliveryTracker.Application.DTOs.Deliveries
{
    public class UpdateDeliveryStatusDto
    {
        public DeliveryStatus Status { get; set; }
    }
}