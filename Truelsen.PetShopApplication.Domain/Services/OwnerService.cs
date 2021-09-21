using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        
        private readonly IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository)
        {
            _repository = repository;
        }
        
        public Owner Create(Owner owner)
        {
            return _repository.Add(owner);
        }

        public List<Owner> GetAll()
        {
            return _repository.GetAll();
        }

        public Owner Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Owner Update(Owner owner)
        {
            return _repository.Update(owner);
        }

        public Owner Find(int id)
        {
            var allOwners = _repository.GetAll();
            foreach (var owner in allOwners)
            {
                if (owner.OwnerId == id)
                {
                    return owner;
                }
            }
            return null;
        }
    }
}