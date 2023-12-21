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

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<User> Create(User user)
        {
            return await _userDal.AddAsync(user);
        }

        public async Task<User> GetById(int id)
        {
            return await _userDal.GetAsync(u => u.Id == id);
        }
    }
}
