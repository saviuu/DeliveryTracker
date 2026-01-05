using System;
using System.Threading.Tasks;
using DeliveryTracker.Application.DTOs.Deliveries;

namespace DeliveryTracker.Application.Interfaces.Services
{
    public interface IDeliveryService
    {
        Task<DeliveryResponseDto> CreateAsync(CreateDeliveryDto dto);
        Task<DeliveryResponseDto> GetByIdAsync(Guid id);
        Task<DeliveryResponseDto> AssignCourierAsync(Guid id, AssignCourierDto dto);
        Task<DeliveryResponseDto> UpdateStatusAsync(Guid id, UpdateDeliveryStatusDto dto);
    }
}