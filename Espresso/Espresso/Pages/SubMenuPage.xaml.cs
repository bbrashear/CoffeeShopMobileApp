using Espresso.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Menu = Espresso.Models.Menu;

namespace Espresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubMenuPage : ContentPage
    {
        //used to place SubMenus pulled from menu object into collection
        public ObservableCollection<SubMenu> SubMenus;

        //constructor must receive a menu item because it is coming from menu page
        public SubMenuPage(Menu menu)
        {
            InitializeComponent();
            SubMenus = new ObservableCollection<SubMenu>();

            //foreach loop places each submenu item from menu properties into Observable Collection
            foreach (var submenu in menu.SubMenus)
            {
                SubMenus.Add(submenu);
            }
            //assign ObservableCollection to SubMenu ListView
            LvSubMenu.ItemsSource = SubMenus;
        }
    }
}