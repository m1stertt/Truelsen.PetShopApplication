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
        // private static List<Pet> _petTable = new List<Pet>();
        // private static int _id = 1;
        // private static bool _hasInitializedData = false;

        #region Constructor

        public PetRepositoryMemory()
        {
            if (FakeDB.PetId > 1) return;
            InitializeFakeData();

        }

        #endregion

        #region CRUD

        public Pet Add(Pet pet)
        {
            pet.Id = FakeDB.PetId++;
            FakeDB.Pets.Add(pet);
            return pet;
        }

        public List<Pet> GetAll()
        {
            return FakeDB.Pets;
        }

        public Pet Delete(int petId)
        {
            Pet foundPet = FakeDB.Pets.Find(pet => petId == pet.Id);
            FakeDB.Pets.Remove(foundPet);
            return foundPet;
        }

        public Pet Update(Pet pet)
        {
            Pet foundPet = FakeDB.Pets.Find(petId => petId.Id == pet.Id);
            foundPet.Name = pet.Name;
            foundPet.Type = pet.Type;
            foundPet.Birthdate = pet.Birthdate;
            foundPet.Color = pet.Color;
            foundPet.Price = pet.Price;
            return foundPet;
        } 

        #endregion

        #region DataInitialization

        private void InitializeFakeData()
        {
            
            Pet pet1 = new Pet()
            {
                Id = FakeDB.PetId++,
                Name = "Luffi",
                Birthdate = DateTime.Now,
                Color = "Black",
                Price = 5000,
                Type = new PetType()
                {
                    Name = "Goat"
                },
                SoldDate = DateTime.Now,
                PreviousOwner = new Owner()
                {
                    Id = 1
                }

            };
            FakeDB.Pets.Add(pet1);
            Pet pet2 = new Pet()
            {
                Id = FakeDB.PetId++,
                Name = "Vuffi",
                Birthdate = DateTime.Now,
                Color = "White",
                Price = 150000,
                Type = new PetType()
                {
                    Name = "Goat"
                },
                SoldDate = DateTime.Now,
                PreviousOwner = new Owner()
                {
                Id = 1
            }
                
            };
            FakeDB.Pets.Add(pet2);
            Pet pet3 = new Pet()
            {
                Id = FakeDB.PetId++,
                Name = "Buffi",
                Birthdate = DateTime.Now,
                Color = "Gray",
                Price = 25000,
                Type = new PetType()
                {
                    Name = "Dog"
                },
                SoldDate = DateTime.Now,
                PreviousOwner = new Owner()
                {
                    Id = 2
                }
                
            };
            FakeDB.Pets.Add(pet3);
            Pet pet4 = new Pet()
            {
                Id = FakeDB.PetId++,
                Name = "Muffi",
                Birthdate = DateTime.Now,
                Color = "Black",
                Price = 100000,
                Type = new PetType()
                {
                    Name = "Dog"
                },
                SoldDate = DateTime.Now,
                PreviousOwner = new Owner()
                {
                    Id = 2
                }
                
            };
            FakeDB.Pets.Add(pet4);
        }

        #endregion

    }
}