using DeliveryTracker.Application.DTOs.Restaurants;
using DeliveryTracker.Application.Interfaces.Services;
using DeliveryTracker.Domain.Entities;
using DeliveryTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTracker.Infrastructure.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly DeliveryTrackerDbContext _dbContext;

        public RestaurantService(DeliveryTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RestaurantResponseDto> CreateAsync(CreateRestaurantDto dto)
        {
            var owner = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == dto.OwnerId) ?? throw new InvalidOperationException("Owner not found.");

            var restaurant = new Restaurant
            {
                Name = dto.Name,
                AddressLine = dto.AddressLine,
                City = dto.City,
                State = dto.State,
                ZipCode = dto.ZipCode,
                OwnerId = dto.OwnerId
            };

            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();

            return new RestaurantResponseDto
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                AddressLine = restaurant.AddressLine,
                City = restaurant.City,
                State = restaurant.State,
                ZipCode = restaurant.ZipCode,
                OwnerId = owner.Id,
                OwnerName = owner.Name,
                CreatedAt = restaurant.CreatedAt
            };
        }

        public async Task<IReadOnlyList<RestaurantResponseDto>> GetAllAsync()
        {
            return await _dbContext.Restaurants
                .AsNoTracking()
                .Include(r => r.Owner)
                .Select(r => new RestaurantResponseDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    AddressLine = r.AddressLine,
                    City = r.City,
                    State = r.State,
                    ZipCode = r.ZipCode,
                    OwnerId = r.OwnerId,
                    OwnerName = r.Owner.Name,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();
        }
    }
}
