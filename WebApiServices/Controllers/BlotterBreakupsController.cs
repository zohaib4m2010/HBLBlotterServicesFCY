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
    public class BlotterBreakupsController : ApiController
    {
        // GET: BlotterBreakups

        [HttpGet]
        public SBP_WebApiResponse GetBlotterBreakups(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterBreakups<DataAccessLayer.SBP_BlotterBreakups, Models.SBP_BlotterBreakups> mapObj = new EntityMapperBlotterBreakups<DataAccessLayer.SBP_BlotterBreakups, Models.SBP_BlotterBreakups>();
                DataAccessLayer.SBP_BlotterBreakups dalBlotterBreakups = DAL.GetBlotterBreakups(id);
                Models.SBP_BlotterBreakups products = new Models.SBP_BlotterBreakups();
                products = mapObj.Translate(dalBlotterBreakups);

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
        public SBP_WebApiResponse GetAllBlotterBreakups(int UserID, int BranchID, int CurID, int BR)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterBreakups<DataAccessLayer.SP_GetLatestBreakup_Result, Models.SP_GetLatestBreakup_Result> mapObj = new EntityMapperBlotterBreakups<DataAccessLayer.SP_GetLatestBreakup_Result, Models.SP_GetLatestBreakup_Result>();

                DataAccessLayer.SP_GetLatestBreakup_Result SBP_BlotterBreakupsList = DAL.GetAllBlotterBreakups(UserID, BranchID, CurID, BR);
                Models.SP_GetLatestBreakup_Result blotterSBP_BlotterBreakups = new Models.SP_GetLatestBreakup_Result();
                //foreach (var item in SBP_BlotterBreakupsList)
                //{
                blotterSBP_BlotterBreakups = mapObj.Translate(SBP_BlotterBreakupsList);
                //}

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);

                var jsonresponse = JsonConvert.SerializeObject(blotterSBP_BlotterBreakups, Formatting.Indented);
                response.Content = new StringContent(jsonresponse, Encoding.UTF8, "application/json");

                if (blotterSBP_BlotterBreakups != null)
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = true,
                        Message = "Success",
                        Data = jsonresponse
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
        [HttpPost]
        public SBP_WebApiResponse InsertBlotterBreakups(Models.SBP_BlotterBreakups item)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups> mapObj = new EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups>();
                    DataAccessLayer.SBP_BlotterBreakups SBP_BlotterBreakupsObj = new DataAccessLayer.SBP_BlotterBreakups();
                    SBP_BlotterBreakupsObj = mapObj.Translate(item);
                    status = DAL.InsertBlotterBreakups(SBP_BlotterBreakupsObj);

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
        public SBP_WebApiResponse UpdateBlotterBreakups(Models.SBP_BlotterBreakups item)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups> mapObj = new EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups>();
                    DataAccessLayer.SBP_BlotterBreakups SBP_BlotterBreakupsObj = new DataAccessLayer.SBP_BlotterBreakups();
                    SBP_BlotterBreakupsObj = mapObj.Translate(item);
                    status = DAL.UpdateBlotterBreakups(SBP_BlotterBreakupsObj);

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
        public SBP_WebApiResponse DeleteBlotterBreakups(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteBlotterBreakups(id);

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