using System;

namespace Models
{
    [Serializable]
    public class FoodModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string FoodType { get; set; }

        public int Calorific { get; set; }

        public int AssimilationMultiplierCoefficient { get; set; }

        public int Quantity { get; set; }
    }
}