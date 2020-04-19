using System;
using System.Windows;
using BLL.Interfaces;
using BLL.Models;

namespace ViewModel
{
    public class AddAnimalVM
    {
        private RelayCommand _create;
        private readonly IAnimalService _animalService;

        public AddAnimalVM(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public RelayCommand CreateAnimal => _create ??= new RelayCommand(obj =>
        {
            var animalModel = new AnimalModel()
            {
                Name = Name,
                AnimalType = AnimalType,
                BirthDate = BirthDate,
                Weight = Weight,
                FedToTime = FedToTime,
                FoodType = FoodType
            };
            
            _animalService.CreateAnimal(animalModel);
            var window = obj as Window;
            window.Close();
        }, IsFieldsNotEmpty);
        
        public string Name { get; set; }

        public string AnimalType { get; set; }

        public DateTime BirthDate { get; set; }

        public int Weight { get; set; }

        public DateTime FedToTime { get; set; }

        public string FoodType { get; set; }

        private bool IsFieldsNotEmpty(object _)
        {
            if (string.IsNullOrEmpty(Name) 
                || string.IsNullOrEmpty(AnimalType) 
                || FedToTime == default
                || Weight == 0
                || BirthDate == default
                || string.IsNullOrEmpty(FoodType))
            {
                return false;
            }

            return true;
        }
    }
}