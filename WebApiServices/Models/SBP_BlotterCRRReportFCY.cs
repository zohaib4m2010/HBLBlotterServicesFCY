using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterCRRReportFCY
    {
        public int CRRID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> PreWeek5PcrReq { get; set; }
        public Nullable<decimal> PreWeek10PcrReq { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> BR { get; set; }
        public Nullable<int> BID { get; set; }
        public string Flag { get; set; }
    }
}