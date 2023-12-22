using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("educations")]
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;
        private readonly IValidator<EducationDto> _validator;

        public EducationController(IEducationService educationService, IMapper mapper, IValidator<EducationDto> validator)
        {
            _educationService = educationService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int petId, EducationDto education)
        {
            var validatorResult = _validator.Validate(education);

            if (!validatorResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
            }

            var educationDtoToUser = _mapper.Map<Education>(education);

            var result = await _educationService.AddToPet(petId, educationDtoToUser);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("educations/{id}")]
        public async Task<IActionResult> GetByPetId(int id)
        {
            var educationResponse = await _educationService.GetByPetId(id);

            if (educationResponse == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<EducationDto>(educationResponse);

            return Ok(result);
        }
    }
}
