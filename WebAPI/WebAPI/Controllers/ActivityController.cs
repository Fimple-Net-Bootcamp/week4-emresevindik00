using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("activities")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;

        public ActivityController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Activity activity)
        {
            var activityResponse = await _activityService.Add(activity);

            if (activityResponse == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<ActivityDto>(activityResponse);

            return Ok(result);
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
