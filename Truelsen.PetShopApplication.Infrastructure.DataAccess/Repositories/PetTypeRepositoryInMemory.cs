using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.DataAccess.Repositories
{
    public class PetTypeRepositoryInMemory : IPetTypeRepository
    {
        private static List<PetType> _petTypeTable = new List<PetType>();
        private static int _id = 1;

        public PetTypeRepositoryInMemory()
        {
            PetType petType = new PetType()
            {
                Id = _id++,
                Name = "Goat",
            };
            _petTypeTable.Add(petType);
        }

        public PetType Add(PetType petType)
        {
            petType.Id = _id++;
            _petTypeTable.Add(petType);
            return petType;
        }

        public List<PetType> GetAll()
        {
            return _petTypeTable;
        }

        public PetType Update(PetType petType)
        {
            return _petTypeTable.Find(petTypeId => petTypeId.Id == petType.Id);
        }

        public PetType Delete(PetType petType)
        {
            return _petTypeTable.Find(petTypeId => petTypeId.Id == petType.Id);
        }
    }
}