using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Add(Pet pet);

        List<Pet> GetAll();

        Pet GetById(int id);

        Pet Delete(int petId);

        Pet Update(Pet pet);

        List<Pet> GetByType(string type);
    }
}