using System.Collections.Generic;
using System.Linq;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repository;

        public PetService(IPetRepository repository)
        {
            _repository = repository;
        }

        public Pet Create(Pet pet)
        {
            return _repository.Add(pet);
        }

        public List<Pet> GetAll()
        {
            return _repository.GetAll();
        }

        public Pet Update(Pet pet)
        {
            return _repository.Update(pet);
        }

        public Pet Delete(int petId)
        {
            return _repository.Delete(petId);
        }

        public List<Pet> Find(string type)
        {
            var allPets = _repository.GetAll();
            List<Pet> results = new List<Pet>();
            foreach (var pet in allPets)
            {
                if (pet.Type.Name.Equals(type))
                {
                    results.Add(pet);
                }
            }

            return results;
        }

        public List<Pet> SortByType(string type)
        {
            List<Pet> sortedList = GetAll().OrderBy(pet => pet.Type.Name).ToList();
            return sortedList;
        }
    }
}