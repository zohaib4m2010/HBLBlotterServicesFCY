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
    public class BlotterDTController : ApiController
    {

        [HttpGet]
        public JsonResult<List<Models.SP_SBPOpicsSystemDate_Result>> GetBlotterSysDT(String BrCode)
        {
            EntityMapperBlotterCurrentDT<DataAccessLayer.SP_SBPOpicsSystemDate_Result, Models.SP_SBPOpicsSystemDate_Result> mapObj =
            new EntityMapperBlotterCurrentDT<DataAccessLayer.SP_SBPOpicsSystemDate_Result, Models.SP_SBPOpicsSystemDate_Result>();

            List<DataAccessLayer.SP_SBPOpicsSystemDate_Result> blotterListDT = DAL.GetSystemDT(BrCode);
            List<Models.SP_SBPOpicsSystemDate_Result> blotter = new List<Models.SP_SBPOpicsSystemDate_Result>();
            foreach (var item in blotterListDT)
            {
                blotter.Add(mapObj.Translate(item));
            }

            return Json<List<Models.SP_SBPOpicsSystemDate_Result>>(blotter);
        }
        //public SBP_WebApiResponse GetBlotterSysDT(String BrCode)
        //{
        //    var responseData = (dynamic)null;
        //    try
        //    {
        //        EntityMapperBlotterCurrentDT<DataAccessLayer.SP_SBPOpicsSystemDate_Result, Models.SP_SBPOpicsSystemDate_Result> mapObj =
        //       new EntityMapperBlotterCurrentDT<DataAccessLayer.SP_SBPOpicsSystemDate_Result, Models.SP_SBPOpicsSystemDate_Result>();

        //        List<DataAccessLayer.SP_SBPOpicsSystemDate_Result> blotterListDT = DAL.GetSystemDT(BrCode);
        //        List<Models.SP_SBPOpicsSystemDate_Result> blotter = new List<Models.SP_SBPOpicsSystemDate_Result>();
        //        foreach (var item in blotterListDT)
        //        {
        //            blotter.Add(mapObj.Translate(item));
        //        }

        //        HttpResponseMessage response = null;
        //        response = Request.CreateResponse(HttpStatusCode.OK);
        //        var jsonResponse = JsonConvert.SerializeObject(blotter.ToList(), Formatting.Indented);
        //        response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
        //        if (blotter.Count > 0)
        //        {
        //            responseData = new SBP_WebApiResponse
        //            {
        //                Status = true,
        //                Message = "Success",
        //                Data = jsonResponse
        //            };
        //        }
        //        else
        //        {
        //            responseData = new SBP_WebApiResponse
        //            {
        //                Status = false,
        //                Message = "Failed",
        //                Data = ""
        //            };
        //        }
        //        return responseData;
        //    }
        //    catch (Exception ex)
        //    {
        //        responseData = new SBP_WebApiResponse
        //        {
        //            Status = false,
        //            Message = "Failed",
        //            Data = ex.Message
        //        };
        //        return responseData;
        //    }
        //}
    }
}
