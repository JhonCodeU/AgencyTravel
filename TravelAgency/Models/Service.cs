using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
        public string descripcion { get; set; }
        public string image { get; set; }
        public int ServiceType_id { get; set; }
        public Nullable<double> Price { get; set; }
    }
}