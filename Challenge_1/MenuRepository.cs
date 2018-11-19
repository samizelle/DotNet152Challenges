using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuRepository
    {
        List<Menu> _menuList = new List<Menu>();

        public void AddMenuItemToList(Menu content)
        {
            _menuList.Add(content);
        }

        public List<Menu> GetListItems()
        {
            return _menuList;
        }
            
        public void DeleteMenuItem(Menu content)
        {
            _menuList.Remove(content);
        }
    }
}
