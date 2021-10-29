using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterRECONController : ApiController
    {
        public SBP_WebApiResponse GetConversionRate(int currID, string BR)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterConversionRate<DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result, Models.SP_Get_SBPBlotterConversionRate_Result> mapObj = new EntitiyMapperBlotterConversionRate<DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result, Models.SP_Get_SBPBlotterConversionRate_Result>();
                List<DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result> dalBlotterTBO = DAL.GetConversionRate(currID, BR);
                List<Models.SP_Get_SBPBlotterConversionRate_Result> products = new List<Models.SP_Get_SBPBlotterConversionRate_Result>();
                foreach (var item in dalBlotterTBO)
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

        public SBP_WebApiResponse GetConversionRateRECON(int currID, string BR)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterConversionRate<DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result, Models.SP_Get_SBPBlotterConversionRate_Result> mapObj = new EntitiyMapperBlotterConversionRate<DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result, Models.SP_Get_SBPBlotterConversionRate_Result>();
                DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result dalBlotterCRate = DAL.GetConversionRateRECON(currID, BR);
                Models.SP_Get_SBPBlotterConversionRate_Result products = new Models.SP_Get_SBPBlotterConversionRate_Result();
                products = mapObj.Translate(dalBlotterCRate);
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
        public SBP_WebApiResponse GetblotterRECON(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterRECON<DataAccessLayer.SBP_BlotterRECON, Models.SBP_BlotterRECON> mapObj = new EntitiyMapperBlotterRECON<DataAccessLayer.SBP_BlotterRECON, Models.SBP_BlotterRECON>();
                DataAccessLayer.SBP_BlotterRECON dalblotterRECON = DAL.GetRECONItem(id);
                Models.SBP_BlotterRECON products = new Models.SBP_BlotterRECON();
                products = mapObj.Translate(dalblotterRECON);

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
        public SBP_WebApiResponse GetAllblotterRECON(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterRECON<DataAccessLayer.SP_GetSBPBlotterRECON_Result, Models.SP_GetSBPBlotterRECON_Result> mapObj = new EntitiyMapperBlotterRECON<DataAccessLayer.SP_GetSBPBlotterRECON_Result, Models.SP_GetSBPBlotterRECON_Result>();
                List<DataAccessLayer.SP_GetSBPBlotterRECON_Result> blotterRECONList = DAL.GetAllBlotterRECON(UserID, BranchID, CurID, BR, DateVal);
                List<Models.SP_GetSBPBlotterRECON_Result> blotterRECON = new List<Models.SP_GetSBPBlotterRECON_Result>();
                foreach (var item in blotterRECONList)
                {
                    blotterRECON.Add(mapObj.Translate(item));
                }
                ////HTTP Json Response
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);

                var jsonresponse = JsonConvert.SerializeObject(blotterRECON.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonresponse, Encoding.UTF8, "application/json");

                if (blotterRECON.Count > 0)
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
        public SBP_WebApiResponse InsertRECON(Models.SBP_BlotterRECON blotterRECON)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON> mapObj = new EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON>();
                    DataAccessLayer.SBP_BlotterRECON RECONObj = new DataAccessLayer.SBP_BlotterRECON();
                    RECONObj = mapObj.Translate(blotterRECON);
                    status = DAL.InsertRECON(RECONObj);

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

        [HttpPost]
        public SBP_WebApiResponse BulkInsertRECON(Models.SBP_BlotterRECON blotterRECON)
        {
            bool status = false;
            long NewId = 0;
            Models.SBP_BlotterRECON ReconnewItem = new Models.SBP_BlotterRECON();
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON> mapObj = new EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON>();
                    DataAccessLayer.SBP_BlotterRECON RECONObj = new DataAccessLayer.SBP_BlotterRECON();
                    RECONObj = mapObj.Translate(blotterRECON);
                    NewId = DAL.ReconExcelUpload(RECONObj);
                    if (NewId > 0)
                    {
                        ReconnewItem = blotterRECON;
                        ReconnewItem.ID = NewId;
                        status = true;
                    }

                    HttpResponseMessage response = null;
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    if (status == true)
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = true,
                            Message = "Record is successfully inserted!",
                            Data = ReconnewItem
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
        public SBP_WebApiResponse UpdateRECON(Models.SBP_BlotterRECON blotterRECON)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON> mapObj = new EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON>();
                    DataAccessLayer.SBP_BlotterRECON RECONObj = new DataAccessLayer.SBP_BlotterRECON();
                    RECONObj = mapObj.Translate(blotterRECON);
                    status = DAL.UpdateRECON(RECONObj);

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
        public SBP_WebApiResponse DeleteRECON(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteRECON(id);

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
