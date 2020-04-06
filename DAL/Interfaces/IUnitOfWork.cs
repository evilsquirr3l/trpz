using DAL.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IAnimalRepository AnimalRepository { get; }

        public IFoodRepository FoodRepository { get; }

        void Save();
    }
}