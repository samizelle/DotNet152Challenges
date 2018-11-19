using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        List<string> _doorList = new List<string>();
        Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();

        public void AddBadgeToList(Badge doors)
        {
            badgeDictionary.Add(doors.BadgeID, doors.DoorAccess);
        }

        public void UpdateExistingBadge(Badge doors)
        {
            badgeDictionary[doors.BadgeID] = doors.DoorAccess;
        }

        public void DeleteBadgeID(int number)
        {
            badgeDictionary.Remove(number);
        }

        public Dictionary<int, List<string>> GetBadge()
        {
            return badgeDictionary;
        }

        public int ParseResponseToInt()
        {
            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);
            return input;
        }
    }
}