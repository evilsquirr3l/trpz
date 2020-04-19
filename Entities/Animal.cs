using System;

namespace Entities
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }

        public string AnimalType { get; set; }

        public DateTime BirthDate { get; set; }

        public int Weight { get; set; }

        public DateTime FedToTime { get; set; }

        public string FoodType { get; set; }
    }
}