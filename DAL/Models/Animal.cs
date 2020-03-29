using System;

namespace DAL.Models
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        
        public AnimalType AnimalType { get; set; }

        public DateTime BirthDate { get; set; }

        public int Weight { get; set; }

        public DateTime FedToTime { get; set; }

        public string FoodType { get; set; }
    }
}