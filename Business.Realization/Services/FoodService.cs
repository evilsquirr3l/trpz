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
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly ISerialization _serializer;

        public FoodService(IUnitOfWork unit, IMapper mapper, IAnimalService animalService, ISerialization serializer)
        {
            _unit = unit;
            _mapper = mapper;
            _serializer = serializer;
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
            var animal = _unit.AnimalRepository.GetById(animalId);
            var suitableFood = GetAll().Where(f => f.FoodType.Equals(animal.FoodType));

            return suitableFood;
        }

        public void Create(FoodModel foodModel)
        {
            var food = _mapper.Map<Food>(foodModel);

            _unit.FoodRepository.Create(food);
            
            _unit.Save();
        }

        public void Serialize(ICollection<FoodModel> foodModels, string path)
        {
            _serializer.Serialization(foodModels, path);
        }

        public ICollection<FoodModel> Deserialize(string path)
        {
            return _serializer.Deserialization(path) as ICollection<FoodModel>;
        }
    }
}