using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterCRRReportingCurrencyWise
    {
        public int SNo { get; set; }
        public Nullable<int> CRRID { get; set; }
        public string CCY { get; set; }
        public Nullable<int> CurID { get; set; }
        public Nullable<decimal> Deposit { get; set; }
        public Nullable<decimal> CRRBal5PcrReq { get; set; }
        public Nullable<decimal> CRRBal10PcrReq { get; set; }
        public Nullable<decimal> EquivalentUSD { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> BR { get; set; }
        public Nullable<int> BID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Flag { get; set; }
    }
}