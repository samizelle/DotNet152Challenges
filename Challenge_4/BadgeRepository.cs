using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        List<Badge> _badgeList = new List<Badge>();

        public void AddBadgeToList(Badge badge)
        {
            _badgeList.Add(badge);
        }
        
        public List<Badge> GetBadge()
        {
            return _badgeList;
        }

        public int ParseResponseToInt()
        {
            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);
            return input;
        }

        public void DeleteBadgeID(Badge badge)
        {
            _badgeList.Remove(badge);
        }

    }


}