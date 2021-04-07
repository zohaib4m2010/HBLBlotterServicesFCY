﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public JsonResult<List<Models.SP_SBPBlotter_Result>> GetAllBlotterList(String BrCode)
        {
            //String BrCode = "02";
            EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result>();

            List<DataAccessLayer.SP_SBPBlotter_Result> blotterList = DAL.GetAllBlotterData(BrCode);
            List<Models.SP_SBPBlotter_Result> blotter = new List<Models.SP_SBPBlotter_Result>();
            foreach (var item in blotterList)
            {
                blotter.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_SBPBlotter_Result>>(blotter);
        }
        // GET:   
        [HttpGet]
        public JsonResult<Models.BlotterSumEmail> GetBlotterSum(String BrCode)        {

            EntityMapperBlotterEmail<DataAccessLayer.BlotterSumEmail, Models.BlotterSumEmail> mapObj = new EntityMapperBlotterEmail<DataAccessLayer.BlotterSumEmail, Models.BlotterSumEmail>();
            DataAccessLayer.BlotterSumEmail dalEmail = DAL.GetAllBlotterDataSum(BrCode);
            Models.BlotterSumEmail SumForEmail = new Models.BlotterSumEmail();
            SumForEmail = mapObj.Translate(dalEmail);
            return Json<Models.BlotterSumEmail>(SumForEmail);

         
        }


        // GET:   
        [HttpGet]
        public JsonResult<List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>> GetLatestBlotterDTLReportDayWise(int BR)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            List<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result> dalEmail = DAL.GetLatestBlotterDTLDayWise(BR);
            List<Models.SP_GETLatestBlotterDTLReportDayWise_Result> SumForEmail = new List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            foreach (var item in dalEmail)
            {
                SumForEmail.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>>(SumForEmail);


        }
    }
}
