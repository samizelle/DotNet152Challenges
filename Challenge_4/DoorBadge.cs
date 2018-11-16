using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class DoorBadge
    {
        public int BadgeID { get; set; }
        public string DoorName { get; set; }

        public DoorBadge(int badgeID, string doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

        public static Dictionary<int, DoorBadge> GetBadgeInfo()
        {

        }
    }
}
