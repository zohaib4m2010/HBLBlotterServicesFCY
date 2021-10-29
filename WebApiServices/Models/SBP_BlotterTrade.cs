﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public partial class SBP_BlotterTrade
    {
        public long SNo { get; set; }
        public int TTID { get; set; }
        public Nullable<System.DateTime> Trade_Date { get; set; }
        public string TradeCOde { get; set; }
        public Nullable<decimal> Trade_InFlow { get; set; }
        public Nullable<decimal> AdjTrade_InFlow { get; set; }
        public Nullable<decimal> Trade_OutFLow { get; set; }
        public Nullable<decimal> AdjTrade_OutFLow { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
        public string DataType { get; set; }
        public string BankCode { get; set; }
    }
}