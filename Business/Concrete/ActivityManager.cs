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
    public class ActivityManager : IActivityService
    {
        IActivityDal _activityDal;

        public ActivityManager(IActivityDal activityDal)
        {
            _activityDal = activityDal;
        }

        public Task<Activity> Add(Activity activity)
        {
            return _activityDal.AddAsync(activity);
        }

        public Task<Activity> GetByPetId(int id)
        {
            return _activityDal.GetActivityByPetId(id);
        }
    }
}
