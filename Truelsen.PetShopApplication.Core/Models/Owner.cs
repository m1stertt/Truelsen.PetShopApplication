using System.Collections.Generic;

namespace Truelsen.PetShopApplication.Core.Models
{
    public class Owner
    {
        public int? OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Pet> OwnerPets { get; set; }

    }
}