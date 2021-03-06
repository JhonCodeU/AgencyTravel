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
    
    public partial class Travel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Travel()
        {
            this.client_has_Travels = new HashSet<client_has_Travels>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public int originCity_id { get; set; }
        public int arrivalCity_id { get; set; }
        public int briefcase_id { get; set; }
    
        public virtual Briefcase Briefcase { get; set; }
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client_has_Travels> client_has_Travels { get; set; }
    }
}
