using DAL.Types;

namespace DAL.Models
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        
        public int FoodTypeId { get; set; }
        
        public FoodType FoodType { get; set; }

        public int Calorific { get; set; }

        public int AssimilationMultiplierCoefficient { get; set; }
    }
}