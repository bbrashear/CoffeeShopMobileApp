using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Espresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private async void TapFacebook_Tapped(object sender, EventArgs e)
        {
             await Launcher.TryOpenAsync(new Uri("https://www.facebook.com/"));
        }

        private async void TapTwitter_Tapped(object sender, EventArgs e)
        {
            await Launcher.TryOpenAsync(new Uri("https://twitter.com/?lang=en"));
        }

        private async void TapInstagram_Tapped(object sender, EventArgs e)
        {
            await Launcher.TryOpenAsync(new Uri("https://www.instagram.com/?hl=en"));
        }

        private async void TapYoutube_Tapped(object sender, EventArgs e)
        {
            await Launcher.TryOpenAsync(new Uri("https://www.youtube.com/"));
        }

        private void TapCall_Tapped(object sender, EventArgs e)
        {
            PhoneDialer.Open("123456789");
        }
    }
}