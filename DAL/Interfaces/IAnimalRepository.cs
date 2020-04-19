using System.Linq;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> GetAll();

        Animal GetById(int id);

        void Update(Animal animal);

        void Create(Animal animal);
    }
}