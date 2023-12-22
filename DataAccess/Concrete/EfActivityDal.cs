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
    public class EfActivityDal : EfRepositoryBase<Activity, PetContext>, IActivityDal
    {
        public async Task<Activity> GetActivityByPetId(int id)
        {
            using (PetContext context = new PetContext())
            {
                var result = context.Activities.Where(a => a.Pet.Id == id)
                    .Include(p => p.Pet);

                return await result.SingleOrDefaultAsync();
            }
        }
    }
}
