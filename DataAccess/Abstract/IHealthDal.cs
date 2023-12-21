using Core;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHealthDal : IAsyncRepository<Health>
    {
        public Task<Health> GetHealthByPetId(int id);
    }
}
