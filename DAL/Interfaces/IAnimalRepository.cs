using System.Linq;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> GetAll();
        
        Animal GetById(int id);
    }
}