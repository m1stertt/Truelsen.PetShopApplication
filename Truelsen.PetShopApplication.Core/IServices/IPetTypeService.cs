using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Core.IServices
{
    public interface IPetTypeService
    {
        PetType Create(PetType petType);

        List<PetType> ReadAll();

        PetType Update(PetType petType);

        PetType Delete(int id);

        PetType FindById(int id);
    }
}