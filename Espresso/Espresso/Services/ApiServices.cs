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
            var response = await client.GetStringAsync("https://blakeespressoapi.azurewebsites.net/api/Menus");
            return JsonConvert.DeserializeObject<List<Menu>>(response);
        }
    }
}
