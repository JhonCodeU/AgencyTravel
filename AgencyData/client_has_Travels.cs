//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgencyData
{
    using System;
    using System.Collections.Generic;
    
    public partial class client_has_Travels
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public int Travels_id { get; set; }
    
        public virtual client client { get; set; }
        public virtual Travel Travel { get; set; }
    }
}
