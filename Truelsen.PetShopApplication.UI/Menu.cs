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
            "Search by Type",
            "Sell Pet",
            "Buy Pet",
            "Update Pet Details",
            "Sort Pets by Price",
            "$$ 5 Cheapest Pets $$*"
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
                        SearchPetByType();
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
            throw new NotImplementedException();
        }

        private void SortPetsByType()
        {
            Console.WriteLine("Enter the type of pet you want to sort by.");
            var type = Console.ReadLine();
            var results = _petService.SortByType(type);
            foreach (var pet in results)
            {
                Console.WriteLine(
                    $"{pet.Id}{pet.Name}, {pet.Birthdate.ToString()}, {pet.Color}, {pet.Price}, {pet.Type.Name}, {pet.SoldDate.ToString()}");
            }
        }
        
        private void SearchPetByType()
        {
            Console.WriteLine("Enter the Type of Pet you want to search for.");
            List<Pet> result = GetSearchMenuInput();
            foreach (var pet in result)
            {
                Console.WriteLine(
                    $"{pet.Id}{pet.Name}, {pet.Birthdate.ToString()}, {pet.Color}, {pet.Price}, {pet.Type.Name}, {pet.SoldDate.ToString()}");
            }
        }

        private void UpdatePetDetails()
        {
            throw new NotImplementedException();
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
            Console.Write("Enter name of Pet: ");
            var petName = Console.ReadLine();
            Console.Write("Enter Type of Pet: ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter birthdate in the following format: MM/dd/yyyy: ");
            var birthdate = @Console.ReadLine();
            var soldDate = DateTime.Now;
            Console.WriteLine("Enter Color of the Pet: ");
            var color = Console.ReadLine();
            Console.WriteLine("Enter Price of the Pet: ");
            var price = Console.ReadLine();
            if (birthdate == null) return;


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

            var newPet = _petService.Create(pet);
            Console.WriteLine("Pet with the following Properties was sold to the PetShop - ");
            PrintPetDetails(newPet);
        }      

        #endregion

        #region Input

        private int GetSelectedMainMenuChoice()
        {
            var choiceString = Console.ReadLine();

            if (int.TryParse(choiceString, out var selection))
            {
                return selection;
            }

            return -1;
        }       

        private List<Pet> GetSearchMenuInput()
        {
            var searchType = Console.ReadLine();
            List<Pet> results = new List<Pet>(_petService.Find(searchType));
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