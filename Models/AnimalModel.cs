using System;

namespace Models
{
    [Serializable]
    public class AnimalModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AnimalType { get; set; }

        public DateTime BirthDate { get; set; }

        public int Weight { get; set; }

        public DateTime FedToTime { get; set; }

        public string FoodType { get; set; }
    }
}