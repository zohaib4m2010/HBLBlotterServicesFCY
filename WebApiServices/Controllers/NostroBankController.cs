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
    public class NostroBankController : ApiController
    {
        // GET: NostroBank

        [HttpGet]
        public SBP_WebApiResponse GetNostroBank(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperNostroBank<DataAccessLayer.NostroBank, Models.NostroBank> mapObj = new EntityMapperNostroBank<DataAccessLayer.NostroBank, Models.NostroBank>();
                DataAccessLayer.NostroBank dalBlotterTBO = DAL.GetNostroBank(id);
                Models.NostroBank products = new Models.NostroBank();
                products = mapObj.Translate(dalBlotterTBO);

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

        #region
        [HttpGet]
        public SBP_WebApiResponse GetNostroBankFromOpicsDDL(int currId, String BRCode)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperNostroBank<DataAccessLayer.SP_GetNostroBankFromOPICS_Result, Models.SP_GetNostroBankFromOPICS_Result> mapObj = new EntityMapperNostroBank<DataAccessLayer.SP_GetNostroBankFromOPICS_Result, Models.SP_GetNostroBankFromOPICS_Result>();
                List<DataAccessLayer.SP_GetNostroBankFromOPICS_Result> dalBlotterNostroBank = DAL.GetNostroBankDDL(currId, BRCode);
                List<Models.SP_GetNostroBankFromOPICS_Result> products = new List<Models.SP_GetNostroBankFromOPICS_Result>();
                foreach (var item in dalBlotterNostroBank)
                {
                    products.Add(mapObj.Translate(item));
                }

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
        #endregion

        [HttpGet]
        public SBP_WebApiResponse GetAllNostroBank(int currId)
        {
            EntityMapperNostroBank<DataAccessLayer.SP_GetAllNostroBankList_Result, Models.NostroBank> mapObj = new EntityMapperNostroBank<DataAccessLayer.SP_GetAllNostroBankList_Result, Models.NostroBank>();

            List<DataAccessLayer.SP_GetAllNostroBankList_Result> NostroBankList = DAL.GetAllNostroBankList(currId);
            List<Models.NostroBank> blotterNostroBank = new List<Models.NostroBank>();
            foreach (var item in NostroBankList)
            {
                blotterNostroBank.Add(mapObj.Translate(item));
            }

            var responseData = (dynamic)null;
            HttpResponseMessage response = null;
            response = Request.CreateResponse(HttpStatusCode.OK);
            var jsonResponse = JsonConvert.SerializeObject(blotterNostroBank.ToList(), Formatting.Indented);
            response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            if (blotterNostroBank.Count > 0)
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
        public SBP_WebApiResponse InsertNostroBank(Models.NostroBank item)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank> mapObj = new EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank>();
                    DataAccessLayer.NostroBank NostroBankObj = new DataAccessLayer.NostroBank();
                    NostroBankObj = mapObj.Translate(item);
                    status = DAL.InsertNostroBank(NostroBankObj);

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
        public SBP_WebApiResponse UpdateNostroBank(Models.NostroBank item)
        {

            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank> mapObj = new EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank>();
                    DataAccessLayer.NostroBank NostroBankObj = new DataAccessLayer.NostroBank();
                    NostroBankObj = mapObj.Translate(item);
                    status = DAL.UpdateNostroBank(NostroBankObj);

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
        public SBP_WebApiResponse DeleteNostroBank(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteNostroBank(id);

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