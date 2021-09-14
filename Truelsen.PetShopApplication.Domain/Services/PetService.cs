using System.Collections.Generic;
using System.Linq;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;


        public PetService(IPetRepository petPetRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petPetRepository;
            _ownerRepository = ownerRepository;
        }

        public List<Pet> FindPetByTypeIncludePreviousOwner(string type)
        {
            var pets = FindByType(type);
            var owners = _ownerRepository.GetAll();
            foreach (var pet in pets)
            {
                foreach (var owner in owners)
                {
                    if (pet.PreviousOwner.Id == owner.Id)
                    {
                        pet.PreviousOwner = new Owner()
                        {
                            Id = owner.Id,
                            Address = owner.Address,
                            Email = owner.Email,
                            FirstName = owner.FirstName,
                            LastName = owner.LastName,
                            PhoneNumber = owner.PhoneNumber
                        };
                    }
                }
            }
            return pets;
        }

        public Pet Create(Pet pet)
        {
            return _petRepository.Add(pet);
        }

        public List<Pet> GetAll()
        {
            return _petRepository.GetAll();
        }

        public Pet Update(Pet pet)
        {
            return _petRepository.Update(pet);
        }

        public Pet Delete(int petId)
        {
            return _petRepository.Delete(petId);
        }

        public List<Pet> FindByType(string type)
        {
            var allPets = _petRepository.GetAll();
            List<Pet> results = new List<Pet>();
            foreach (var pet in allPets)
            {
                if (pet.Type.Name.Equals(type))
                {
                    results.Add(new Pet()
                    {
                        Id = pet.Id,
                        Name = pet.Name,
                        Birthdate = pet.Birthdate,
                        Color = pet.Color,
                        Type = pet.Type,
                        Price = pet.Price,
                        SoldDate = pet.SoldDate,
                        PreviousOwner = pet.PreviousOwner
                    });
                }
            }

            return results;
        }

        public List<Pet> SortByType(string type)
        {
            var allPets = _petRepository.GetAll();
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
            var allPets = _petRepository.GetAll();
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