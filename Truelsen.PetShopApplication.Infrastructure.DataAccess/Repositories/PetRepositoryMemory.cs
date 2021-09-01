using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.DataAccess.Repositories
{
    public class PetRepositoryMemory : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _id = 1;
        private static bool _hasInitializedData = false;

        #region Constructor

        public PetRepositoryMemory()
        {
            if (!_hasInitializedData)
            {
                InitializeFakeData();
                _hasInitializedData = true;
            }

        }

        #endregion

        #region CRUD

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

        #endregion

        #region DataInitialization

        private void InitializeFakeData()
        {
            Pet pet1 = new Pet()
            {
                Id = _id++,
                Name = "Luffi",
                Birthdate = DateTime.Now,
                Color = "Black",
                Price = 5000,
                Type = new PetType()
                {
                    Name = "Goat"
                },
                SoldDate = DateTime.Now
                
            };
            _petTable.Add(pet1);
            Pet pet2 = new Pet()
            {
                Id = _id++,
                Name = "Vuffi",
                Birthdate = DateTime.Now,
                Color = "White",
                Price = 150000,
                Type = new PetType()
                {
                    Name = "Goat"
                },
                SoldDate = DateTime.Now
                
            };
            _petTable.Add(pet1);
            Pet pet3 = new Pet()
            {
                Id = _id++,
                Name = "Buffi",
                Birthdate = DateTime.Now,
                Color = "Gray",
                Price = 25000,
                Type = new PetType()
                {
                    Name = "Dog"
                },
                SoldDate = DateTime.Now
                
            };
            _petTable.Add(pet1);
            Pet pet4 = new Pet()
            {
                Id = _id++,
                Name = "Muffi",
                Birthdate = DateTime.Now,
                Color = "Black",
                Price = 100000,
                Type = new PetType()
                {
                    Name = "Dog"
                },
                SoldDate = DateTime.Now
                
            };
            _petTable.Add(pet1);
        }

        #endregion

    }
}