using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace Business.Realization.Services
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public FoodService(IUnitOfWork unit, IMapper mapper, IAnimalService animalService)
        {
            _unit = unit;
            _mapper = mapper;
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
    }
}