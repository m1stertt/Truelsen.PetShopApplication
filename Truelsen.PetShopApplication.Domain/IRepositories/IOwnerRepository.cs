using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner Add(Owner owner);
        

        List<Owner> GetAll();

        Owner Delete(int id);

        Owner Update(Owner owner);
    }
}