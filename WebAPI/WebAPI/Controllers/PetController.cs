using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("pets")]
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        private readonly IValidator<PetDto> _validator;

        public PetController(IPetService petService, IMapper mapper, IValidator<PetDto> validator)
        {
            _petService = petService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PetDto pet)
        {
            var validatorResult = _validator.Validate(pet);

            if (!validatorResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
            }

            var dtoToPet = _mapper.Map<Pet>(pet);
            var result = await _petService.Add(dtoToPet);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _petService.GetAll();

            if (pets == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<List<PetDto>>(pets);

            return Ok(result);
        }

        [HttpPut("/pets/{id}")]
        public async Task<IActionResult> UpdateById(int id, Pet pet)
        {
            var updatedPet = await _petService.GetById(id);

            if (updatedPet == null)
            {
                return NoContent();
            }

            updatedPet.Species = pet.Species;

            _petService.Update(updatedPet);
            

            return Ok(updatedPet);
        }

        [HttpGet("/pets/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var petResponse = await _petService.GetById(id);

            if (petResponse == null)
            {
                return NoContent();
            }

            var result = _mapper.Map<PetDto>(petResponse);

            return Ok(result);
        }

        [HttpGet("/statistics/{id}")]
        public async Task<IActionResult> GetStatisticById(int id)
        {
            var petResponse = _petService.GetAllStatisticsById(id);

            if (petResponse == null)
            {
                return NoContent();
            }

            return Ok(petResponse);
        }
    }
}
