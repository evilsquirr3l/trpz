using BLL.TypeModels;

namespace BLL.Models
{
    public class FoodModel
    {
        public string Name { get; set; }
        
        public FoodTypeModel FoodType { get; set; }

        public int Calorific { get; set; }

        public int AssimilationMultiplierCoefficient { get; set; }
        
        public int Quantity { get; set; }
    }
}