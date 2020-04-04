using System.Linq;
using DAL.Interfaces;
using DAL.Models;

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
            return _dbset.Food.AsQueryable();
        }

        public Food GetById(int id)
        {
            return _dbset.Food.Find(id);
        }
    }
}