using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Animal> AnimalRepository { get; }

        public IRepository<FoodType> FoodTypesRepository { get; }

        public IRepository<Food> FoodRepository { get; }
        
        int Save();
    }
}