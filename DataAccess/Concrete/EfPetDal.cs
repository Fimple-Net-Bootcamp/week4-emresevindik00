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
    public class EfPetDal : EfRepositoryBase<Pet, PetContext>, IPetDal
    {
    }
}
