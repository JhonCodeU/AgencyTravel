using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyLibrary.Models
{
    public class Client
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
    }
}