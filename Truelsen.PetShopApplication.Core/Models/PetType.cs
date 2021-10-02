using System.Collections.Generic;

namespace Truelsen.PetShopApplication.Core.Models
{
    public class PetType
    {
        public int? PetTypeId { get; set; }
        
        public string PetTypeName { get; set; }

        public List<Pet> PetTypePets { get; set; }
    }
}