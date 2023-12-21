using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INutrientService
    {
        Task<List<Nutrient>> GetAll();
        Task<Nutrient> GiveToPet(int id, Nutrient nutrient);
    }
}
