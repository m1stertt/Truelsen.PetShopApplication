using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Core.IServices
{
    public interface IPetService
    {
        Pet Create(Pet pet);

        List<Pet> GetAll();
        
        Pet Delete(int petId);

        Pet Update(Pet pet);

        List<Pet> Find(string type);
        
    }
}