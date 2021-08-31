using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType Add(PetType petType);

        List<PetType> GetAll();
        PetType Update(PetType petType);
        PetType Delete(PetType petType);
    }
}