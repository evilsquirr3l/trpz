using System.Linq;
using Entities;

namespace Dal.Abstract
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> GetAll();

        Animal GetById(int id);

        void Update(Animal animal);

        void Create(Animal animal);
    }
}