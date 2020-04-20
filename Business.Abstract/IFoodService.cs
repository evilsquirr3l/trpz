﻿using System.Collections.Generic;
using Models;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IEnumerable<FoodModel> GetAll();

        FoodModel GetById(int id);

        IEnumerable<FoodModel> GetSuitableFoodForAnimal(int animalId);

        void Create(FoodModel foodModel);
    }
}