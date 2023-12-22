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
    public class EducationManager : IEducationService
    {
        IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public Task<Education> AddToPet(int id, Education education)
        {
            return _educationDal.GiveToPet(id, education);
        }

        public Task<Education> GetByPetId(int id)
        {
            return _educationDal.GetByPetId(id);
        }
    }
}
