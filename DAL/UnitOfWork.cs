using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZooDbContext _context;

        public UnitOfWork(ZooDbContext context, IRepository<Animal> animalRepository)
        {
            _context = context;
            AnimalRepository = animalRepository;
        }

        public IRepository<Animal> AnimalRepository { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}