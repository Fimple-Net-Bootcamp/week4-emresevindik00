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
    public class PetManager : IPetService
    {
        IPetDal _petDal;

        public PetManager(IPetDal petDal)
        {
            _petDal = petDal;
        }
        public async Task<Pet> Add(Pet pet)
        {
            return await _petDal.AddAsync(pet);
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _petDal.GetAllAsync();
        }

        public async Task<Pet> GetById(int id)
        {
            return await _petDal.GetAsync(p => p.Id == id);
        }

        public async Task<Pet> Update(Pet pet)
        {
            return await _petDal.UpdateAsync(pet);
        }
    }
}
