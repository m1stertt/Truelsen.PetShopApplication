using System.Collections.Generic;

namespace Truelsen.PetShopApplication.Core.Models
{
    public class PetType
    {
        public int? PetTypeId { get; set; }
        
        public string Name { get; set; }

        public List<Pet> Pets { get; set; }
    }
}