using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Models;
using DAL.Interfaces;

namespace BLL
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public AnimalService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public DateTime CurrentTime { get; set; } = DateTime.Now;

        public IEnumerable<AnimalModel> GetAllAnimals()
        {
            var animals = _unit.AnimalRepository.GetAll();

            return _mapper.Map<IEnumerable<AnimalModel>>(animals);
        }
    }
}