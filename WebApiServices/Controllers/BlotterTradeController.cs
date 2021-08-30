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
    public class BlotterTradeController : ApiController
    {
        // GET: BlotterTrade
        [HttpGet]
        public SBP_WebApiResponse GetAllTradeTransactionTitles()
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterTrade<DataAccessLayer.SP_GETAllTradeTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
               mapObj = new EntityMapperBlotterTrade<DataAccessLayer.SP_GETAllTradeTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

                List<DataAccessLayer.SP_GETAllTradeTransactionTitles_Result> blotterTradeList = DAL.GetAllTradeTransactionTitles();
                List<Models.SP_GETAllTransactionTitles_Result> blotterTrade = new List<Models.SP_GETAllTransactionTitles_Result>();
                foreach (var item in blotterTradeList)
                {
                    blotterTrade.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterTrade.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterTrade.Count > 0)
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
        public SBP_WebApiResponse GetBlotterTrade(int id)
        {

            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterTrade<DataAccessLayer.SBP_BlotterTrade, Models.SBP_BlotterTrade>
                    mapObj = new EntityMapperBlotterTrade<DataAccessLayer.SBP_BlotterTrade, Models.SBP_BlotterTrade>();
                DataAccessLayer.SBP_BlotterTrade dalBlotterTrade = DAL.GetTradeItem(id);
                Models.SBP_BlotterTrade products = new Models.SBP_BlotterTrade();
                products = mapObj.Translate(dalBlotterTrade);

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
        public SBP_WebApiResponse GetAllBlotterTrade(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterTrade<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result, Models.SP_GetAll_SBPBlotterTrade_Result> mapObj = new EntityMapperBlotterTrade<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result, Models.SP_GetAll_SBPBlotterTrade_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result> blotterTradeList = DAL.GetAllBlotterTrade(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterTrade_Result> blotterTrade = new List<Models.SP_GetAll_SBPBlotterTrade_Result>();
            foreach (var item in blotterTradeList)
            {
                blotterTrade.Add(mapObj.Translate(item));
            }

            var responseData = (dynamic)null;
            HttpResponseMessage response = null;
            response = Request.CreateResponse(HttpStatusCode.OK);
            var jsonResponse = JsonConvert.SerializeObject(blotterTrade.ToList(), Formatting.Indented);
            response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            if (blotterTrade.Count > 0)
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
        public SBP_WebApiResponse InsertTrade(Models.SBP_BlotterTrade blotterTrade)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade> mapObj = new EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade>();
                    DataAccessLayer.SBP_BlotterTrade TradeObj = new DataAccessLayer.SBP_BlotterTrade();
                    TradeObj = mapObj.Translate(blotterTrade);
                    status = DAL.InsertTrade(TradeObj);

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
        public SBP_WebApiResponse UpdateTrade(Models.SBP_BlotterTrade blotterTrade)
        {

            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade> mapObj = new EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade>();
                    DataAccessLayer.SBP_BlotterTrade TradeObj = new DataAccessLayer.SBP_BlotterTrade();
                    TradeObj = mapObj.Translate(blotterTrade);
                    status = DAL.UpdateTrade(TradeObj);

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
        public SBP_WebApiResponse DeleteTrade(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteTrade(id);

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