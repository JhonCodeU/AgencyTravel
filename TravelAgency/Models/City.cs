using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAgency.Models;

namespace TravelAgency.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int Department_id { get; set; }
    }
}