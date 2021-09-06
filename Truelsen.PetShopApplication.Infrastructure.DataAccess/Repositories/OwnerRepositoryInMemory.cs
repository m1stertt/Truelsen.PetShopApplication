using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.DataAccess.Repositories
{
    public class OwnerRepositoryInMemory : IOwnerRepository
    {
        
        private static List<Owner> _ownerTable = new List<Owner>();
        private static int _id = 1;
        private static bool _hasInitializedData = false;

        public OwnerRepositoryInMemory()
        {
            Owner owner1 = new Owner()
            {
                Id = _id++,
                FirstName = "Peter",
                LastName = "Hansen"
            };
            _ownerTable.Add(owner1);
        }
        
        #region CRUD

        public Owner Add(Owner owner)
        {
            owner.Id = _id++;
            _ownerTable.Add(owner);
            return owner;
        }

        public List<Owner> GetAll()
        {
            return _ownerTable;
        }

        public Owner Delete(int id)
        {
            Owner foundOwner = _ownerTable.Find(owner => id == owner.Id);
            _ownerTable.Remove(foundOwner);
            return foundOwner;
        }

        public Owner Update(Owner owner)
        {
            return null;
        }

        #endregion

    }
}