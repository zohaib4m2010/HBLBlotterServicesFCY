﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterCRD
    {
        public long SNo { get; set; }
        public string BankCode { get; set; }
        public Nullable<System.DateTime> ValueDate { get; set; }
        public Nullable<decimal> CRD_InFlow { get; set; }
        public Nullable<decimal> CRD_OutFlow { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
    }
}