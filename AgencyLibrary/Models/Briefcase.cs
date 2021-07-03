﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyLibrary.Models
{
    public class Briefcase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> city_id { get; set; }
    }
}