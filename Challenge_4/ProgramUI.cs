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
        List<Badge> _badgeList;

        // Dictionary<int, Badge> myDictionary = new Dictionary<int, Badge>();

        public void Run()
        {
            //myDictionary.Add ();
            _badgeList = badgeRepo.GetBadge();
            Badge badgeOne = new Badge(1, "A1, C4, D2");
            Badge badgeTwo = new Badge(2, "A1, C2, C3");
            Badge badgeThree = new Badge(3, "A2, B1, B3, D1");

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
                        var newBadge = CreateNewBadge();
                        badgeRepo.AddBadgeToList(newBadge);
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

        public Badge CreateNewBadge()
        {
            Console.WriteLine("Here is the list of current badges:\n");
            ViewBadgeAccessList();
            Console.WriteLine("Enter a new BadgeID:");
            int badgeID = badgeRepo.ParseResponseToInt();
            Console.WriteLine("What doors will this badge have access to? (1, 2, 3)");
            string doorAccess = Console.ReadLine();
            Badge newBadge = new Badge(badgeID, doorAccess);
            return newBadge;
        }

        public void UpdateExistingBadge()
        {

        }

        public void DeleteBadgeID()
        {
            Console.WriteLine("Here is the list of current badges:\n");
            ViewBadgeAccessList();
            Console.WriteLine("Which BadgeID would you like to delete?");
            int badgeID = badgeRepo.ParseResponseToInt();
            foreach(Badge badge in badgeRepo.GetBadge())
            {
                if (badgeID == badge.BadgeID)
                {
                    badgeRepo.DeleteBadgeID(badge);
                    break;
                }
            }
        }

        public void ViewBadgeAccessList()
        {
            foreach (Badge badge in _badgeList)
            {
                Console.WriteLine($"Badge {badge.BadgeID} has access to Doors {badge.DoorAccess}");
            }
        }

    }
}
