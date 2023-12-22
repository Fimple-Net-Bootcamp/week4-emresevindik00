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
    public class SocialInteractionManager : ISocialInteractionService
    {
        ISocialInteractionDal _socialInteractionDal;

        public SocialInteractionManager(ISocialInteractionDal socialInteractionDal)
        {
            _socialInteractionDal = socialInteractionDal;
        }

        public Task<SocialInteraction> AddToPet(int id, SocialInteraction socialInteraction)
        {
            return _socialInteractionDal.AddToPet(id, socialInteraction);
        }

        public Task<SocialInteraction> GetByPetId(int id)
        {
            return _socialInteractionDal.GetByPetId(id);
        }
    }
}
