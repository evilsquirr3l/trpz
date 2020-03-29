using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZooDbContext _context;

        public UnitOfWork(ZooDbContext context, IRepository<Animal> animalRepository, IRepository<Food> foodRepository)
        {
            _context = context;
            AnimalRepository = animalRepository;
            FoodRepository = foodRepository;
        }

        public IRepository<Animal> AnimalRepository { get; }
        public IRepository<Food> FoodRepository { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}