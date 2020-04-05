using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ZooDbContext _dbset;

        public FoodRepository(ZooDbContext dbset)
        {
            _dbset = dbset;
        }

        public IQueryable<Food> GetAll()
        {
            return _dbset.Food.AsQueryable().AsNoTracking();
        }

        public Food GetById(int id)
        {
            return _dbset.Food.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public void Update(Food food)
        {
            _dbset.Food.Update(food);
        }
    }
}