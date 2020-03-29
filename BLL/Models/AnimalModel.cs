using System;
using System.Collections.Generic;
using DAL.Types;

namespace BLL.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public AnimalType AnimalType { get; set; }

        public DateTime BirthDate { get; set; }

        public int Weight { get; set; }

        public DateTime FedToTime { get; set; }

        public ICollection<FoodTypeModel> FoodTypes { get; set; }
        
        public readonly int CaloriesPerDayToFeed;

        public AnimalModel()
        {
            CaloriesPerDayToFeed = Weight * (DateTime.Now - BirthDate).Days / 1000;
        }
    }
}