//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_interbank_placement_borrow
    {
        public string dealno { get; set; }
        public Nullable<System.DateTime> dealdate { get; set; }
        public Nullable<System.DateTime> vdate { get; set; }
        public Nullable<System.DateTime> mdate { get; set; }
        public Nullable<int> Duration { get; set; }
        public string product { get; set; }
        public string prodtype { get; set; }
        public string sn { get; set; }
        public string ccy { get; set; }
        public Nullable<decimal> ccyamt { get; set; }
        public Nullable<decimal> intrate { get; set; }
        public string dealsrce { get; set; }
        public string br { get; set; }
    }
}