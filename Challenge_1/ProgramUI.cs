using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            bool addingItem = true;
            while (addingItem)
            {
                Console.WriteLine("Choose an option:\n\t" +
                    "1 - Add Menu Item\n\t" +
                    "2 - Delete Menu Item\n\t" +
                    "3 - Print Menu List\n\t" +
                    "4 - Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:  //Add Menu Item
                        AddMenuItem();
                        break;
                    case 2:  //Delete Menu Item
                        DeleteMenuItem();
                        break;
                    case 3:  //Print Menu List
                        PrintMenuList();
                        break;
                    case 4: //Exit Menu
                        addingItem = false;
                        Console.WriteLine("Thank you");
                        break;
                    default:  //oops, try again
                        Console.WriteLine("Invalid response, try again");
                        break;
                }
            }
        }

        private void AddMenuItem()
        {
            Menu newContent = new Menu();
            Console.WriteLine("Give this menu item a Meal Number");
            newContent.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What is this meal's name?");
            newContent.MealName = Console.ReadLine();

            Console.WriteLine("Write the Meal Description");
            newContent.MealDescription = Console.ReadLine();

            Console.WriteLine("What ingredients are in this meal?");
            newContent.MealIngredients = Console.ReadLine();

            Console.WriteLine("What is the price for this meal?");
            newContent.MealPrice = decimal.Parse(Console.ReadLine());
            _menuRepo.AddMenuItemToList(newContent);
        }

        private void PrintMenuList()
        {
            //Console.Clear();
            Console.WriteLine("Here is your menu list:");
            foreach (Menu content in _menuRepo.GetListItems())
            {
                Console.WriteLine($"{content.MealNumber} {content.MealName}\n\t" +
                    $"{content.MealDescription}\n\t" +
                    $"{content.MealIngredients}\n\t" +
                    $"{content.MealPrice}\n");
            }
        }

        public void DeleteMenuItem()
        {
            PrintMenuList();
            Console.WriteLine("Which Meal Number would you like to delete?");
            int menuNumber = int.Parse(Console.ReadLine());
            foreach (Menu content in _menuRepo.GetListItems())
            {
                if (menuNumber == content.MealNumber)
                {
                    _menuRepo.DeleteMenuItem(content);
                    break;
                }
            }
        }
    }
}