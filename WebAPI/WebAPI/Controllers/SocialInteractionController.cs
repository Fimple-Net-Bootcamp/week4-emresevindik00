using AutoMapper;
using Business.Abstract;
using Entities.Dtos;
using Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("socialInteractions")]
    public class SocialInteractionController : Controller
    {
        private readonly ISocialInteractionService _socialInteractionService;
        private readonly IMapper _mapper;
        private readonly IValidator<SocialInteractionDto> _validator;

        public SocialInteractionController(ISocialInteractionService socialInteractionService, IMapper mapper, IValidator<SocialInteractionDto> validator)
        {
            _socialInteractionService = socialInteractionService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int petId, SocialInteractionDto socialInteraction)
        {
            var validatorResult = _validator.Validate(socialInteraction);

            if (!validatorResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
            }

            var socialInteractionnDtoToSocialInteraction = _mapper.Map<SocialInteraction>(socialInteraction);

            var result = await _socialInteractionService.AddToPet(petId, socialInteractionnDtoToSocialInteraction);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("educations/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var educationResponse = await _socialInteractionService.GetByPetId(id);

            if (educationResponse == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<EducationDto>(educationResponse);

            return Ok(result);
        }
    }
}
