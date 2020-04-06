﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class FoodService : IFoodService
    {
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public FoodService(IUnitOfWork unit, IMapper mapper, IAnimalService animalService)
        {
            _unit = unit;
            _mapper = mapper;
            _animalService = animalService;
        }

        public IEnumerable<FoodModel> GetAll()
        {
            var food = _unit.FoodRepository.GetAll();

            return _mapper.Map<IEnumerable<FoodModel>>(food);
        }

        public FoodModel GetById(int id)
        {
            var food = _unit.FoodRepository.GetById(id);

            return _mapper.Map<FoodModel>(food);
        }

        public IEnumerable<FoodModel> GetSuitableFoodForAnimal(int animalId)
        {
            var animal = _animalService.GetAnimalById(animalId);
            var suitableFood = GetAll().Where(f => f.FoodType.Equals(animal.FoodType));

            return suitableFood;
        }
    }
}