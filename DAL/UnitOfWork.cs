using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZooDbContext _context;

        public UnitOfWork(ZooDbContext context, IAnimalRepository animalRepository, IFoodRepository foodRepository)
        {
            _context = context;
            AnimalRepository = animalRepository;
            FoodRepository = foodRepository;
        }

        public IAnimalRepository AnimalRepository { get; }
        public IFoodRepository FoodRepository { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}