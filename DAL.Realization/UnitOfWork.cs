using System.Linq;
using Dal.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Realization
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
            
            Detach();
        }

        private void Detach()
        {
            foreach (var entity in _context.ChangeTracker.Entries().ToArray())
                if (entity.Entity != null)
                    entity.State = EntityState.Detached;
        }
    }
}