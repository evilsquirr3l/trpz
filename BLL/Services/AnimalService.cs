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
    }
}