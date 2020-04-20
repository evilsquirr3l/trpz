using System.Linq;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Realization.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ZooDbContext _context;

        public FoodRepository(ZooDbContext context)
        {
            _context = context;
        }

        public IQueryable<Food> GetAll()
        {
            return _context.Food.AsQueryable().AsNoTracking();
        }

        public Food GetById(int id)
        {
            return _context.Food.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public void Update(Food food)
        {
            _context.Food.Update(food);
        }

        public void Create(Food food)
        {
            _context.Food.Add(food);
        }
    }
}