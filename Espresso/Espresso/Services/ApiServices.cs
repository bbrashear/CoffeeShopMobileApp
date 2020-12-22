using Espresso.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Espresso.Services
{
    public class ApiServices
    {
        public async Task<List<Menu>> GetMenu()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://blakeespressoapi.azurewebsites.net/api/Menus"); //http get request, async allows the ui to continue functioning
            return JsonConvert.DeserializeObject<List<Menu>>(response); //converts json data into c# object
        }

        public async Task<bool> ReserveTable(Reservation reservation)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(reservation); //turns c# object into json format
            var content = new StringContent(json, Encoding.UTF8, "application/json"); //creates a formatted text appropriate for the http server or client communication
            var response = await client.PostAsync("https://blakeespressoapi.azurewebsites.net/api/Reservations", content); //http post request
            return response.IsSuccessStatusCode;
        }
    }
}
