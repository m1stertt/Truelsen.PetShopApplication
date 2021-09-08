using System;
using System.Collections.Generic;
using System.Linq;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.UI
{
    public class Menu
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;

        #region MenuStrings

        // List of menu choice strings
        private string[] _menuChoices =
        {
            "Show All Pets",
            "Sort Pets by Price",
            "Sell Pet",
            "Buy Pet",
            "Update Pet Details",
            "Search by Type",
            "$$ 5 Cheapest Pets $$"
        };

        #endregion

        public void Start()
        {
            PrintWelcomeMessage();
            ShowMainMenu();
            StartMenuLoop();
        }

        #region Constructor

        public Menu(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }

        #endregion

        #region StartMenuLoop

        private void StartMenuLoop()
        {
            int choice;
            while ((choice = GetSelectedMainMenuChoice()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        ShowAllPets();
                        break;
                    case 2:
                        SortByPrice();
                        break;
                    case 3:
                        SellPet();
                        break;
                    case 4:
                        BuyPet();
                        break;
                    case 5:
                        UpdatePetDetails();
                        break;
                    case 6:
                        SortPetsByType();
                        break;
                    case 7:
                        ShowCheapestPets();
                        break;
                    default:
                        TryValidInput();
                        break;
                }

                PrintDivider();
                ShowMainMenu();
            }
        }

        #endregion


        private void ShowCheapestPets()
        {
            List<Pet> result = GetPriceSorted();
            for (int i = 0; i < 4; i++)
            {
                PrintPetDetails(result[i]);
            }
        }

        private void SortPetsByType()
        {
            var results = GetTypeSearch();
            Console.WriteLine($"All {results.First().Type.Name}s in database: ");
            foreach (var pet in results)
            {
                Console.WriteLine(
                    $"{pet.Id}{pet.Name}, {pet.Birthdate.ToString()}, {pet.Color}, {pet.Price}, {pet.Type.Name}, {pet.SoldDate.ToString()}");
            }
        }

        private void SortByPrice()
        {
            List<Pet> result = GetPriceSorted();
            foreach (var pet in result)
            {
                PrintPetDetails(pet);
            }
        }

        private List<Pet> GetPriceSorted()
        {
            var results = _petService.SortByPrice();
            return results;
        }

        private void UpdatePetDetails()
        {
            Console.Write("Enter Id of the Pet you want to update: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                Pet pet = new Pet();
                pet = _petService.FindById(id);
                var updatedPet = GetPetDetailsInput();
                pet.Name = updatedPet.Name;
                pet.Type = updatedPet.Type;
                pet.Price = updatedPet.Price;
                pet.Birthdate = updatedPet.Birthdate;
                pet.Color = updatedPet.Color;
                pet.SoldDate = updatedPet.SoldDate;
                _petService.Update(pet);
            }
        }

        private void BuyPet()
        {
            Console.WriteLine("Enter ID of the Pet you want to buy.");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var petId))
            {
                _petService.Delete(petId);
            }
        }

        private void ShowAllPets()
        {
            Console.WriteLine("All Pets:");
            PrintDivider();
            var pets = _petService.GetAll();
            foreach (var pet in pets)
            {
                PrintPetDetails(pet);
            }
        }

        #region SellPet

        private void SellPet()
        {
            var pet = GetPetDetailsInput();

            var newPet = _petService.Create(pet);
            Console.WriteLine("Pet with the following Properties was sold to the PetShop - ");
            PrintPetDetails(newPet);
        }

        #endregion

        #region Input

        private Pet GetPetDetailsInput()
        {
            Console.Write("Enter name of Pet: ");
            var petName = Console.ReadLine();
            while (!InputStringValidation(petName))
            {
                petName = Console.ReadLine();
            }

            Console.Write("Enter Type of Pet: ");
            string type = Console.ReadLine();
            while (!InputStringValidation(type))
            {
                type = Console.ReadLine();
            }

            Console.WriteLine("Enter birthdate in the following format: dd/MM/yyyy: ");
            var birthdate = @Console.ReadLine();
            while (!InputDateValidation(birthdate))
            {
                birthdate = Console.ReadLine();
            }

            Console.WriteLine("Enter Color of the Pet: ");
            var color = Console.ReadLine();
            while (!InputStringValidation(color))
            {
                color = Console.ReadLine();
            }

            Console.WriteLine("Enter Price of the Pet: ");
            var price = Console.ReadLine();
            while (!InputDoubleValidation(price))
            {
                price = Console.ReadLine();
            }

            // Checking if the petType is already available in the repository.
            // If not we will create a new type.
            var petType = new PetType()
            {
                Name = type
            };
            petType = _petTypeService.Find(petType) ?? _petTypeService.Create(petType);

            var pet = new Pet()
            {
                Name = petName,
                Birthdate = Convert.ToDateTime(birthdate),
                Color = color,
                Price = Convert.ToDouble(price),
                Type = petType,
                SoldDate = DateTime.Now
            };
            return pet;
        }

        private bool InputDoubleValidation(string price)
        {
            while (string.IsNullOrEmpty(price) || !double.TryParse(price, out var temp))
            {
                Console.WriteLine("Price can't be empty and has to be a number! Input price once more: ");
                return false;
            }

            return true;
        }

        private bool InputStringValidation(string inputString)
        {
            while (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Name can't be empty! Input pet name once more: ");
                return false;
            }

            return true;
        }

        private bool InputDateValidation(string inputString)
        {
            if (!DateTime.TryParse(inputString, out var temp))
            {
                Console.WriteLine("Date can't be empty or or in wrong format. Try again in the format: dd/MM/yyyy: ");
                return false;
            }

            return true;
        }

        private int GetSelectedMainMenuChoice()
        {
            var choiceString = Console.ReadLine();

            if (int.TryParse(choiceString, out var selection))
            {
                return selection;
            }

            return -1;
        }

        private List<Pet> GetTypeSearch()
        {
            Console.Write("Enter the Type of Pet you want to search for: ");
            var searchType = Console.ReadLine();
            List<Pet> results = new List<Pet>(_petService.SortByType(searchType));
            return results;
        }

        #endregion

        #region Printing

        private void ShowMainMenu()
        {
            for (int i = 0; i < _menuChoices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuChoices[i]}");
            }

            Console.WriteLine("0. To Exit");
            Console.Write("Enter choice: ");
        }

        private void PrintWelcomeMessage()
        {
            PrintDivider();
            Console.WriteLine("Welcome to the PetShop");
            PrintDivider();
            Console.WriteLine("Here you can buy or sell pets!");
            PrintDivider();
            Console.WriteLine("If you Buy a pet it will be removed from the shop.");
            PrintDivider();
            Console.WriteLine("If you Sell a pet it will be added to the shop.");
            PrintDivider();
            Console.WriteLine("Also try some of our other features!");
            PrintDivider();
        }

        private void PrintDivider()
        {
            Console.WriteLine("------------------------------------------------");
        }

        public void PrintPetDetails(Pet pet)
        {
            Console.WriteLine(
                $"Id: {pet.Id}, Name: {pet.Name}, Birthdate: {pet.Birthdate.ToString()}, Color: {pet.Color}," +
                $" Price: {pet.Price}, Pet Type: {pet.Type.Name}, Sold Date: {pet.SoldDate.ToString()}");
        }

        private void TryValidInput()
        {
            Console.WriteLine("Please enter a valid choice.");
        }

        #endregion
    }
}