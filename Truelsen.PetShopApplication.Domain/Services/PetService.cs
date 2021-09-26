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
                    if (pet.PreviousOwner.OwnerId == owner.OwnerId)
                    {
                        pet.PreviousOwner = new Owner()
                        {
                            OwnerId = owner.OwnerId,
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
            return _petRepository.GetByType(type);
        }

        public List<Pet> SortByType(string type)
        {
            throw new System.NotImplementedException();
        }


        public List<Pet> SortByPrice()
        {
            return GetAll().OrderBy(pet => pet.Price).ToList();

        }


        public Pet FindById(int id)
        {
            return _petRepository.GetById(id);
        }
    }
}