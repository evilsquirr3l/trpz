using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZooDbContext _context;

        public AnimalRepository(ZooDbContext context)
        {
            _context = context;
        }

        public IQueryable<Animal> GetAll()
        {
            return _context.Animals.AsQueryable().AsNoTracking();
        }

        public Animal GetById(int id)
        {
            return _context.Animals.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public void Update(Animal animal)
        {
            _context.Animals.Update(animal);
        }

        public void Create(Animal animal)
        {
            _context.Animals.Add(animal);
        }
    }
}