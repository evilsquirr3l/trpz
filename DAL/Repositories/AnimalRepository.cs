using System.Linq;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

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
            return _dbset.Animals.AsQueryable().AsNoTracking();
        }

        public Animal GetById(int id)
        {
            return _dbset.Animals.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public void Update(Animal animal)
        {
            _dbset.Animals.Update(animal);
        }
    }
}