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
    
    public partial class SP_GetSBPBlotterCRRFINCON_Result
    {
        public long SNo { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> DemandTimeLiablities { get; set; }
        public Nullable<decimal> TimeLiablitiesOverOneYear { get; set; }
        public Nullable<decimal> DemandTimeLiablitiesTotal { get; set; }
        public Nullable<decimal> DepositEligibleFor { get; set; }
        public Nullable<decimal> OtherAmounts { get; set; }
        public Nullable<decimal> TotalEligibleForCRR { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
    }
}
