using DeliveryTracker.Application.DTOs.Restaurants;

namespace DeliveryTracker.Application.Interfaces.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantResponseDto> CreateAsync(CreateRestaurantDto dto);
        Task<IReadOnlyList<RestaurantResponseDto>> GetAllAsync();
    }
}
