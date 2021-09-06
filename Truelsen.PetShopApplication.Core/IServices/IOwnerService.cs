using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Core.IServices
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);

        List<Owner> GetAll();
        
        Owner Delete(int id);

        Owner Update(Owner owner);

        Owner Find(int id);


    }
}