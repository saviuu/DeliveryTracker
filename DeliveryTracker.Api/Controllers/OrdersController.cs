using DeliveryTracker.Application.DTOs.Orders;
using DeliveryTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> Create([FromBody] CreateOrderDto dto)
        {
            var result = await _orderService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }
    }
}
