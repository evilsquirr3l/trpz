using System.Windows;
using BLL.Interfaces;
using BLL.Models;

namespace ViewModel
{
    public class AddFoodVM
    {
        private RelayCommand _create;
        private readonly IFoodService _foodService;

        public AddFoodVM(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public RelayCommand CreateFood => _create ??= new RelayCommand(obj =>
        {
            var foodModel = new FoodModel()
            {
                AssimilationMultiplierCoefficient = AssimilationMultiplierCoefficient, Calorific = Calorific,
                FoodType = FoodType, Name = Name, Quantity = Quantity
            };

            _foodService.Create(foodModel);
            var window = obj as Window;
            window.Close();
        }, IsFieldsNotEmpty);

        public string Name { get; set; }

        public string FoodType { get; set; }

        public int Calorific { get; set; }

        public int AssimilationMultiplierCoefficient { get; set; }

        public int Quantity { get; set; }

        private bool IsFieldsNotEmpty(object _)
        {
            if (string.IsNullOrEmpty(Name)
                || string.IsNullOrEmpty(Name)
                || Quantity == 0
                || AssimilationMultiplierCoefficient == 0
                || Calorific == 0
                || string.IsNullOrEmpty(FoodType))
            {
                return false;
            }

            return true;
        }
    }
}