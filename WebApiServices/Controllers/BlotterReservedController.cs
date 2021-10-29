using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Repository;


namespace WebApiServices.Controllers
{
    public class BlotterReservedController : ApiController
    {
        [HttpGet]
        public SBP_WebApiResponse GetAllblotterReserved(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterReserved<DataAccessLayer.SP_GetSBP_Reserved_Result, Models.SP_GetSBP_Reserved_Result> mapObj = new EntitiyMapperBlotterReserved<DataAccessLayer.SP_GetSBP_Reserved_Result, Models.SP_GetSBP_Reserved_Result>();

                List<DataAccessLayer.SP_GetSBP_Reserved_Result> blotterReservedList = DAL.GetAllBlotterReserved(UserID, BranchID, BR);
                List<Models.SP_GetSBP_Reserved_Result> blotterReserved = new List<Models.SP_GetSBP_Reserved_Result>();
                foreach (var item in blotterReservedList)
                {
                    blotterReserved.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterReserved.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterReserved.Count > 0)
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
                        Message = "Failed",
                        Data = ""
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {

                responseData = new SBP_WebApiResponse
                {
                    Status = false,
                    Message = "Failed",
                    Data = ex.Message
                };
                return responseData;
            }

        }


        [HttpPut]
        public SBP_WebApiResponse UpdateReserved(Models.BlotterSBP_Reserved blotterReserved)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterReserved<Models.BlotterSBP_Reserved, DataAccessLayer.BlotterSBP_Reserved> mapObj = new EntitiyMapperBlotterReserved<Models.BlotterSBP_Reserved, DataAccessLayer.BlotterSBP_Reserved>();
                    DataAccessLayer.BlotterSBP_Reserved ReservedObj = new DataAccessLayer.BlotterSBP_Reserved();
                    ReservedObj = mapObj.Translate(blotterReserved);
                    status = DAL.UpdateReserved(ReservedObj);

                    HttpResponseMessage response = null;
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    if (status == true)
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = true,
                            Message = "Record is successfully updated!",
                            Data = ""
                        };
                    }
                    else
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = false,
                            Message = "Record could not be updated",
                            Data = ""
                        };
                    }
                }
                return responseData;
            }
            catch (Exception ex)
            {
                responseData = new SBP_WebApiResponse
                {
                    Status = false,
                    Message = "Failed",
                    Data = ex.Message
                };
                return responseData;
            }
        }

    }
}
