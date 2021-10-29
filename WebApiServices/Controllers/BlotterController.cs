using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterController : ApiController
    {
        // GET:   
        [HttpGet]
        public SBP_WebApiResponse GetAllBlotterList(String BrCode, String DataType, String CurrentDate)
        {
            //String BrCode = "02";
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result>();
                List<DataAccessLayer.SP_SBPBlotter_Result> blotterList = DAL.GetAllBlotterData(BrCode, DataType, CurrentDate);
                List<Models.SP_SBPBlotter_Result> blotter = new List<Models.SP_SBPBlotter_Result>();
                foreach (var item in blotterList)
                {
                    blotter.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotter.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotter.Count > 0)
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = true,
                        Message = "Success",
                        Data = jsonResponse
                    };
                }
                else
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Data not available",
                        Data = ""
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Failed",
                        Data = ex.Message
                    };
                }
                return responseData;
            }

        }

        [HttpGet]
        public SBP_WebApiResponse GetAllBlotterFCYList(String BrCode, int CurrId, String CurrentDate, string NostroBank)
        {
            //String BrCode = "02";
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterFCY<DataAccessLayer.SP_SBPBlotter_FCY_Result, Models.SP_SBPBlotter_FCY_Result> mapObj = new EntityMapperBlotterFCY<DataAccessLayer.SP_SBPBlotter_FCY_Result, Models.SP_SBPBlotter_FCY_Result>();

                List<DataAccessLayer.SP_SBPBlotter_FCY_Result> blotterList = DAL.GetAllBlotterData_FCY(BrCode, CurrId, CurrentDate, NostroBank);
                List<Models.SP_SBPBlotter_FCY_Result> blotter = new List<Models.SP_SBPBlotter_FCY_Result>();
                foreach (var item in blotterList)
                {
                    blotter.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotter.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotter.Count > 0)
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = true,
                        Message = "Success",
                        Data = jsonResponse
                    };
                }
                else
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Data not available",
                        Data = ""
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Failed",
                        Data = ex.Message
                    };
                }
                return responseData;
            }

        }



        // GET:   
        [HttpGet]
        public JsonResult<Models.BlotterSumEmail> GetBlotterSum(String BrCode)
        {

            EntityMapperBlotterEmail<DataAccessLayer.BlotterSumEmail, Models.BlotterSumEmail> mapObj = new EntityMapperBlotterEmail<DataAccessLayer.BlotterSumEmail, Models.BlotterSumEmail>();
            DataAccessLayer.BlotterSumEmail dalEmail = DAL.GetAllBlotterDataSum(BrCode);
            Models.BlotterSumEmail SumForEmail = new Models.BlotterSumEmail();
            SumForEmail = mapObj.Translate(dalEmail);
            return Json<Models.BlotterSumEmail>(SumForEmail);


        }


        // GET:   
        [HttpGet]
        public JsonResult<List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>> GetLatestBlotterDTLReportDayWise(int BR, string StartDate, string EndDate)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            List<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result> dalEmail = DAL.GetLatestBlotterDTLDayWise(BR, StartDate, EndDate);
            List<Models.SP_GETLatestBlotterDTLReportDayWise_Result> SumForEmail = new List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            foreach (var item in dalEmail)
            {
                SumForEmail.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>>(SumForEmail);


        }

        // GET:   
        [HttpGet]
        public JsonResult<Models.SP_GETLatestBlotterDTLReportDayWise_Result> GetLatestBlotterDTLReportForToday(int BR)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result dalEmail = DAL.GetLatestBlotterDTLForToday(BR);
            Models.SP_GETLatestBlotterDTLReportDayWise_Result SumForEmail = new Models.SP_GETLatestBlotterDTLReportDayWise_Result();

            SumForEmail = mapObj.Translate(dalEmail);

            return Json<Models.SP_GETLatestBlotterDTLReportDayWise_Result>(SumForEmail);


        }

        // GET:   
        [HttpGet]
        public JsonResult<Models.SBP_BlotterOpeningBalance> GetLatestOpeningBalaceForToday(int BR, string Date)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GetOpeningBalance_Result, Models.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GetOpeningBalance_Result, Models.SBP_BlotterOpeningBalance>();
            DataAccessLayer.SP_GetOpeningBalance_Result dalEmail = DAL.GetOpeningBalance(BR, Convert.ToDateTime(Date));
            Models.SBP_BlotterOpeningBalance SumForEmail = new Models.SBP_BlotterOpeningBalance();
            SumForEmail = mapObj.Translate(dalEmail);
            return Json<Models.SBP_BlotterOpeningBalance>(SumForEmail);
        }

        [HttpGet]
        public JsonResult<Models.SP_GetFCYOpeningBalance_Result> GetLatestFCYOpeningBalaceForToday(int BR, string Date)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GetFCYOpeningBalance_Result, Models.SP_GetFCYOpeningBalance_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GetFCYOpeningBalance_Result, Models.SP_GetFCYOpeningBalance_Result>();
            DataAccessLayer.SP_GetFCYOpeningBalance_Result dalEmail = DAL.GetFCYOpeningBalance(BR, Convert.ToDateTime(Date));
            Models.SP_GetFCYOpeningBalance_Result SumForEmail = new Models.SP_GetFCYOpeningBalance_Result();
            SumForEmail = mapObj.Translate(dalEmail);
            return Json<Models.SP_GetFCYOpeningBalance_Result>(SumForEmail);
        }


        // GET:   
        [HttpPost]
        public JsonResult<List<Models.SP_GetOPICSManualData_Result>> GetOPICSManualData(GetBlotterMnualDataParam BMDP)
        {

            List<Models.SP_GetOPICSManualData_Result> SumForEmail = new List<Models.SP_GetOPICSManualData_Result>();
            if (BMDP.Recon)
            {
                EntityMapperBlotter<DataAccessLayer.SP_ReconcileOPICSManualData_Result, Models.SP_GetOPICSManualData_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_ReconcileOPICSManualData_Result, Models.SP_GetOPICSManualData_Result>();
                List<DataAccessLayer.SP_ReconcileOPICSManualData_Result> dalEmail = DAL.ReconcileOPICSManualData(BMDP.BR, BMDP.DateFor);
                foreach (var item in dalEmail)
                {
                    SumForEmail.Add(mapObj.Translate(item));
                }
            }
            else
            {
                EntityMapperBlotter<DataAccessLayer.SP_GetOPICSManualData_Result, Models.SP_GetOPICSManualData_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GetOPICSManualData_Result, Models.SP_GetOPICSManualData_Result>();
                List<DataAccessLayer.SP_GetOPICSManualData_Result> dalEmail = DAL.GetOPICSManualData(BMDP.BR, BMDP.DateFor, BMDP.Flag, BMDP.CurId, BMDP.NostroCode);
                foreach (var item in dalEmail)
                {
                    SumForEmail.Add(mapObj.Translate(item));
                }
            }
            return Json<List<Models.SP_GetOPICSManualData_Result>>(SumForEmail);


        }

        #region Added 04-Aug-2021

        // POST:   
        [HttpPost]
        public SBP_WebApiResponse InsertBlotterListLCY(List<Models.BlotterDataColor> BlotterDataLCY)
        {
            bool status = false;
            EntityMapperBlotter<Models.BlotterDataColor, DataAccessLayer.BlotterDataColor> mapObj = new EntityMapperBlotter<Models.BlotterDataColor, DataAccessLayer.BlotterDataColor>();
            DataAccessLayer.BlotterDataColor Obj = new DataAccessLayer.BlotterDataColor();
            for (int i = 0; i < BlotterDataLCY.Count; i++)
            {
                Obj = mapObj.Translate(BlotterDataLCY[i]);
                status = DAL.InsertBlotterDumpDta(Obj);
            }
            return null;
        }

        [HttpPost]
        public SBP_WebApiResponse InsertBlotterListFCY(List<Models.BlotterDataColor> BlotterDataFCY)
        {
            bool status = false;
            EntityMapperBlotter<Models.BlotterDataColor, DataAccessLayer.BlotterDataColor> mapObj = new EntityMapperBlotter<Models.BlotterDataColor, DataAccessLayer.BlotterDataColor>();
            DataAccessLayer.BlotterDataColor Obj = new DataAccessLayer.BlotterDataColor();
            for (int i = 0; i < BlotterDataFCY.Count; i++)
            {
                Obj = mapObj.Translate(BlotterDataFCY[i]);
                status = DAL.InsertBlotterDumpDta(Obj);
            }
            return null;
        }




        [HttpPut]
        public bool Update(Models.SP_GETLatestBlotterDTLReportDayWise_Result blotterCRRDayWise)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                EntityMapperBlotter<Models.SP_GETLatestBlotterDTLReportDayWise_Result, DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result> mapObj = new EntityMapperBlotter<Models.SP_GETLatestBlotterDTLReportDayWise_Result, DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result>();
                DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result CRRObj = new DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result();
                CRRObj = mapObj.Translate(blotterCRRDayWise);
                status = DAL.UpdateCRRReportDayWiseBalance(CRRObj);
            }
            return status;
        }


        [HttpGet]
        public JsonResult<List<Models.SP_GetSBP_CRRReportingFCYCurrWise_Result>> GetLatestBlotterCRRFCYReportCurrencyWise(int BR, int BID, int UserID, string StartDate, string EndDate)
        {

            EntitiyMapperBlotterCRRReportFCY<DataAccessLayer.SP_GetSBP_CRRReportingFCYCurrWise_Result, Models.SP_GetSBP_CRRReportingFCYCurrWise_Result> mapObj = new EntitiyMapperBlotterCRRReportFCY<DataAccessLayer.SP_GetSBP_CRRReportingFCYCurrWise_Result, Models.SP_GetSBP_CRRReportingFCYCurrWise_Result>();
            List<DataAccessLayer.SP_GetSBP_CRRReportingFCYCurrWise_Result> dalEmail = DAL.GetLatestBlotterFCYCRRReportingCurrencyWise(BR, BID, UserID, StartDate, EndDate);
            List<Models.SP_GetSBP_CRRReportingFCYCurrWise_Result> SumForEmail = new List<Models.SP_GetSBP_CRRReportingFCYCurrWise_Result>();
            foreach (var item in dalEmail)
            {
                SumForEmail.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBP_CRRReportingFCYCurrWise_Result>>(SumForEmail);
        }

        #endregion
    }
}
