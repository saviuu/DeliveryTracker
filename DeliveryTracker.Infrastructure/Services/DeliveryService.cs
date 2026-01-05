using Microsoft.EntityFrameworkCore;
using DeliveryTracker.Application.DTOs.Deliveries;
using DeliveryTracker.Application.Interfaces.Services;
using DeliveryTracker.Domain.Entities;
using DeliveryTracker.Domain.Enums;
using DeliveryTracker.Infrastructure.Persistence;

namespace DeliveryTracker.Infrastructure.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly DeliveryTrackerDbContext _dbContext;

        public DeliveryService(DeliveryTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeliveryResponseDto> CreateAsync(CreateDeliveryDto dto)
        {
            var orderExists = await _dbContext.Orders.AnyAsync(o => o.Id == dto.OrderId);
            if (!orderExists) throw new InvalidOperationException("Order not found.");

            var deliveryExists = await _dbContext.Deliveries.AnyAsync(o => o.Id == dto.OrderId);
            if (!deliveryExists) throw new InvalidOperationException("The order already has a delivery assigned.");

            var delivery = new Delivery
            {
                OrderId = dto.OrderId,
                Status = DeliveryStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Deliveries.Add(delivery);
            await _dbContext.SaveChangesAsync();

            return MapToDto(delivery);
        }

        public async Task<DeliveryResponseDto> GetByIdAsync(Guid id)
        {
            var delivery = await _dbContext.Deliveries
                .FirstOrDefaultAsync(d => d.Id == id);

            if (delivery == null) return null;

            return MapToDto(delivery);
        }

        public async Task<DeliveryResponseDto> AssignCourierAsync(Guid id, AssignCourierDto dto)
        {
            var delivery = await _dbContext.Deliveries.FindAsync(id) ?? throw new InvalidOperationException("Delivery not found.");

            // Verificar se o utilizador é realmente um estafeta (Courier)
            var courier = await _dbContext.Users.FindAsync(dto.CourierId);
            if (courier == null || courier.Role != UserRole.Courier) //
                throw new InvalidOperationException("User is not a valid courier.");

            delivery.CourierId = dto.CourierId;
            delivery.Status = DeliveryStatus.Assigned; //
            delivery.AcceptedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return MapToDto(delivery);
        }

        public async Task<DeliveryResponseDto> UpdateStatusAsync(Guid id, UpdateDeliveryStatusDto dto)
        {
            var delivery = await _dbContext.Deliveries.FindAsync(id) ?? throw new InvalidOperationException("Delivery not found.");
            delivery.Status = dto.Status;s

            // Atualiza timestamps baseado na mudança de estado
            switch (dto.Status)
            {
                case DeliveryStatus.OnTheWayToCustomer:
                    // Assumimos que ao ir para o cliente, já recolheu o pedido
                    if (!delivery.PickedUpAt.HasValue) delivery.PickedUpAt = DateTime.UtcNow;
                    break;
                case DeliveryStatus.Completed:
                    if (!delivery.DeliveredAt.HasValue) delivery.DeliveredAt = DateTime.UtcNow;
                    break;
            }

            await _dbContext.SaveChangesAsync();
            return MapToDto(delivery);
        }

        private static DeliveryResponseDto MapToDto(Delivery delivery)
        {
            return new DeliveryResponseDto
            {
                Id = delivery.Id,
                OrderId = delivery.OrderId,
                CourierId = delivery.CourierId == Guid.Empty ? null : delivery.CourierId,
                Status = delivery.Status.ToString(),
                CreatedAt = delivery.CreatedAt,
                AcceptedAt = delivery.AcceptedAt,
                PickedUpAt = delivery.PickedUpAt,
                DeliveredAt = delivery.DeliveredAt
            };
        }
    }
}