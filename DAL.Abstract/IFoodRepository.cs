using System.Linq;
using Entities;

namespace DAL.Abstract
{
    public interface IFoodRepository
    {
        IQueryable<Food> GetAll();

        Food GetById(int id);

        void Update(Food food);

        void Create(Food food);
    }
}