using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEducationService
    {
        Task<Education> AddToPet(int id, Education education);
        Task<Education> GetByPetId(int id);
    }
}
