﻿using System.Collections.Generic;
using BLL.Models;

namespace BLL
{
    public interface IAnimalService
    {
        IEnumerable<AnimalModel> GetAllAnimals();
        IEnumerable<AnimalModel> GetHungryAnimals();
        AnimalModel GetAnimal(int id);
        bool FeedAnimal(int animalId, FoodModel food);
    }
}