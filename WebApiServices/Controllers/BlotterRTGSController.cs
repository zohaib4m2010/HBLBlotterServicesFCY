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
    public class BlotterRTGSController : ApiController
    {
        // GET: BlotterRTGS
        [HttpGet]
        public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllRTGSTransactionTitles()
        {
            EntityMapperBlotterRTGS<DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
                mapObj = new EntityMapperBlotterRTGS<DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            List<DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result> blotterRTGSList = DAL.GetAllRTGSTransactionTitles();
            List<Models.SP_GETAllTransactionTitles_Result> blotterRTGS = new List<Models.SP_GETAllTransactionTitles_Result>();
            foreach (var item in blotterRTGSList)
            {
                blotterRTGS.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterRTGS);
        }

        [HttpGet]
        public SBP_WebApiResponse GetBlotterRTGS(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterRTGS<DataAccessLayer.SBP_BlotterRTGS, Models.SBP_BlotterRTGS> mapObj = new EntityMapperBlotterRTGS<DataAccessLayer.SBP_BlotterRTGS, Models.SBP_BlotterRTGS>();
                DataAccessLayer.SBP_BlotterRTGS dalBlotterRTGS = DAL.GetRTGSItem(id);
                Models.SBP_BlotterRTGS products = new Models.SBP_BlotterRTGS();
                products = mapObj.Translate(dalBlotterRTGS);

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(products, Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (products != null)
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


        [HttpGet]
        public SBP_WebApiResponse GetAllBlotterRTGS(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterRTGS<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result, Models.SP_GetAll_SBPBlotterRTGS_Result> mapObj = new EntityMapperBlotterRTGS<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result, Models.SP_GetAll_SBPBlotterRTGS_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result> blotterRTGSList = DAL.GetAllBlotterRTGS(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterRTGS_Result> blotterRTGS = new List<Models.SP_GetAll_SBPBlotterRTGS_Result>();
            foreach (var item in blotterRTGSList)
            {
                blotterRTGS.Add(mapObj.Translate(item));
            }
            var responseData = (dynamic)null;
            HttpResponseMessage response = null;
            response = Request.CreateResponse(HttpStatusCode.OK);
            var jsonResponse = JsonConvert.SerializeObject(blotterRTGS.ToList(), Formatting.Indented);
            response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            if (blotterRTGS.Count > 0)
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


        [HttpPost]
        public SBP_WebApiResponse InsertRTGS(Models.SBP_BlotterRTGS blotterRTGS)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {

                    EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS> mapObj = new EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS>();
                    DataAccessLayer.SBP_BlotterRTGS RTGSObj = new DataAccessLayer.SBP_BlotterRTGS();
                    RTGSObj = mapObj.Translate(blotterRTGS);
                    status = DAL.InsertRTGS(RTGSObj);

                    HttpResponseMessage response = null;
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    if (status == true)
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = true,
                            Message = "Record is successfully inserted!",
                            Data = ""
                        };
                    }
                    else
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = false,
                            Message = "Record could not be inserted",
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
                    Message = "Record could not be inserted",
                    Data = ex.ToString()
                };
                return responseData;
            }
        }

        [HttpPut]
        public SBP_WebApiResponse UpdateRTGS(Models.SBP_BlotterRTGS blotterRTGS)
        {


            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS> mapObj = new EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS>();
                    DataAccessLayer.SBP_BlotterRTGS RTGSObj = new DataAccessLayer.SBP_BlotterRTGS();
                    RTGSObj = mapObj.Translate(blotterRTGS);
                    status = DAL.UpdateRTGS(RTGSObj);

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
                    Message = "Record could not be updated",
                    Data = ex.ToString()
                };
                return responseData;
            }
        }

        [HttpDelete]
        public SBP_WebApiResponse DeleteRTGS(int id)
        {

            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteRTGS(id);

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                if (status == true)
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = true,
                        Message = "Record is successfully deleted!",
                        Data = ""
                    };
                }
                else
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Record could not be deleted",
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
                    Message = "Record could not be deleted",
                    Data = ex.ToString()
                };
                return responseData;
            }
        }
    }
}
