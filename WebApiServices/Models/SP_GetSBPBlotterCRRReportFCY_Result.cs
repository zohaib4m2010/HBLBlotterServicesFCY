using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_GetSBPBlotterCRRReportFCY_Result
    {
        public int CRRID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> PreWeek5PcrReq { get; set; }
        public Nullable<decimal> PreWeek10PcrReq { get; set; }
    }
}