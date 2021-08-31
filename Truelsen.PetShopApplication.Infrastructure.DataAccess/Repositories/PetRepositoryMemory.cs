using System;
using System.Collections.Generic;
using System.ComponentModel;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.DataAccess.Repositories
{
    public class PetRepositoryMemory : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _id = 1;

        public PetRepositoryMemory()
        {
            Pet pet1 = new Pet()
            {
                Id = 1,
                Name = "Vuffi",
                Birthdate = DateTime.Now,
                Color = "Black",
                Price = 100000,
                Type = new PetType()
                {
                    Name = "Goat"
                },
                SoldDate = DateTime.Now
                
            };
            _petTable.Add(pet1);
        }

        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _petTable.Add(pet);
            return pet;
        }

        public List<Pet> GetAll()
        {
            return _petTable;
        }

        public Pet Delete(int petId)
        {
            Pet foundPet = _petTable.Find(pet => petId == pet.Id);
            _petTable.Remove(foundPet);
            return foundPet;
        }

        public Pet Update(Pet pet)
        {
            Pet foundPet = _petTable.Find(petId => petId.Id == pet.Id);
            foundPet = pet;
            return foundPet;
        }
    }
}