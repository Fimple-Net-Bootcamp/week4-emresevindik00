﻿using Core.DataAccess;
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
    public class EfNutrientDal : EfRepositoryBase<Nutrient, PetContext>, INutrientDal
    {
        public async Task<Nutrient> GetByPetId(int id)
        {
            using (PetContext context = new PetContext())
            {
                var pets = await context.Nutrients.Where(e => e.Pet.Id == id)
                    .Include(e => e.Pet)
                    .SingleOrDefaultAsync();

                return pets;
            }
        }

        public async Task<Nutrient> GiveToPet(int id, Nutrient nutrient)
        {
            using (PetContext context = new PetContext())
            {
                var pets = await context.Pets.FindAsync(id);

                nutrient.Pet.Id = id;
                var addedEntity = context.Entry(nutrient);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return nutrient;
            }
        }
    }
}
