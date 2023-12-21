using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class HealthDto
    {
        public string Situation { get; set; }
        public Pet Pet { get; set; }
    }
}
