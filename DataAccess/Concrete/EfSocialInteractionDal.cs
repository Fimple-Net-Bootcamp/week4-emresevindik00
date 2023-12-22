using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfSocialInteractionDal : EfRepositoryBase<SocialInteraction, PetContext>, ISocialInteractionDal
    {
        public async Task<SocialInteraction> AddToPet(int id, SocialInteraction socialInteraction)
        {
            using (PetContext context = new PetContext())
            {
                var pets = await context.Pets.FindAsync(id);

                socialInteraction.Pet.Id = id;
                await context.SocialInteractions.AddAsync(socialInteraction);
                await context.SaveChangesAsync();
                return socialInteraction;
            }
        }

        public async Task<SocialInteraction> GetByPetId(int id)
        {
            using (PetContext context = new PetContext())
            {
                var pets = await context.SocialInteractions.Where(e => e.Pet.Id == id)
                    .Include(e => e.Pet)
                    .SingleOrDefaultAsync();

                return pets;
            }
        }
    }
}
