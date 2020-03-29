using System;

namespace BLL.Models
{
    public class AnimalModel
    {
        public readonly int CaloriesPerDayToFeed;

        public AnimalModel()
        {
            CaloriesPerDayToFeed = Weight * (DateTime.Now - BirthDate).Days / 1000;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string AnimalType { get; set; }

        public DateTime BirthDate { get; set; }

        public int Weight { get; set; }

        public DateTime FedToTime { get; set; }

        public string FoodType { get; set; }
    }
}