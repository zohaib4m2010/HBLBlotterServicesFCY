using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Models
{
    public class SBP_BlotterOpening
    {
        public int SNo { get; set; }
        public Nullable<System.DateTime> CurrentDate { get; set; }
        public Nullable<decimal> TodayAmount { get; set; }
        public string BR { get; set; }

    }
}
