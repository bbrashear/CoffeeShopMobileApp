using Espresso.Models;
using Espresso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Espresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
        }

        //on Book Table button click, new Reservation is created where properties are set to their respective entries
        private async void BtnBookTable_Clicked(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation()
            {
                Name = EntName.Text,
                Email = EntEmail.Text,
                Phone = EntPhone.Text,
                TotalPeople = EntTotalPeople.Text,
                Date = DpBookingDate.Date.ToString(),
                Time = TpBookingTime.Time.ToString(),
            };

            //api is called to post the reservation
            ApiServices apiServices = new ApiServices();
            bool response = await apiServices.ReserveTable(reservation);

            //alert notification
            if (response != true)
            {
                await DisplayAlert("Oops", "Something went wrong", "Okay");
            }
            else
            {
                await DisplayAlert("Hi", "Your table has been reserved", "Okay");
            }

        }
    }
}