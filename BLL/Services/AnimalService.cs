using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Models;
using DAL.Interfaces;

namespace BLL
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly ITimeService _timeService;
        
        public AnimalService(IUnitOfWork unit, IMapper mapper, ITimeService timeService)
        {
            _unit = unit;
            _mapper = mapper;
            _timeService = timeService;
        }
        
        public IEnumerable<AnimalModel> GetAllAnimals()
        {
            var animals = _unit.AnimalRepository.GetAll();

            return _mapper.Map<IEnumerable<AnimalModel>>(animals);
        }

        public IEnumerable<AnimalModel> GetHungryAnimals()
        {
            var hungryAnimals = GetAllAnimals().Where(a => a.FedToTime < _timeService.CurrentTime);

            return hungryAnimals;
        }

        public AnimalModel GetAnimal(int id)
        {
            var animal = _unit.AnimalRepository.GetById(id);

            return _mapper.Map<AnimalModel>(animal);
        }

        public bool FeedAnimal(int animalId, FoodModel food)
        {
            var animal = GetAnimal(animalId);

            if (!IsAnimalHungry(animal) || !IsAnimalEatsFood(animal, food) || !IsEnoughFood(food))
            {
                return false;
            }
            
            var hoursFed = CalculateAssimilationHours(animal, food);
            animal.FedToTime.AddHours(hoursFed);

            return true;
        }

        private bool IsEnoughFood(FoodModel foodModel)
        {
            return foodModel.Quantity > 1;
        }

        private bool IsAnimalHungry(AnimalModel animal)
        {
            return animal.FedToTime < DateTime.Now;
        }

        private bool IsAnimalEatsFood(AnimalModel animal, FoodModel food)
        {
            return animal.FoodTypes.Contains(food.FoodType);
        }

        private int CalculateAssimilationHours(AnimalModel animal, FoodModel food)
        {
            var hours = animal.CaloriesPerDayToFeed - food.Calorific / food.AssimilationMultiplierCoefficient;

            return hours;
        }
    }
}