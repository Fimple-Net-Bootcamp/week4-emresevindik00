using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("nutrients")]
    public class NutrientController : Controller
    {
        private readonly INutrientService _nutrientService;
        private readonly IMapper _mapper;
        private readonly IValidator<NutrientDto> _validator;

        public NutrientController(INutrientService nutrientService, IMapper mapper, IValidator<NutrientDto> validator)
        {
            _nutrientService = nutrientService;
            _mapper = mapper;
            _validator = validator;
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
            var result = await _nutrientService.GiveToPet(nutrient.Pet.Id, nutrient);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
