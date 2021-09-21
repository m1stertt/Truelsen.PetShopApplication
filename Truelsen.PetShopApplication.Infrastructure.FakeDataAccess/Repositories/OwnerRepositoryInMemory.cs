using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.DataAccess.Repositories
{
    public class OwnerRepositoryInMemory : IOwnerRepository
    {
        
        // private static List<Owner> _ownerTable = new List<Owner>();
        // private static int _id = 1;

        public OwnerRepositoryInMemory()
        {
            if (FakeDB.Owners.Count > 0) return;
            Owner owner1 = new Owner()
            {
                OwnerId = FakeDB.OwnerId++,
                FirstName = "Peter",
                LastName = "Hansen",
                
                
            };
            FakeDB.Owners.Add(owner1);
            Owner owner2 = new Owner()
            {
                OwnerId = FakeDB.OwnerId++,
                FirstName = "Jacob",
                LastName = "Larsen",
                
                
            };
            FakeDB.Owners.Add(owner2);
        }
        
        #region CRUD

        public Owner Add(Owner owner)
        {
            owner.OwnerId = FakeDB.OwnerId++;
            FakeDB.Owners.Add(owner);
            return owner;
        }

        public List<Owner> GetAll()
        {
            return FakeDB.Owners;
        }

        public Owner Delete(int id)
        {
            Owner foundOwner = FakeDB.Owners.Find(owner => id == owner.OwnerId);
            FakeDB.Owners.Remove(foundOwner);
            return foundOwner;
        }

        public Owner Update(Owner owner)
        {
            return null;
        }

        #endregion

    }
}