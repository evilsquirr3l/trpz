using System.Linq;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IFoodRepository
    {
        IQueryable<Food> GetAll();

        Food GetById(int id);

        void Update(Food food);

        void Create(Food food);
    }
}