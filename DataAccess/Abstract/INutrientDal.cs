using Core;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INutrientDal : IAsyncRepository<Nutrient>
    {
        public Task<Nutrient> GiveToPet(int id, Nutrient nutrient);
    }
}
