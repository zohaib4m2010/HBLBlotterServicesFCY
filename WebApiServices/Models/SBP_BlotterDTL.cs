using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Models
{
    public partial class SBP_BlotterDTL
    {
        public int SNo { get; set; }
        public System.DateTime DTL_Date { get; set; }
        public string DTL_Code { get; set; }
        public int NO_OF_Days { get; set; }
        public double DTL_Amount { get; set; }
        public string T_User_Id { get; set; }
        public System.DateTime T_Date { get; set; }
        public string Flag { get; set; }
        public string BR { get; set; }
    }
}
