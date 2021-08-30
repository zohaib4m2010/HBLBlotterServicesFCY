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
    public class BlotterClearingController : ApiController
    {
        // GET: BlotterClearing
        //[HttpGet]
        //public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllClearingTransactionTitles()
        //{
        //    EntityMapperBlotterClearing<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
        //        mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

        //    List<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result> blotterClearingList = DAL.GetAllClearingTransactionTitles();
        //    List<Models.SP_GETAllTransactionTitles_Result> blotterClearing = new List<Models.SP_GETAllTransactionTitles_Result>();
        //    foreach (var item in blotterClearingList)
        //    {
        //        blotterClearing.Add(mapObj.Translate(item));
        //    }
        //    return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterClearing);
        //}

        //[HttpGet]
        //public JsonResult<Models.SBP_BlotterClearing> GetBlotterClearing(int id)
        //{
        //    EntityMapperBlotterClearing<DataAccessLayer.SBP_BlotterClearing, Models.SBP_BlotterClearing> 
        //        mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SBP_BlotterClearing, Models.SBP_BlotterClearing>();
        //    DataAccessLayer.SBP_BlotterClearing dalBlotterClearing = DAL.GetClearingItem(id);
        //    Models.SBP_BlotterClearing products = new Models.SBP_BlotterClearing();
        //    products = mapObj.Translate(dalBlotterClearing);
        //    return Json<Models.SBP_BlotterClearing>(products);
        //}

        //[HttpGet]
        //public JsonResult<List<Models.SP_GetAll_SBPBlotterClearing_Result>> GetAllBlotterClearing(int UserID, int BranchID, int CurID,int BR)
        //{
        //    EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result, Models.SP_GetAll_SBPBlotterClearing_Result> mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result, Models.SP_GetAll_SBPBlotterClearing_Result>();

        //    List<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result> blotterClearingList = DAL.GetAllBlotterClearing(UserID,BranchID,CurID,BR);
        //    List<Models.SP_GetAll_SBPBlotterClearing_Result> blotterClearing = new List<Models.SP_GetAll_SBPBlotterClearing_Result>();
        //    foreach (var item in blotterClearingList)
        //    {
        //        blotterClearing.Add(mapObj.Translate(item));
        //    }
        //    return Json<List<Models.SP_GetAll_SBPBlotterClearing_Result>>(blotterClearing);
        //}

        //[HttpPost]
        //public bool InsertClearing(Models.SBP_BlotterClearing blotterClearing)
        //{
        //    bool status = false;
        //    if (ModelState.IsValid)
        //    {
        //        EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing> mapObj = new EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing>();
        //        DataAccessLayer.SBP_BlotterClearing ClearingObj = new DataAccessLayer.SBP_BlotterClearing();
        //        ClearingObj = mapObj.Translate(blotterClearing);
        //        status = DAL.InsertClearing(ClearingObj);
        //    }
        //    return status;

        //}


        //[HttpPut]
        //public bool UpdateClearing(Models.SBP_BlotterClearing blotterClearing)
        //{
        //    bool status = false;
        //    if (ModelState.IsValid)
        //    {
        //        EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing> mapObj = new EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing>();
        //        DataAccessLayer.SBP_BlotterClearing ClearingObj = new DataAccessLayer.SBP_BlotterClearing();
        //        ClearingObj = mapObj.Translate(blotterClearing);
        //        status = DAL.UpdateClearing(ClearingObj);
        //    }
        //    return status;

        //}

        //[HttpDelete]
        //public bool DeleteClearing(int id)
        //{
        //    var status = DAL.DeleteClearing(id);
        //    return status;
        //}
        [HttpGet]
        public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllClearingTransactionTitles()
        {
            EntityMapperBlotterClearing<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
                mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            List<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result> blotterClearingList = DAL.GetAllClearingTransactionTitles();
            List<Models.SP_GETAllTransactionTitles_Result> blotterClearing = new List<Models.SP_GETAllTransactionTitles_Result>();
            foreach (var item in blotterClearingList)
            {
                blotterClearing.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterClearing);
        }

        [HttpGet]
        public SBP_WebApiResponse GetBlotterClearing(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntityMapperBlotterClearing<DataAccessLayer.SBP_BlotterClearing, Models.SBP_BlotterClearing>
                               mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SBP_BlotterClearing, Models.SBP_BlotterClearing>();
                DataAccessLayer.SBP_BlotterClearing dalBlotterClearing = DAL.GetClearingItem(id);
                Models.SBP_BlotterClearing products = new Models.SBP_BlotterClearing();
                products = mapObj.Translate(dalBlotterClearing);

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
        public SBP_WebApiResponse GetAllBlotterClearing(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result, Models.SP_GetAll_SBPBlotterClearing_Result> mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result, Models.SP_GetAll_SBPBlotterClearing_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result> blotterClearingList = DAL.GetAllBlotterClearing(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterClearing_Result> blotterClearing = new List<Models.SP_GetAll_SBPBlotterClearing_Result>();
            foreach (var item in blotterClearingList)
            {
                blotterClearing.Add(mapObj.Translate(item));
            }

            var responseData = (dynamic)null;
            HttpResponseMessage response = null;
            response = Request.CreateResponse(HttpStatusCode.OK);
            var jsonResponse = JsonConvert.SerializeObject(blotterClearing.ToList(), Formatting.Indented);
            response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            if (blotterClearing.Count > 0)
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
        public SBP_WebApiResponse InsertClearing(Models.SBP_BlotterClearing blotterClearing)
        {
            bool status = false;
            var responseData = (dynamic)null;

            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing> mapObj = new EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing>();
                    DataAccessLayer.SBP_BlotterClearing ClearingObj = new DataAccessLayer.SBP_BlotterClearing();
                    ClearingObj = mapObj.Translate(blotterClearing);
                    status = DAL.InsertClearing(ClearingObj);

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
        public SBP_WebApiResponse UpdateClearing(Models.SBP_BlotterClearing blotterClearing)
        {

            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing> mapObj = new EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing>();
                    DataAccessLayer.SBP_BlotterClearing ClearingObj = new DataAccessLayer.SBP_BlotterClearing();
                    ClearingObj = mapObj.Translate(blotterClearing);
                    status = DAL.UpdateClearing(ClearingObj);

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
        public SBP_WebApiResponse DeleteClearing(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;

            try
            {
                status = DAL.DeleteClearing(id);

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