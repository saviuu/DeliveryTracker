using DeliveryTracker.Application.DTOs.Users;
using DeliveryTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Create([FromBody] CreateUserDto dto)
        {
            var result = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
    }
}
