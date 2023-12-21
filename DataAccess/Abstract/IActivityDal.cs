using Core;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IActivityDal : IAsyncRepository<Activity>
    {
        public Task<Activity> GetActivityByPetId(int id);
    }
}
