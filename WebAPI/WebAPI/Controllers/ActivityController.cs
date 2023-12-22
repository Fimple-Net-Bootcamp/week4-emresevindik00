using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("activities")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;
        private readonly IValidator<ActivityDto> _validator;

        public ActivityController(IActivityService activityService, IMapper mapper, IValidator<ActivityDto> validator)
        {
            _activityService = activityService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityDto activity)
        {
            if (activity == null)
            {
                return NoContent();
            }

            var validatorResult = _validator.Validate(activity);

            if (!validatorResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
            }

            var result = _mapper.Map<Activity>(activity);
            var activityResponse = await _activityService.Add(result);  

            return Ok(activityResponse);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetByPetId(int id)
        {
            var activityResponse = await _activityService.GetByPetId(id);

            if (activityResponse == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<ActivityDto>(activityResponse);

            return Ok(result);
        }
    }
}
