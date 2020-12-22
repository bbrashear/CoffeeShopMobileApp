using Espresso.Services;
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
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Menu> Menus;
        public static bool First = true;
        public MenuPage()
        {
            InitializeComponent();
            Menus = new ObservableCollection<Menu>();
        }

        //OnAppearing method is being overridden to use the async and await keywords
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //static boolean field First ensures the api is only called once if the user moves to another
            //tab and switches back to the menu tab
            if (First)
            {
                //calls the GetMenu method from apiServices class and returns the list of menus in a variable
                ApiServices apiServices = new ApiServices();
                var menus = await apiServices.GetMenu();

                //add each menu to the ObservableCollection
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }

                //assign ObservableCollection to Menu ListView
                LvMenu.ItemsSource = Menus;

                //sets BusyIndicator to false after receiving response from database
                BusyIndicator.IsRunning = false;
            }
            First = false;
        }

        private void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //stores selected item in variable, as keyword checks if the selected item is a menu
            var selectedMenu = e.SelectedItem as Menu;

            //if the selectedMenu is not null, object gets passed to SubMenu page
            if (selectedMenu != null)
            {
                Navigation.PushAsync(new SubMenuPage(selectedMenu));
            }

            //resets the selectedMenu's value to null so it is no longer in a "pressed" state
            ((ListView)sender).SelectedItem = null;
        }
    }
}