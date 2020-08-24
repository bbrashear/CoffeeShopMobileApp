using System;
using System.Collections.Generic;
using System.Text;

namespace Espresso.Models
{
    public class Reservation
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TotalPeople { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
