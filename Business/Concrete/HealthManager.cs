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
    public class HealthManager : IHealthService
    {
        IHealthDal _healthDal;

        public HealthManager(IHealthDal healthDal)
        {
            _healthDal = healthDal;   
        }
        public Task<Health> GetHealthByPetId(int id)
        {
            return _healthDal.GetHealthByPetId(id);
        }

        public Task<Health> PatchHealthByPetId(Health health)
        {
            return _healthDal.UpdateAsync(health);
        }
    }
}
