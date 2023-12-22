using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using Entities.Request;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("healths")]
    public class HealthController : Controller
    {
        private readonly IHealthService _healthService;
        private readonly IMapper _mapper;
        private readonly IValidator<HealthDto> _validator;

        public HealthController(IHealthService healthService, IMapper mapper, IValidator<HealthDto> validator)
        {
            _healthService = healthService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPetId(int id)
        {
            var healthResponse = await _healthService.GetHealthByPetId(id);

            if (healthResponse == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<PetDto>(healthResponse);

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchByPetId(JsonPatchDocument<Health> healthRequest, int id)
        {
            var updatedHealth = await _healthService.GetHealthByPetId(id);


            if (updatedHealth == null)
            {
                return NoContent();
            }

            healthRequest.ApplyTo(updatedHealth, ModelState);

            _healthService.PatchHealthByPetId(updatedHealth);

            return Ok(updatedHealth);
        }
    }
}
