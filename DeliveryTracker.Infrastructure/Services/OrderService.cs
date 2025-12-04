using DeliveryTracker.Application.DTOs.Orders;
using DeliveryTracker.Application.Interfaces.Services;
using DeliveryTracker.Domain.Entities;
using DeliveryTracker.Domain.Enums;
using DeliveryTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTracker.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly DeliveryTrackerDbContext _dbContext;

        public OrderService(DeliveryTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderResponseDto> CreateAsync(CreateOrderDto dto)
        {
            // Basic validation: ensure customer and restaurant exist
            var customerExists = await _dbContext.Users.AnyAsync(u => u.Id == dto.CustomerId);
            var restaurantExists = await _dbContext.Restaurants.AnyAsync(r => r.Id == dto.RestaurantId);

            if (!customerExists || !restaurantExists) throw new InvalidOperationException("Customer or restaurant not found.");

            var order = new Order
            {
                CustomerId = dto.CustomerId,
                RestaurantId = dto.RestaurantId,
                DeliveryFee = dto.DeliveryFee,
                Notes = dto.Notes,
                Status = OrderStatus.Pending
            };

            // Calculate subtotal based on items
            decimal subtotal = 0m;

            foreach (var item in dto.Items)
            {
                var lineTotal = item.UnitPrice * item.Quantity;
                subtotal += lineTotal;

                var orderItem = new OrderItem
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };

                order.Items.Add(orderItem);
            }

            order.Subtotal = subtotal;

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return MapToResponse(order);
        }

        public async Task<IReadOnlyList<OrderResponseDto>> GetAllAsync()
        {
            var orders = await _dbContext.Orders
                .AsNoTracking()
                .Include(o => o.Items)
                .ToListAsync();

            return [.. orders.Select(MapToResponse)];
        }

        private static OrderResponseDto MapToResponse(Order order)
        {
            return new OrderResponseDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                RestaurantId = order.RestaurantId,
                Status = order.Status,
                Subtotal = order.Subtotal,
                DeliveryFee = order.DeliveryFee,
                Total = order.Total,
                Notes = order.Notes,
                CreatedAt = order.CreatedAt,
                Items = [.. order.Items.Select(oi => new OrderItemResponseDto
                {
                    Id = oi.Id,
                    ProductName = oi.ProductName,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    LineTotal = oi.LineTotal
                })]
            };
        }
    }
}
