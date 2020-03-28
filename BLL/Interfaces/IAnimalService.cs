using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL
{
    public interface IAnimalService
    {
        DateTime CurrentTime { get; set; }
        IEnumerable<AnimalModel> GetAllAnimals();
    }
}