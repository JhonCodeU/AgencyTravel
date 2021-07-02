using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Client_Has_Travels
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public int Travels_id { get; set; }
    }
}