using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class ProgramUI
    {
        BadgeRepository badgeRepo = new BadgeRepository();

        public void Run()
        {
            Badge badgeOne = new Badge { BadgeID = 1, DoorAccess = new List<string>() { "A1", "C4", "D2" } };
            Badge badgeTwo = new Badge { BadgeID = 2, DoorAccess = new List<string>() { "A1", "C2", "C3" } };
            Badge badgeThree = new Badge { BadgeID = 3, DoorAccess = new List<string>() { "A2", "B1", "B3", "D1" } };

            badgeRepo.AddBadgeToList(badgeOne);
            badgeRepo.AddBadgeToList(badgeTwo);
            badgeRepo.AddBadgeToList(badgeThree);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("What would you like to do?\n\t" +
                    "1. Create New Badge\n\t" +
                    "2. Update Existing Badge\n\t" +
                    "3. Delete Existing Badge\n\t" +
                    "4. View Badge Access List\n\t" +
                    "5. Exit");

                int input = badgeRepo.ParseResponseToInt();

                switch (input)
                {
                    case 1:
                        CreateNewBadge();
                        break;
                    case 2:
                        UpdateExistingBadge();
                        break;
                    case 3:
                        DeleteBadgeID();
                        break;
                    case 4:
                        ViewBadgeAccessList();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void CreateNewBadge()
        {
            List<string> doors = new List<string>();
            ViewBadgeAccessList();
            Console.WriteLine("Enter a new BadgeID:");
            int badgeID = badgeRepo.ParseResponseToInt();
            Console.WriteLine("What door will this badge have access to?");
            string door = Console.ReadLine();
            doors.Add(door);
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Would you like to add another door to this badge? y/n");
                string response = Console.ReadLine().ToLower();
                if (response == "y")
                {
                    isRunning = true;
                    Console.WriteLine("Enter another door for this badge");
                    string doorTwo = Console.ReadLine();
                    doors.Add(doorTwo);
                }
                else
                {
                    isRunning = false;
                    break;
                }
            }
            Badge newBadge = new Badge(badgeID, doors);
            badgeRepo.AddBadgeToList(newBadge);
        }

        public void UpdateExistingBadge()
        {
            ViewBadgeAccessList();
            Console.WriteLine("Which BadgeID would you like to update?");
            int badgeID = badgeRepo.ParseResponseToInt();
            Dictionary<int, List<string>> badges = badgeRepo.GetBadge();
            List<string> doors = badges[badgeID];
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Would you like to delete a door from this badge? y/n");
                string response = Console.ReadLine().ToLower();
                if (response == "y")
                {
                    Console.WriteLine("Enter the door to delete:");
                    string door = Console.ReadLine();
                    doors.Remove(door);
                }
                else
                {
                    Console.WriteLine("Would you like to add a door to this badge? y/n");
                    string responseThree = Console.ReadLine().ToLower();
                    if (responseThree == "y")
                    {
                        Console.WriteLine("Enter the door to add");
                        string doorThree = Console.ReadLine();
                        doors.Add(doorThree);
                    }
                    else
                    {
                        isRunning = false;
                        break;
                    }
                    Console.WriteLine("Would you like to add another door to this badge? y/n");
                    string responseFour = Console.ReadLine();
                    if (responseFour == "y")
                    {
                        Console.WriteLine("Enter the door to add");
                        string doorFour = Console.ReadLine();
                        doors.Add(doorFour);
                    }
                    else
                    {
                        isRunning = false;
                        break;
                    }
                }
                Console.WriteLine("Would you like to delete another door? y/n");
                string responseTwo = Console.ReadLine().ToLower();
                if (responseTwo == "y")
                {
                    isRunning = true;
                    Console.WriteLine("Enter the door to delete");
                    string doorTwo = Console.ReadLine();
                    doors.Remove(doorTwo);
                }
                else
                {
                    Console.WriteLine("Would you like to add a door to this badge? y/n");
                    string responseThree = Console.ReadLine().ToLower();
                    if (responseThree == "y")
                    {
                        Console.WriteLine("Enter the door to add");
                        string doorThree = Console.ReadLine();
                        doors.Add(doorThree);
                    }
                    else
                    {
                        isRunning = false;
                        break;
                    }
                    Console.WriteLine("Would you like to add another door to this badge? y/n");
                    string responseFour = Console.ReadLine();
                    if (responseFour == "y")
                    {
                        Console.WriteLine("Enter the door to add");
                        string doorFour = Console.ReadLine();
                        doors.Add(doorFour);
                    }
                    else
                    {
                        isRunning = false;
                        break;
                    }
                Badge newBadge = new Badge(badgeID, doors);
                badgeRepo.UpdateExistingBadge(newBadge);
                }
            }
        }

        public void DeleteBadgeID()
        {
            ViewBadgeAccessList();
            Console.WriteLine("Which BadgeID would you like to delete?");
            int badgeID = badgeRepo.ParseResponseToInt();
            badgeRepo.DeleteBadgeID(badgeID);
        }

        public void ViewBadgeAccessList()
        {
            Dictionary<int, List<string>> badges = badgeRepo.GetBadge();
            Console.WriteLine("Here is the list of current badges:\n");
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                Console.WriteLine("BadgeID {0} has access to Doors:", badge.Key);
                foreach (string doors in badge.Value)
                {
                    Console.WriteLine("\t{0}", doors);
                }
            }
        }
    }
}
