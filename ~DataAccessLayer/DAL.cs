using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
       
        static BlotterEntities DbContextB;
        static DAL()
        {
           
            DbContextB = new BlotterEntities();

        }
        public static List<SP_SBPBlotter_Result> GetAllBlotterData(String Br)
        {
            var results = DbContextB.SP_SBPBlotter(Br).ToList();
            return results;
        }
        public static BlotterSumEmail GetAllBlotterDataSum(String BrCode)
        {
            var results = DbContextB.SP_SBPBlotter(BrCode);
            decimal TotalAmount=0;
            decimal inAmt1 = 0;
            decimal inAmt2 = 0;
            decimal inAmt3 = 0;
            decimal TInflow = 0;
            decimal TOutFlow = 0;
            BlotterSumEmail Bmail = new BlotterSumEmail();
            foreach (var Amt in results)
            {
                inAmt1 = Convert.ToDecimal(Amt.Inflow);
                inAmt2 = Convert.ToDecimal(Amt.Outflow);
                inAmt3 = Convert.ToDecimal(Amt.OpeningBalance);
                TInflow = TInflow + inAmt1;
                TOutFlow = TOutFlow + inAmt2;
                TotalAmount = TotalAmount + inAmt1 + inAmt2 + inAmt3;                      
            }
            Bmail.Balance = TotalAmount/1000000;
            Bmail.InFlow = TInflow/1000000;
            Bmail.OutFlow = TOutFlow/1000000;
            return Bmail;
        }
        //*****************************************************
        //Manual Deals Producers
        //*****************************************************
        public static List<SBP_BlotterManualDeals> GetAllDeals(String BrCode)
        {
            return DbContextB.SBP_BlotterManualDeals.Where(p=>p.BR== BrCode).ToList();
        }
        public static SBP_BlotterManualDeals GetManualDeal(int ManualDealId)
        {
            return DbContextB.SBP_BlotterManualDeals.Where(p => p.SNo == ManualDealId).FirstOrDefault();
        }
        public static bool InsertManualDeals(SBP_BlotterManualDeals ManualDealsItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterManualDeals.Add(ManualDealsItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false; 
            }
            return status;
        }
        public static bool UpdateManualDeals(SBP_BlotterManualDeals ManualDealsItem)
        {
            bool status;
            try
            {
                SBP_BlotterManualDeals prodItem = DbContextB.SBP_BlotterManualDeals.Where(p => p.SNo == ManualDealsItem.SNo).FirstOrDefault();
                if (prodItem != null)
                {
                   
                    prodItem.Description = ManualDealsItem.Description;           
                    prodItem.DealDate = ManualDealsItem.DealDate;   
                    prodItem.InFlow = ManualDealsItem.InFlow;
                    prodItem.OutFlow = ManualDealsItem.OutFlow;             
                    prodItem.CurrentDate = ManualDealsItem.CurrentDate;
                    prodItem.DealStatus = ManualDealsItem.DealStatus;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteManualDeals(int id)
        {
            bool status;
            try
            {
                SBP_BlotterManualDeals prodItem = DbContextB.SBP_BlotterManualDeals.Where(p => p.SNo == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContextB.SBP_BlotterManualDeals.Remove(prodItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //Setup Producers
        //*****************************************************
        public static List<SBP_BlotterSetup> GetAllSetUpItems()
        {
            return DbContextB.SBP_BlotterSetup.ToList();
        }
        public static SBP_BlotterSetup GetSetUpItem(int SetupId)
        {
            return DbContextB.SBP_BlotterSetup.Where(p => p.SNo == SetupId).FirstOrDefault();
        }
        public static bool InsertSetUp(SBP_BlotterSetup SetupItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterSetup.Add(SetupItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateSetUp(SBP_BlotterSetup SetupItem)
        {
            bool status;
            try
            {
                SBP_BlotterSetup setupItem = DbContextB.SBP_BlotterSetup.Where(p => p.SNo == SetupItem.SNo).FirstOrDefault();
                if (setupItem != null)
                {
                    setupItem.Description = SetupItem.Description;
                    setupItem.status = SetupItem.status;                  
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteSetUp(int id)
        {
            bool status;
            try
            {
                SBP_BlotterSetup setupItem = DbContextB.SBP_BlotterSetup.Where(p => p.SNo == id).FirstOrDefault();
                if (setupItem != null)
                {
                    DbContextB.SBP_BlotterSetup.Remove(setupItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //Opening Deals Producers
        //*****************************************************
        public static List<SBP_BlotterOpening> GetAllOpeningAmount(String BrCode)
        {
            return DbContextB.SBP_BlotterOpening.Where(p=>p.BR== BrCode).ToList();
        }
        public static SBP_BlotterOpening GetOpeningDeal(int Id)
        {
            return DbContextB.SBP_BlotterOpening.Where(p => p.SNo == Id).FirstOrDefault();
        }
        public static bool InsertOpeningDeals(SBP_BlotterOpening OpeningDealsItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterOpening.Add(OpeningDealsItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }
        public static bool UpdateOpeningDeals(SBP_BlotterOpening OpeningDealsItem)
        {
            bool status;
            try
            {
                SBP_BlotterOpening prodItem = DbContextB.SBP_BlotterOpening.Where(p => p.SNo == OpeningDealsItem.SNo).FirstOrDefault();
                if (prodItem != null)
                {

                    prodItem.CurrentDate = OpeningDealsItem.CurrentDate;
                    prodItem.TodayAmount = OpeningDealsItem.TodayAmount;                   
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteOpeningDeals(int id)
        {
            bool status;
            try
            {
                SBP_BlotterOpening prodItem = DbContextB.SBP_BlotterOpening.Where(p => p.SNo == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContextB.SBP_BlotterOpening.Remove(prodItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //System Current Date  Producers
        //*****************************************************
        public static List<SP_SBPOpicsSystemDate_Result> GetSystemDT(String BrCode)
        {
            var results = DbContextB.SP_SBPOpicsSystemDate(BrCode).ToList();
            return results;
        }
        //*****************************************************
        //Manual DTL Producers
        //*****************************************************
        public static List<SBP_BlotterDTL> GetAllDTLDeals(String BrCode)
        {
            return DbContextB.SBP_BlotterDTL.Where(p=> p.BR==BrCode).ToList();
        }
        public static SBP_BlotterDTL GetDTLDeal(int DTLDealId)
        {
            return DbContextB.SBP_BlotterDTL.Where(p => p.SNo == DTLDealId).FirstOrDefault();
        }
        public static bool InsertDTLDeals(SBP_BlotterDTL DTLDealsItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterDTL.Add(DTLDealsItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }
        public static bool UpdateDTLDeals(SBP_BlotterDTL DTLDealsItem)
        {
            bool status;
            try
            {
                SBP_BlotterDTL prodItem = DbContextB.SBP_BlotterDTL.Where(p => p.SNo == DTLDealsItem.SNo).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.DTL_Date = DTLDealsItem.DTL_Date;
                    prodItem.DTL_Code = DTLDealsItem.DTL_Code;
                    prodItem.NO_OF_Days = DTLDealsItem.NO_OF_Days;
                    prodItem.DTL_Amount = DTLDealsItem.DTL_Amount;
                    prodItem.T_User_Id = DTLDealsItem.T_User_Id;
                    prodItem.T_Date = DTLDealsItem.T_Date;
                    prodItem.Flag = DTLDealsItem.Flag;

                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteDTLDeals(int id)
        {
            bool status;
            try
            {
                SBP_BlotterDTL prodItem = DbContextB.SBP_BlotterDTL.Where(p => p.SNo == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContextB.SBP_BlotterDTL.Remove(prodItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //DTL DeskBoard Producers
        //*****************************************************
        public static SBP_BlotterDTLDaysWiseBal GetDTLDeskBoard(String BrCode)
        {
            //return DbContextB.SBP_BlotterDTLDaysWiseBal.ToList();
            var maxID = DbContextB.SBP_BlotterDTLDaysWiseBal.Any() ? DbContextB.SBP_BlotterDTLDaysWiseBal.Max(p => p.Id ) : 0; 
            return DbContextB.SBP_BlotterDTLDaysWiseBal.Where(p => p.Id == maxID && p.BR== BrCode).FirstOrDefault();
        }
        public static bool UpdateWiseBal(SBP_BlotterDTLDaysWiseBal WiseBalItem)
        {
            bool status;
            try
            {
                SBP_BlotterDTLDaysWiseBal prodItem = DbContextB.SBP_BlotterDTLDaysWiseBal.Where(p => p.Id == WiseBalItem.Id).FirstOrDefault();
                if (prodItem != null)
                {
                    //prodItem.Id = WiseBalItem.Id;
                    prodItem.DTL_Days = WiseBalItem.DTL_Days;
                    prodItem.DTL_Date = WiseBalItem.DTL_Date;
                    prodItem.NextDate = WiseBalItem.NextDate;
                    prodItem.DTL_Amount = WiseBalItem.DTL_Amount;
                    prodItem.MinAmount_3P = WiseBalItem.MinAmount_3P;
                    prodItem.MaxAmount_5P = WiseBalItem.MaxAmount_5P;

                    prodItem.Friday_01 = WiseBalItem.Friday_01;
                    prodItem.Date_01 = WiseBalItem.Date_01;
                    prodItem.CashFlow_01 = WiseBalItem.CashFlow_01;
                    prodItem.CashOutFlow_01 = WiseBalItem.CashOutFlow_01;

                    prodItem.Saturday_02 = WiseBalItem.Saturday_02;
                    prodItem.Date_02 = WiseBalItem.Date_02;
                    prodItem.CashFlow_02 = WiseBalItem.CashFlow_02;
                    prodItem.CashOutFlow_02 = WiseBalItem.CashOutFlow_02;

                    prodItem.Sunday_03 = WiseBalItem.Sunday_03;
                    prodItem.Date_03 = WiseBalItem.Date_03;
                    prodItem.CashFlow_03 = WiseBalItem.CashFlow_03;
                    prodItem.CashOutFlow_03 = WiseBalItem.CashOutFlow_03;

                    prodItem.Monday_04 = WiseBalItem.Monday_04;
                    prodItem.Date_04 = WiseBalItem.Date_04;
                    prodItem.CashFlow_04 = WiseBalItem.CashFlow_04;
                    prodItem.CashOutFlow_04 = WiseBalItem.CashOutFlow_04;

                    prodItem.Tuesday_05 = WiseBalItem.Tuesday_05;
                    prodItem.Date_05 = WiseBalItem.Date_05;
                    prodItem.CashFlow_05 = WiseBalItem.CashFlow_05;
                    prodItem.CashOutFlow_05 = WiseBalItem.CashOutFlow_05;

                    prodItem.Wednesday_06 = WiseBalItem.Wednesday_06;
                    prodItem.Date_06 = WiseBalItem.Date_06;
                    prodItem.CashFlow_06 = WiseBalItem.CashFlow_06;
                    prodItem.CashOutFlow_06 = WiseBalItem.CashOutFlow_06;

                    prodItem.Thursday_07 = WiseBalItem.Thursday_07;
                    prodItem.Date_07 = WiseBalItem.Date_07;
                    prodItem.CashFlow_07 = WiseBalItem.CashFlow_07;
                    prodItem.CashOutFlow_07 = WiseBalItem.CashOutFlow_07;

                    prodItem.Friday_08 = WiseBalItem.Friday_08;
                    prodItem.Date_08 = WiseBalItem.Date_08;
                    prodItem.CashFlow_08 = WiseBalItem.CashFlow_08;
                    prodItem.CashOutFlow_08 = WiseBalItem.CashOutFlow_08;

                    prodItem.Saturday_09 = WiseBalItem.Saturday_09;
                    prodItem.Date_09 = WiseBalItem.Date_09;
                    prodItem.CashFlow_09 = WiseBalItem.CashFlow_09;
                    prodItem.CashOutFlow_09 = WiseBalItem.CashOutFlow_09;

                    prodItem.Sunday_10 = WiseBalItem.Sunday_10;
                    prodItem.Date_10 = WiseBalItem.Date_10;
                    prodItem.CashFlow_10 = WiseBalItem.CashFlow_10;
                    prodItem.CashOutFlow_10 = WiseBalItem.CashOutFlow_10;

                    prodItem.Monday_11 = WiseBalItem.Monday_11;
                    prodItem.Date_11 = WiseBalItem.Date_11;
                    prodItem.CashFlow_11 = WiseBalItem.CashFlow_11;
                    prodItem.CashOutFlow_11 = WiseBalItem.CashOutFlow_11;

                    prodItem.Tuesday_12 = WiseBalItem.Tuesday_12;
                    prodItem.Date_12 = WiseBalItem.Date_12;
                    prodItem.CashFlow_12 = WiseBalItem.CashFlow_12;
                    prodItem.CashOutFlow_12 = WiseBalItem.CashOutFlow_12;

                    prodItem.Wednesday_13 = WiseBalItem.Wednesday_13;
                    prodItem.Date_13 = WiseBalItem.Date_13;
                    prodItem.CashFlow_13 = WiseBalItem.CashFlow_13;
                    prodItem.CashOutFlow_13 = WiseBalItem.CashOutFlow_13;

                    prodItem.Thursday_14 = WiseBalItem.Thursday_14;
                    prodItem.Date_14 = WiseBalItem.Date_14;
                    prodItem.CashFlow_14 = WiseBalItem.CashFlow_14;
                    prodItem.CashOutFlow_14 = WiseBalItem.CashOutFlow_14;
                    prodItem.BR = WiseBalItem.BR;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static List<SP_SBPGetLoginInfo_Result> GetBlotterLogin(String userName,String password,String BranchCode)
        {
            var results = DbContextB.SP_SBPGetLoginInfo(userName,password, BranchCode).ToList();
            return results;
        }
        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static bool UpdateRunningBal(String BrCode,DateTime StartDate,DateTime Enddate)
        {
            bool status;
            try
            {
                int i = DbContextB.SP_SBPBlotterRunningBal(BrCode, StartDate, Enddate);                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;

          

         
        }
    }
}
 