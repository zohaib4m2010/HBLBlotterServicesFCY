using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterOpeningBalance
    {
        public long Id { get; set; }
        public Nullable<decimal> OpenBalActual { get; set; }
        public Nullable<decimal> AdjOpenBal { get; set; }
        public Nullable<System.DateTime> BalDate { get; set; }
        public string DataType { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
    }
}