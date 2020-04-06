using System.Linq;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public void Save()
        {
            _context.SaveChanges();

            foreach (var cosmetic in _context.ChangeTracker.Entries().ToArray())
                if (cosmetic.Entity != null)
                    cosmetic.State = EntityState.Detached;
        }
    }
}