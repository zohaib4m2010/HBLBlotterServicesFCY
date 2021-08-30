using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{

    public class BlotterTBOController : ApiController
    {


        [HttpGet]
        public SBP_WebApiResponse GetAllTBOTransactionTitles()
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterTBO<DataAccessLayer.SP_GETAllTBOTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result> mapObj = new EntitiyMapperBlotterTBO<DataAccessLayer.SP_GETAllTBOTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

                List<DataAccessLayer.SP_GETAllTBOTransactionTitles_Result> blotterTBOList = DAL.GetAllTBOTransactionTitles();
                List<Models.SP_GETAllTransactionTitles_Result> blotterTBO = new List<Models.SP_GETAllTransactionTitles_Result>();
                foreach (var item in blotterTBOList)
                {
                    blotterTBO.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterTBO.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterTBO.Count > 0)
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
        public SBP_WebApiResponse GetBlotterTBO(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterTBO<DataAccessLayer.SBP_BlotterTBO, Models.SBP_BlotterTBO> mapObj = new EntitiyMapperBlotterTBO<DataAccessLayer.SBP_BlotterTBO, Models.SBP_BlotterTBO>();
                DataAccessLayer.SBP_BlotterTBO dalBlotterTBO = DAL.GetTBOItem(id);
                Models.SBP_BlotterTBO products = new Models.SBP_BlotterTBO();
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

        [HttpGet]
        public SBP_WebApiResponse GetAllBlotterTBO(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterTBO<DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result, Models.SP_GetAll_SBPBlotterTBO_Result> mapObj = new EntitiyMapperBlotterTBO<DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result, Models.SP_GetAll_SBPBlotterTBO_Result>();
                List<DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result> blotterTBOList = DAL.GetAllBlotterTBO(UserID, BranchID, CurID, BR, DateVal);
                List<Models.SP_GetAll_SBPBlotterTBO_Result> blotterTBO = new List<Models.SP_GetAll_SBPBlotterTBO_Result>();
                foreach (var item in blotterTBOList)
                {
                    blotterTBO.Add(mapObj.Translate(item));
                }

                ////HTTP Json Response
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);

                var jsonresponse = JsonConvert.SerializeObject(blotterTBO.ToList(), Formatting.None);
                response.Content = new StringContent(jsonresponse, Encoding.UTF8, "application/json");

                if (blotterTBO.Count > 0)
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
                    Message = "Record could not be inserted",
                    Data = ex.ToString()
                };
                return responseData;
            }

        }

        [HttpPost]
        public SBP_WebApiResponse InsertTBO(Models.SBP_BlotterTBO blotterTBO)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO> mapObj = new EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO>();
                    DataAccessLayer.SBP_BlotterTBO TBOObj = new DataAccessLayer.SBP_BlotterTBO();
                    TBOObj = mapObj.Translate(blotterTBO);
                    status = DAL.InsertTBO(TBOObj);

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
        public SBP_WebApiResponse UpdateTBO(Models.SBP_BlotterTBO blotterTBO)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO> mapObj = new EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO>();
                    DataAccessLayer.SBP_BlotterTBO TBOObj = new DataAccessLayer.SBP_BlotterTBO();
                    TBOObj = mapObj.Translate(blotterTBO);
                    status = DAL.UpdateTBO(TBOObj);

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
        public SBP_WebApiResponse DeleteTBO(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteTBO(id);

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