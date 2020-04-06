using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
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
    }
}