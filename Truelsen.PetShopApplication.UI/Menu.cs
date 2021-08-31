using System;
using Truelsen.PetShopApplication.Core.IServices;

namespace Truelsen.PetShopApplication.UI
{
    public class Menu
    {
        private IPetService _service;

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

        public Menu(IPetService service)
        {
            _service = service;
        }

        public void Start()
        {
            PrintWelcomeMessage();
            ShowMainMenu();
            StartMenuLoop();
        }

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
                        // SortPetsByType();
                        break;
                    case 7:
                        // ShowCheapestPets();
                        break;
                    default:
                        TryValidInput();
                        break;
                }
                PrintDivider();
                ShowMainMenu();
                
            }
            
        }

        private void SearchPetByType()
        {
            Console.WriteLine("Enter the Type of Pet you want to search for.");
            string choice;
            while ((choice = GetSearchMenuInput()) != 0)
            {
                if (choice == 1)
                {
                    Console.WriteLine("Enter Pet Type to Search for.");
                    var petTypeToSearchFor = Console.ReadLine();
                    _service.Find(petTypeToSearchFor);
                }
                else if (choice == -1)
                {
                    TryValidInput();
                }
            }
            ShowMainMenu();
        }

        private int GetSearchMenuInput()
        {
            var choiceString = Console.ReadLine();
            int choice;
            if (int.TryParse(choiceString, out choice))
            {
                return choice;
            }

            return -1;
        }

        private void TryValidInput()
        {
            Console.WriteLine("Please enter a valid choice.");
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
                _service.Delete(petId);
            }
        }

        private void ShowAllPets()
        {
            Console.WriteLine("All Pets:");
            PrintDivider();
            var pets = _service.GetAll();
            foreach (var pet in pets)
            {
                Console.WriteLine(
                    $"{pet.Id}{pet.Name}, {pet.Birthdate.ToString()}, {pet.Color}, {pet.Price}, {pet.Type.Name}, {pet.SoldDate.ToString()}");
            }
        }

        private void SellPet()
        {
            throw new NotImplementedException();
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

        private void ShowMainMenu()
        {
            for (int i = 0; i < _menuChoices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuChoices[i]}");
            }

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
    }
}