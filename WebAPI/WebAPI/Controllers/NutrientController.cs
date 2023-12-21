using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("nutrients")]
    public class NutrientController : Controller
    {
        private readonly INutrientService _nutrientService;
        private readonly IMapper _mapper;

        public NutrientController(INutrientService nutrientService, IMapper mapper)
        {
            _nutrientService = nutrientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nutrients = await _nutrientService.GetAll();

            if (nutrients == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<List<NutrientDto>>(nutrients);

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GiveToPet(int id, Nutrient nutrient)
        {
            var result = await _nutrientService.GiveToPet(id, nutrient);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
