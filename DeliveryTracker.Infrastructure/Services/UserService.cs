using DeliveryTracker.Application.DTOs.Users;
using DeliveryTracker.Application.Interfaces.Services;
using DeliveryTracker.Domain.Entities;
using DeliveryTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTracker.Infrastructure.Services
{
    public class UserService(DeliveryTrackerDbContext dbContext) : IUserService
    {
        private readonly DeliveryTrackerDbContext _dbContext = dbContext;

        public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Role = dto.Role
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<IReadOnlyList<UserResponseDto>> GetAllAsync()
        {
            return await _dbContext
                .Users
                .AsNoTracking()
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();
        }
    }
}
