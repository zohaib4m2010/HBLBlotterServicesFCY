using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterBreakups
    {
        public long SNo { get; set; }
        public Nullable<decimal> OpeningBalActual { get; set; }
        public Nullable<decimal> AdjOpeningBalActual { get; set; }
        public Nullable<decimal> FoodPayment_inFlow { get; set; }
        public Nullable<decimal> AdjFoodPayment_inFlow { get; set; }
        public Nullable<decimal> HOKRemittance_inFlow { get; set; }
        public Nullable<decimal> AdjHOKRemittance_inFlow { get; set; }
        public Nullable<decimal> ERF_inflow { get; set; }
        public Nullable<decimal> AdjERF_inflow { get; set; }
        public Nullable<decimal> SBPChequeDeposite_inflow { get; set; }
        public Nullable<decimal> AdjSBPChequeDeposite_inflow { get; set; }
        public Nullable<decimal> Miscellaneous_inflow { get; set; }
        public Nullable<decimal> AdjMiscellaneous_inflow { get; set; }
        public Nullable<decimal> CashWithdrawbySBPCheques_outFlow { get; set; }
        public Nullable<decimal> AdjCashWithdrawbySBPCheques_outFlow { get; set; }
        public Nullable<decimal> ERF_outflow { get; set; }
        public Nullable<decimal> AdjERF_outflow { get; set; }
        public Nullable<decimal> DSC_outFlow { get; set; }
        public Nullable<decimal> AdjDSC_outFlow { get; set; }
        public Nullable<decimal> RemitanceToHOK_outFlow { get; set; }
        public Nullable<decimal> AdjRemitanceToHOK_outFlow { get; set; }
        public Nullable<decimal> SBPCheqGivenToOtherBank_outFlow { get; set; }
        public Nullable<decimal> AdjSBPCheqGivenToOtherBank_outFlow { get; set; }
        public Nullable<decimal> Miscellaneous_outflow { get; set; }
        public Nullable<decimal> AdjMiscellaneous_outflow { get; set; }
        public Nullable<decimal> EstimatedCLossingBal { get; set; }
        public Nullable<decimal> AdjEstimatedCLossingBal { get; set; }
        public Nullable<System.DateTime> BreakupDate { get; set; }
        public Nullable<System.DateTime> AdjDate { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
    }
}