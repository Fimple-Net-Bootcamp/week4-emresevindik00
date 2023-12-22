using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class SocialInteractionDto
    {
        public string InteractionName { get; set; }
        public Pet Pet { get; set; }
    }
}
