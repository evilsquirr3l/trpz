using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZooDbContext _context;

        public UnitOfWork(ZooDbContext context, IRepository<Animal> animalRepository, IRepository<FoodType> foodTypesRepository, IRepository<Food> foodRepository)
        {
            _context = context;
            AnimalRepository = animalRepository;
            FoodTypesRepository = foodTypesRepository;
            FoodRepository = foodRepository;
        }

        public IRepository<Animal> AnimalRepository { get; }
        public IRepository<FoodType> FoodTypesRepository { get; }
        public IRepository<Food> FoodRepository { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}