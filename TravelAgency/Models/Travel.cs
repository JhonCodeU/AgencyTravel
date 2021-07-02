using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Travel
    {
        public int id { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public int originCity_id { get; set; }
        public int arrivalCity_id { get; set; }
        public int briefcase_id { get; set; }
    }
}