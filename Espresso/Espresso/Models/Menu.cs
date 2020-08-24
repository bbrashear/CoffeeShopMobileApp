using System;
using System.Collections.Generic;
using System.Text;

namespace Espresso.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<SubMenu> SubMenus { get; set; }
    }

    public class SubMenu
    {
        public int SubMenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}
