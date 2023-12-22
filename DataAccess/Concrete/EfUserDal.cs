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
    public class EfUserDal : EfRepositoryBase<User, PetContext>, IUserDal
    {
        public int GetStatisticByUserId(int userId)
        {
            using (PetContext context = new PetContext())
            {
                var pets = context.Users.Where(e => e.Id == userId)
                    .Include(e => e.Pet)
                    .SingleOrDefault();

                int id = pets.Pet.Id;

                return id;
            }
        }
    }
}
