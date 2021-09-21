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

                Name = "Goat",
            };
            _petTypeTable.Add(petType);
        }

        public PetType Add(PetType petType)
        {
            petType.PetTypeId = _id++;
            _petTypeTable.Add(petType);
            return petType;
        }

        public List<PetType> GetAll()
        {
            return _petTypeTable;
        }

        public PetType Update(PetType petType)
        {
            PetType foundPetType =_petTypeTable.Find(petTypeId => petTypeId.PetTypeId == petType.PetTypeId);
            _petTypeTable.Remove(foundPetType);
            return foundPetType;
        }

        public PetType Delete(int id)
        {
            PetType foundPetType =_petTypeTable.Find(petTypeId => petTypeId.PetTypeId == id);
            return foundPetType;
        }

        public PetType GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}