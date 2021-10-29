using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterImportExport
    {
        public int SNo { get; set; }
        public string BlotterType { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string BankCode { get; set; }
        public Nullable<int> CurId { get; set; }
        public string Branch { get; set; }
        public string Customer { get; set; }
        public Nullable<decimal> Inflow { get; set; }
        public Nullable<int> AgainstCurId { get; set; }
        public string AgainstBankCode { get; set; }
        public Nullable<decimal> Outflow { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Flag { get; set; }
        public Nullable<int> BID { get; set; }
        public Nullable<int> BR { get; set; }
        public Nullable<int> UserId { get; set; }
    }
}