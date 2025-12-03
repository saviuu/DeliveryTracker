using DeliveryTracker.Application.DTOs.Restaurants;
using DeliveryTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController(IRestaurantService restaurantService) : ControllerBase
    {
        private readonly IRestaurantService _restaurantService = restaurantService;

        [HttpPost]
        public async Task<ActionResult<RestaurantResponseDto>> Create([FromBody] CreateRestaurantDto dto)
        {
            var result = await _restaurantService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantResponseDto>>> GetAll()
        {
            var restaurants = await _restaurantService.GetAllAsync();
            return Ok(restaurants);
        }
    }
}
