//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public long transaction_id { get; set; }
        public Nullable<long> customer_id { get; set; }
        public Nullable<System.DateTime> transaction_date { get; set; }
        public Nullable<System.DateTime> transaction_type { get; set; }
        public Nullable<double> amount { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
