using System;
using System.Collections.Generic;

namespace Truelsen.PetShopApplication.Core.Models
{
    public class Pet
    {
        public int? PetId { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        
        public List<PetColor> Colors { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public double Price { get; set; }
        
        public Owner PreviousOwner { get; set; }
        
    }
}