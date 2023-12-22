using Core;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEducationDal : IAsyncRepository<Education>
    {
        public Task<Education> GetByPetId(int id);
        public Task<Education> GiveToPet(int id, Education education);
    }
}
