using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterFundsTransfer
    {
        public long SNo { get; set; }
        public string DataType { get; set; }
        public Nullable<System.DateTime> FT_Date { get; set; }
        public string FTCOde { get; set; }
        public Nullable<decimal> FT_InFlow { get; set; }
        public Nullable<decimal> FT_OutFLow { get; set; }
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