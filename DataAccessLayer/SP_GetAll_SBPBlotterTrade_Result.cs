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
    
    public partial class SP_GetAll_SBPBlotterTrade_Result
    {
        public long SNo { get; set; }
        public int TTID { get; set; }
        public string TransactionType { get; set; }
        public Nullable<System.DateTime> Trade_Date { get; set; }
        public string TradeCOde { get; set; }
        public Nullable<decimal> Trade_InFlow { get; set; }
        public Nullable<decimal> Trade_OutFLow { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
    }
}