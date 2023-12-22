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
    public class EfEducationDal : EfRepositoryBase<Education, PetContext>, IEducationDal
    {
        public async Task<Education> GetByPetId(int id)
        {
            using (PetContext context = new PetContext())
            {
                var pets = await context.Educations.Where(e => e.pet.Id == id)
                    .Include(e => e.pet)
                    .SingleOrDefaultAsync();

                return pets;
            }
        }

        public async Task<Education> GiveToPet(int id, Education education)
        {
            using (PetContext context = new PetContext())
            {
                var pets = await context.Pets.FindAsync(id);

                education.pet.Id = id;
                var addedEntity = context.Entry(education);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return education;
            }
        }
    }
}
