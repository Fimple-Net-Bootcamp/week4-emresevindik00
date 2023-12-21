using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfRepositoryBase<User, PetContext>, IUserDal
    {
    }
}
