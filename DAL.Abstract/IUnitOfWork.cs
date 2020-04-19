
namespace Dal.Abstract
{
    public interface IUnitOfWork
    {
        public IAnimalRepository AnimalRepository { get; }

        public IFoodRepository FoodRepository { get; }

        void Save();
    }
}