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

        public List<Pet> FindByType(string type)
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

        public List<Pet> SortByPrice()
        {
            List<Pet> sortedList = GetAll().OrderBy(pet => pet.Price).ToList();
            return sortedList;
        }

        
        
        public Pet FindById(int id)
        {
            var allPets = _repository.GetAll();
            foreach (var pet in allPets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }

            return null;
        }
    }
}