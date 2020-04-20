using System.Collections.Generic;
using Models;

namespace Business.Abstract
{
    public interface IAnimalService
    {
        IEnumerable<AnimalModel> GetAllAnimals();
        IEnumerable<AnimalModel> GetHungryAnimals();
        AnimalModel GetAnimalById(int id);
        bool FeedAnimal(AnimalModel animal, FoodModel food);
        void CreateAnimal(AnimalModel animalModel);
    }
}