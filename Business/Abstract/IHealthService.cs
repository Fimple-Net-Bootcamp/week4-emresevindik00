using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHealthService
    {
        Task<Health> GetHealthByPetId(int id);
        Task<Health> PatchHealthByPetId(Health health);
    }
}
