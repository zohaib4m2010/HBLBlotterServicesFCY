using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Models
{
    public class SBP_BlotterManualDeals
    {
        public int SNo { get; set; }
        public Nullable<System.DateTime> DealDate { get; set; }
        public Nullable<decimal> InFlow { get; set; }
        public Nullable<decimal> OutFlow { get; set; }
        public Nullable<System.DateTime> CurrentDate { get; set; }
        public string DealStatus { get; set; }
        public string Description { get; set; }
        public string BR { get; set; }

    }
}
