using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Statistic
    {
        public List<Health> Healths { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Nutrient> Nutrients { get; set; }
    }
}
