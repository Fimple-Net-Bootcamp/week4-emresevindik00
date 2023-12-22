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
    public class NutrientManager : INutrientService
    {
        INutrientDal _nutrientDal;

        public NutrientManager(INutrientDal nutrientDal)
        {
            _nutrientDal = nutrientDal;
        }
        public Task<List<Nutrient>> GetAll()
        {
            return _nutrientDal.GetAllAsync();
        }

        public Task<Nutrient> GetByPetId(int id)
        {
            return _nutrientDal.GetByPetId(id);
        }

        public Task<Nutrient> GiveToPet(int id, Nutrient nutrient)
        {
            return _nutrientDal.GiveToPet(id, nutrient);
        }
    }
}
