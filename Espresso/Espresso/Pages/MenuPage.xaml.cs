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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiServices apiServices = new ApiServices();
                var menus = await apiServices.GetMenu();
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }

                LvMenu.ItemsSource = Menus;
                BusyIndicator.IsRunning = false;
            }
            First = false;
        }

        private void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenu = e.SelectedItem as Menu;
            if (selectedMenu != null)
            {
                Navigation.PushAsync(new SubMenuPage(selectedMenu));
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}