using DeliveryTracker.Application.DTOs.Users;

namespace DeliveryTracker.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateAsync(CreateUserDto dto);
        Task<IReadOnlyList<UserResponseDto>> GetAllAsync();
    }
}
