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
    public class EfHealthDal : EfRepositoryBase<Health, PetContext>, IHealthDal
    {
        public async Task<Health> GetHealthByPetId(int id)
        {
            using (PetContext context = new PetContext())
            {
                var result = context.Healths.Where(h => h.Pet.Id == id)
                    .Include(p => p.Pet);

                return await result.SingleOrDefaultAsync();
            }
        }
    }
}
