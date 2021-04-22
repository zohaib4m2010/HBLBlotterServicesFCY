using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public partial class SBP_BlotterClearing
    {
        public long SNo { get; set; }
        public int TTID { get; set; }
        public Nullable<System.DateTime> Clearing_Date { get; set; }
        public string ClearingCOde { get; set; }
        public Nullable<decimal> Clearing_InFlow { get; set; }
        public Nullable<decimal> AdjClearing_InFlow { get; set; }
        public Nullable<decimal> Clearing_OutFLow { get; set; }
        public Nullable<decimal> AdjClearing_OutFLow { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
    }
}