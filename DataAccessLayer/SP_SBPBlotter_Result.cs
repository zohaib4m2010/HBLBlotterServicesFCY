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
    
    public partial class SP_SBPBlotter_Result
    {
        public int DealNo { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DealDate { get; set; }
        public Nullable<System.DateTime> ValueDate { get; set; }
        public Nullable<System.DateTime> MaturityDate { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> Inflow { get; set; }
        public Nullable<decimal> Outflow { get; set; }
        public decimal OpeningBalance { get; set; }
        public Nullable<bool> Recon_IsActive { get; set; }
    }
}
