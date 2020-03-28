using System.Collections.Generic;
using BLL.Models;

namespace BLL
{
    public interface IAnimalService
    {
        IEnumerable<AnimalModel> GetAllAnimals();

        public AnimalModel GetAnimal(int id);
    }
}