using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPetService
    {
        Task<List<Pet>> GetAll();
        Task<Pet> GetById(int id);
        Task<Pet> Add(Pet pet);
        Task<Pet> Update(Pet pet);
        Statistic GetAllStatisticsById(int id);
    }
}
