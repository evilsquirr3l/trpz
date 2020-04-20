using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstract;
using DAL.Abstract;
using Entities;
using FileSerialization;
using Models;

namespace Business.Realization.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly ITimeService _timeService;
        private readonly IUnitOfWork _unit;
        private readonly ISerialization _serializer;

        public AnimalService(IUnitOfWork unit, IMapper mapper, ITimeService timeService, ISerialization serializer)
        {
            _unit = unit;
            _mapper = mapper;
            _timeService = timeService;
            _serializer = serializer;
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

        public AnimalModel GetAnimalById(int id)
        {
            var animal = _unit.AnimalRepository.GetById(id);

            return _mapper.Map<AnimalModel>(animal);
        }

        public bool FeedAnimal(AnimalModel animal, FoodModel food)
        {
            if (!IsAnimalHungry(animal) || !IsAnimalEatsFood(animal, food) || !IsEnoughFood(food)) return false;

            food.Quantity -= 1;

            var hoursFed = CalculateAssimilationHours(animal, food);
            animal.FedToTime = animal.FedToTime.AddHours(hoursFed);

            UpdateEntities(animal, food);

            return true;
        }

        public void CreateAnimal(AnimalModel animalModel)
        {
            var animal = _mapper.Map<Animal>(animalModel);

            _unit.AnimalRepository.Create(animal);
            
            _unit.Save();
        }

        public void Serialize(ICollection<AnimalModel> animalModels, string path)
        {
            _serializer.Serialization(animalModels, path);
        }

        public ICollection<AnimalModel> Deserialize(string path)
        {
            return _serializer.Deserialization(path) as ICollection<AnimalModel>;
        }

        private void UpdateEntities(AnimalModel animal, FoodModel food)
        {
            var animalEntity = _mapper.Map<Animal>(animal);
            var foodEntity = _mapper.Map<Food>(food);
            
            _unit.FoodRepository.Update(foodEntity);
            _unit.AnimalRepository.Update(animalEntity);
            _unit.Save();
        }
        
        private bool IsEnoughFood(FoodModel foodModel)
        {
            return foodModel.Quantity > 1;
        }

        private bool IsAnimalHungry(AnimalModel animal)
        {
            return animal.FedToTime < _timeService.CurrentTime;
        }

        private bool IsAnimalEatsFood(AnimalModel animal, FoodModel food)
        {
            return animal.FoodType.Contains(food.FoodType);
        }

        private int CalculateAssimilationHours(AnimalModel animal, FoodModel food)
        {
            var caloriesPerHour = animal.Weight * (_timeService.CurrentTime - animal.BirthDate).Days;

            var hoursFed = food.Calorific * food.AssimilationMultiplierCoefficient / caloriesPerHour;

            return hoursFed;
        }
    }
}