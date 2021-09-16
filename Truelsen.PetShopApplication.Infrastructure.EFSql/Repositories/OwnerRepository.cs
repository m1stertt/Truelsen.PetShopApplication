using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql.Repositories
{
    public class OwnerRepository : IPetRepository
    {

        public Pet Add(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Pet Delete(int petId)
        {
            throw new System.NotImplementedException();
        }

        public Pet Update(Pet pet)
        {
            throw new System.NotImplementedException();
        }
    }
}