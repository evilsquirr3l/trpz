using System.Linq;
using DAL.Models;

namespace DAL.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZooDbContext _dbset;

        public AnimalRepository(ZooDbContext dbset)
        {
            _dbset = dbset;
        }
        
        public IQueryable<Animal> GetAll()
        {
            return _dbset.Animals.AsQueryable();
        }

        public Animal GetById(int id)
        {
            return _dbset.Animals.Find(id);
        }
    }
}