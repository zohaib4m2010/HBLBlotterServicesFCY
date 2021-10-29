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
    public class BlotterOpenBalController : ApiController
    {
        // GET: BlotterOpenBal

        [HttpGet]
        public SBP_WebApiResponse GetBlotterOpenBalById(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterOpenBal<DataAccessLayer.SBP_BlotterOpeningBalance, Models.SBP_BlotterOpeningBalance>
                    mapObj = new EntityMapperBlotterOpenBal<DataAccessLayer.SBP_BlotterOpeningBalance, Models.SBP_BlotterOpeningBalance>();
                DataAccessLayer.SBP_BlotterOpeningBalance dalBlotterOpenBal = DAL.GetOpenBalItem(id);
                Models.SBP_BlotterOpeningBalance products = new Models.SBP_BlotterOpeningBalance();
                products = mapObj.Translate(dalBlotterOpenBal);

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
        public SBP_WebApiResponse GetAllBlotterOpenBal(int UserID, int BranchID, int CurID, int BR, string dateVal)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterOpenBal<DataAccessLayer.SP_GetAllOpeningBalance_Result, Models.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotterOpenBal<DataAccessLayer.SP_GetAllOpeningBalance_Result, Models.SBP_BlotterOpeningBalance>();

                List<DataAccessLayer.SP_GetAllOpeningBalance_Result> blotterOpenBalList = DAL.GetAllBlotterOpenBal(UserID, BranchID, CurID, BR, dateVal);
                List<Models.SBP_BlotterOpeningBalance> blotterOpenBal = new List<Models.SBP_BlotterOpeningBalance>();
                foreach (var item in blotterOpenBalList)
                {
                    blotterOpenBal.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterOpenBal.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterOpenBal.Count > 0)
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
        [HttpPost]
        public SBP_WebApiResponse InsertOpenBal(Models.SBP_BlotterOpeningBalance blotterOpenBal)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance>();
                    DataAccessLayer.SBP_BlotterOpeningBalance OpenBalObj = new DataAccessLayer.SBP_BlotterOpeningBalance();
                    OpenBalObj = mapObj.Translate(blotterOpenBal);
                    status = DAL.InsertOpenBal(OpenBalObj);

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
        public SBP_WebApiResponse UpdateOpenBal(Models.SBP_BlotterOpeningBalance blotterOpenBal)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance>();
                    DataAccessLayer.SBP_BlotterOpeningBalance OpenBalObj = new DataAccessLayer.SBP_BlotterOpeningBalance();
                    OpenBalObj = mapObj.Translate(blotterOpenBal);
                    status = DAL.UpdateOpenBal(OpenBalObj);

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
        public SBP_WebApiResponse DeleteOpenBal(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteOpenBal(id);

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
