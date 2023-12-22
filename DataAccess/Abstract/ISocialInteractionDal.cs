using Core;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISocialInteractionDal : IAsyncRepository<SocialInteraction>
    {
        public Task<SocialInteraction> AddToPet(int id, SocialInteraction socialInteraction);
        public Task<SocialInteraction> GetByPetId(int id);
    }
}
