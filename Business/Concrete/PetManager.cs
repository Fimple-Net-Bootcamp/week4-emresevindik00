using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PetManager : IPetService
    {
        IPetDal _petDal;
        IHealthService _healthService;
        IActivityService _activityService;
        INutrientService _nutrientService;

        public PetManager(IPetDal petDal, IHealthService healthService, IActivityService activityService, INutrientService nutrientService)
        {
            _petDal = petDal;
            _healthService = healthService;
            _activityService = activityService;
            _nutrientService = nutrientService;
        }
        public async Task<Pet> Add(Pet pet)
        {
            return await _petDal.AddAsync(pet);
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _petDal.GetAllAsync();
        }

        public Statistic GetAllStatisticsById(int id)
        {
            Statistic statistic = new Statistic();

            var healths = _healthService.GetHealthByPetId(id);
            statistic.Healths.Add(healths.Result);

            var activities = _activityService.GetByPetId(id);
            statistic.Activities.Add(activities.Result);

            var nutrients = _nutrientService.GetByPetId(id);
            statistic.Nutrients.Add(nutrients.Result);

            return statistic;
        }

        public async Task<Pet> GetById(int id)
        {
            return await _petDal.GetAsync(p => p.Id == id);
        }

        public async Task<Pet> Update(Pet pet)
        {
            return await _petDal.UpdateAsync(pet);
        }
    }
}
