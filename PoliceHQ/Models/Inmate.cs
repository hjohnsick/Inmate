using System;
using System.Collections.Generic;

namespace PoliceHQ.Models
{
    public partial class Inmate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Charges { get; set; }
        public DateTime DateBooked { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public bool? Tattoos { get; set; }
    }
}
