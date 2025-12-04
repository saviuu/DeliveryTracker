using DeliveryTracker.Application.DTOs.Orders;

namespace DeliveryTracker.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateAsync(CreateOrderDto dto);
        Task<IReadOnlyList<OrderResponseDto>> GetAllAsync();
        // After we can add GetById, UpdateStatus, etc.
    }
}
