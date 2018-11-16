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

        public List<Badge> GetBadges()
        {
            return _badgeList;
        }
    }


}