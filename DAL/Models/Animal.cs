using System;
using DAL.Models;
using DAL.Types;

namespace DAL
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        
        public AnimalType AnimalType { get; set; }

        public DateTime BirthDate { get; set; }

        public int Weight { get; set; }
    }
}