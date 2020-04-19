using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IFoodService
    {
        IEnumerable<FoodModel> GetAll();

        FoodModel GetById(int id);

        IEnumerable<FoodModel> GetSuitableFoodForAnimal(int animalId);

        void Create(FoodModel foodModel);
    }
}