using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDto> _validator;

        public UserController(IUserService userService, IMapper mapper, IValidator<UserDto> validator)
        {
            _userService = userService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {
            var validatorResult = _validator.Validate(user);

            if (!validatorResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
            }

            var userDtoToUser = _mapper.Map<User>(user);

            var result = await _userService.Create(userDtoToUser);

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

        [HttpGet("statistics/{id}")]
        public async Task<IActionResult> GetStatisticById(int id)
        {
            var statistic = _userService.GetStatisticById(id);

            if (statistic == null)
            {
                return NoContent();
            }

            return Ok(statistic);
        }
    }
}
