using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeRepository _repository;

        public PetTypeService(IPetTypeRepository repository)
        {
            _repository = repository;
        }

        public PetType Create(PetType petType)
        {
            return _repository.Add(petType);
        }

        public List<PetType> ReadAll()
        {
            return _repository.GetAll();
        }

        public PetType Update(PetType petType)
        {
            return _repository.Update(petType);
        }

        public PetType Delete(int id)
        {
            return _repository.Delete(id);
        }

        public PetType FindById(int id)
        {
            var allPetTypes = _repository.GetAll();
            foreach (var petType in allPetTypes)
            {
                if (petType.PetTypeId == id)
                {
                    return petType;
                }

            }
            return null;
        }
    }
}