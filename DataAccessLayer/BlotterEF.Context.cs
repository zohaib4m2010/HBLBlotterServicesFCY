﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BlotterEntities : DbContext
    {
        public BlotterEntities()
            : base("name=BlotterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SBP_BlotterManualDeals> SBP_BlotterManualDeals { get; set; }
        public virtual DbSet<SBP_BlotterSetup> SBP_BlotterSetup { get; set; }
        public virtual DbSet<SBP_BlotterOpening> SBP_BlotterOpening { get; set; }
        public virtual DbSet<SBP_BlotterDTL> SBP_BlotterDTL { get; set; }
        public virtual DbSet<NostroBank> NostroBanks { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserRoleRelation> UserRoleRelations { get; set; }
        public virtual DbSet<WebPages> WebPages { get; set; }
        public virtual DbSet<UserPageRelation> UserPageRelations { get; set; }
        public virtual DbSet<SBP_BlotterDTLDaysWiseBal> SBP_BlotterDTLDaysWiseBal { get; set; }
        public virtual DbSet<SBP_BlotterCRRReportCalcSetup> SBP_BlotterCRRReportCalcSetup { get; set; }
        public virtual DbSet<SBP_BlotterCRRFINCON> SBP_BlotterCRRFINCON { get; set; }
        public virtual DbSet<SBP_BlotterCRRReportDaysWiseBal> SBP_BlotterCRRReportDaysWiseBal { get; set; }
        public virtual DbSet<SBP_BlotterBreakups> SBP_BlotterBreakups { get; set; }
        public virtual DbSet<SBP_BlotterTBO> SBP_BlotterTBO { get; set; }
        public virtual DbSet<SBP_BlotterClearing> SBP_BlotterClearing { get; set; }
        public virtual DbSet<SBP_BlotterTrade> SBP_BlotterTrade { get; set; }
        public virtual DbSet<SBP_BlotterManualData> SBP_BlotterManualData { get; set; }
        public virtual DbSet<SBP_LoginInfo> SBP_LoginInfo { get; set; }
    
        public virtual ObjectResult<SP_SBPBlotter_Result> SP_SBPBlotter(string br)
        {
            var brParameter = br != null ?
                new ObjectParameter("Br", br) :
                new ObjectParameter("Br", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SBPBlotter_Result>("SP_SBPBlotter", brParameter);
        }
    
        public virtual ObjectResult<SP_SBPOpicsSystemDate_Result> SP_SBPOpicsSystemDate(string brCode)
        {
            var brCodeParameter = brCode != null ?
                new ObjectParameter("BrCode", brCode) :
                new ObjectParameter("BrCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SBPOpicsSystemDate_Result>("SP_SBPOpicsSystemDate", brCodeParameter);
        }
    
        public virtual ObjectResult<SP_GETAllClearingTransactionTitles_Result> SP_GETAllClearingTransactionTitles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GETAllClearingTransactionTitles_Result>("SP_GETAllClearingTransactionTitles");
        }
    
        public virtual ObjectResult<SP_GETAllTBOTransactionTitles_Result> SP_GETAllTBOTransactionTitles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GETAllTBOTransactionTitles_Result>("SP_GETAllTBOTransactionTitles");
        }
    
        public virtual ObjectResult<SP_GETAllTradeTransactionTitles_Result> SP_GETAllTradeTransactionTitles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GETAllTradeTransactionTitles_Result>("SP_GETAllTradeTransactionTitles");
        }
    
        public virtual ObjectResult<SP_GetAllUserPageRelations_Result> SP_GetAllUserPageRelations(Nullable<int> roleid)
        {
            var roleidParameter = roleid.HasValue ?
                new ObjectParameter("Roleid", roleid) :
                new ObjectParameter("Roleid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAllUserPageRelations_Result>("SP_GetAllUserPageRelations", roleidParameter);
        }
    
        public virtual ObjectResult<SP_GetNotListedUserPageRelations_Result> SP_GetNotListedUserPageRelations(Nullable<int> roleid)
        {
            var roleidParameter = roleid.HasValue ?
                new ObjectParameter("Roleid", roleid) :
                new ObjectParameter("Roleid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetNotListedUserPageRelations_Result>("SP_GetNotListedUserPageRelations", roleidParameter);
        }
    
        public virtual ObjectResult<SP_GetUserPageRelationById_Result> SP_GetUserPageRelationById(Nullable<int> uPRID)
        {
            var uPRIDParameter = uPRID.HasValue ?
                new ObjectParameter("UPRID", uPRID) :
                new ObjectParameter("UPRID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetUserPageRelationById_Result>("SP_GetUserPageRelationById", uPRIDParameter);
        }
    
        public virtual int SP_InsertLoginInfo(string userName, string password, string contactNo, string email, Nullable<int> branchID, Nullable<bool> isActive, Nullable<bool> isConventional, Nullable<bool> isislamic, Nullable<System.DateTime> createDate, Nullable<int> uRID)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var contactNoParameter = contactNo != null ?
                new ObjectParameter("ContactNo", contactNo) :
                new ObjectParameter("ContactNo", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            var isConventionalParameter = isConventional.HasValue ?
                new ObjectParameter("isConventional", isConventional) :
                new ObjectParameter("isConventional", typeof(bool));
    
            var isislamicParameter = isislamic.HasValue ?
                new ObjectParameter("isislamic", isislamic) :
                new ObjectParameter("isislamic", typeof(bool));
    
            var createDateParameter = createDate.HasValue ?
                new ObjectParameter("CreateDate", createDate) :
                new ObjectParameter("CreateDate", typeof(System.DateTime));
    
            var uRIDParameter = uRID.HasValue ?
                new ObjectParameter("URID", uRID) :
                new ObjectParameter("URID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InsertLoginInfo", userNameParameter, passwordParameter, contactNoParameter, emailParameter, branchIDParameter, isActiveParameter, isConventionalParameter, isislamicParameter, createDateParameter, uRIDParameter);
        }
    
        public virtual int SP_SBPBlotterRunningBal(string br, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var brParameter = br != null ?
                new ObjectParameter("Br", br) :
                new ObjectParameter("Br", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_SBPBlotterRunningBal", brParameter, startDateParameter, endDateParameter);
        }
    
        public virtual int SP_AddDaysInBlotterReport(Nullable<decimal> dTLValue, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> bR)
        {
            var dTLValueParameter = dTLValue.HasValue ?
                new ObjectParameter("DTLValue", dTLValue) :
                new ObjectParameter("DTLValue", typeof(decimal));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_AddDaysInBlotterReport", dTLValueParameter, startDateParameter, endDateParameter, bRParameter);
        }
    
        public virtual int SP_UpdateDaysInBlotterReport(Nullable<decimal> dTLValue, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> bR)
        {
            var dTLValueParameter = dTLValue.HasValue ?
                new ObjectParameter("DTLValue", dTLValue) :
                new ObjectParameter("DTLValue", typeof(decimal));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateDaysInBlotterReport", dTLValueParameter, startDateParameter, endDateParameter, bRParameter);
        }
    
        public virtual ObjectResult<SP_GetSBPBlotterCRRFINCON_Result> SP_GetSBPBlotterCRRFINCON(Nullable<int> userID, Nullable<int> branchID, Nullable<int> curID, Nullable<int> bR)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            var curIDParameter = curID.HasValue ?
                new ObjectParameter("CurID", curID) :
                new ObjectParameter("CurID", typeof(int));
    
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetSBPBlotterCRRFINCON_Result>("SP_GetSBPBlotterCRRFINCON", userIDParameter, branchIDParameter, curIDParameter, bRParameter);
        }
    
        public virtual ObjectResult<SP_GETLatestBlotterDTLReportDayWise_Result> SP_GETLatestBlotterDTLReportDayWise(Nullable<int> bR)
        {
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GETLatestBlotterDTLReportDayWise_Result>("SP_GETLatestBlotterDTLReportDayWise", bRParameter);
        }
    
        public virtual ObjectResult<SP_GetLatestBreakup_Result> SP_GetLatestBreakup(Nullable<int> userID, Nullable<int> branchID, Nullable<int> curID, Nullable<int> bR)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            var curIDParameter = curID.HasValue ?
                new ObjectParameter("CurID", curID) :
                new ObjectParameter("CurID", typeof(int));
    
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetLatestBreakup_Result>("SP_GetLatestBreakup", userIDParameter, branchIDParameter, curIDParameter, bRParameter);
        }
    
        public virtual ObjectResult<SP_GetAll_SBPBlotterTBO_Result> SP_GetAll_SBPBlotterTBO(Nullable<int> userID, Nullable<int> branchID, Nullable<int> curID, Nullable<int> bR)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            var curIDParameter = curID.HasValue ?
                new ObjectParameter("CurID", curID) :
                new ObjectParameter("CurID", typeof(int));
    
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAll_SBPBlotterTBO_Result>("SP_GetAll_SBPBlotterTBO", userIDParameter, branchIDParameter, curIDParameter, bRParameter);
        }
    
        public virtual ObjectResult<SP_GetAll_SBPBlotterClearing_Result> SP_GetAll_SBPBlotterClearing(Nullable<int> userID, Nullable<int> branchID, Nullable<int> curID, Nullable<int> bR)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            var curIDParameter = curID.HasValue ?
                new ObjectParameter("CurID", curID) :
                new ObjectParameter("CurID", typeof(int));
    
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAll_SBPBlotterClearing_Result>("SP_GetAll_SBPBlotterClearing", userIDParameter, branchIDParameter, curIDParameter, bRParameter);
        }
    
        public virtual ObjectResult<SP_GetAll_SBPBlotterTrade_Result> SP_GetAll_SBPBlotterTrade(Nullable<int> userID, Nullable<int> branchID, Nullable<int> curID, Nullable<int> bR)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            var curIDParameter = curID.HasValue ?
                new ObjectParameter("CurID", curID) :
                new ObjectParameter("CurID", typeof(int));
    
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAll_SBPBlotterTrade_Result>("SP_GetAll_SBPBlotterTrade", userIDParameter, branchIDParameter, curIDParameter, bRParameter);
        }
    
        public virtual ObjectResult<SP_GetOPICSManualData_Result> SP_GetOPICSManualData(Nullable<int> bR, Nullable<System.DateTime> date)
        {
            var bRParameter = bR.HasValue ?
                new ObjectParameter("BR", bR) :
                new ObjectParameter("BR", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetOPICSManualData_Result>("SP_GetOPICSManualData", bRParameter, dateParameter);
        }
    
        public virtual ObjectResult<SP_SBPGetLoginInfo_Result> SP_SBPGetLoginInfo(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SBPGetLoginInfo_Result>("SP_SBPGetLoginInfo", userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<SP_SBPGetLoginInfoById_Result> SP_SBPGetLoginInfoById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SBPGetLoginInfoById_Result>("SP_SBPGetLoginInfoById", idParameter);
        }
    
        public virtual ObjectResult<sp_GetAllUsers_Result> sp_GetAllUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetAllUsers_Result>("sp_GetAllUsers");
        }
    
        public virtual ObjectResult<sp_GetUserById_Result> sp_GetUserById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUserById_Result>("sp_GetUserById", idParameter);
        }
    }
}
