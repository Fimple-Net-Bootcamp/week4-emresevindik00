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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IPetService _petService;

        public UserManager(IUserDal userDal, IPetService petService)
        {
            _userDal = userDal;
            _petService = petService;
        }

        public async Task<User> Create(User user)
        {
            return await _userDal.AddAsync(user);
        }

        public async Task<User> GetById(int id)
        {
            return await _userDal.GetAsync(u => u.Id == id);
        }


        public Statistic GetStatisticById(int id)
        {
            int petId = _userDal.GetStatisticByUserId(id);

            return _petService.GetAllStatisticsById(id);
        }
    }
}
