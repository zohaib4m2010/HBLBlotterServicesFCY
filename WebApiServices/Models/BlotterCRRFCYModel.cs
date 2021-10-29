using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class BlotterCRRFCYModel
    {
        public SBP_BlotterCRRReportFCY CRRReportFCY { get; set; }
        public List<SBP_BlotterCRRReportingCurrencyWise> CRRReportingCurrencyWise { get; set; }
    }
}