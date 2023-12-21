using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var result = await _userService.Create(user);

            if (result == null)
            {
                return NoContent();
            }
            
            return Ok(result);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userResponse = await _userService.GetById(id);

            if (userResponse == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<UserDto>(userResponse);

            return Ok(result);
        }
    }
}
