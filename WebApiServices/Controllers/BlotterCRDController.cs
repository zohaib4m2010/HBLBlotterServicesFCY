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
    public class BlotterCRDController : ApiController
    {

        // GET: blotterCRD
        [HttpGet]
        public SBP_WebApiResponse GetblotterCRD(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterCRD<DataAccessLayer.SBP_BlotterCRD, Models.SBP_BlotterCRD> mapObj = new EntitiyMapperBlotterCRD<DataAccessLayer.SBP_BlotterCRD, Models.SBP_BlotterCRD>();
                DataAccessLayer.SBP_BlotterCRD dalblotterCRD = DAL.GetCRDItem(id);
                Models.SBP_BlotterCRD products = new Models.SBP_BlotterCRD();
                products = mapObj.Translate(dalblotterCRD);
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
        public SBP_WebApiResponse GetAllblotterCRD(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterCRD<DataAccessLayer.SP_GetSBPBlotterCRD_Result, Models.SP_GetSBPBlotterCRD_Result> mapObj = new EntitiyMapperBlotterCRD<DataAccessLayer.SP_GetSBPBlotterCRD_Result, Models.SP_GetSBPBlotterCRD_Result>();

                List<DataAccessLayer.SP_GetSBPBlotterCRD_Result> blotterCRDList = DAL.GetAllBlotterCRD(UserID, BranchID, CurID, BR, DateVal);
                List<Models.SP_GetSBPBlotterCRD_Result> blotterCRD = new List<Models.SP_GetSBPBlotterCRD_Result>();
                foreach (var item in blotterCRDList)
                {
                    blotterCRD.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterCRD.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterCRD.Count > 0)
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
        public SBP_WebApiResponse InsertCRD(Models.SBP_BlotterCRD blotterCRD)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {

                    EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD> mapObj = new EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD>();
                    DataAccessLayer.SBP_BlotterCRD CRDObj = new DataAccessLayer.SBP_BlotterCRD();
                    CRDObj = mapObj.Translate(blotterCRD);
                    status = DAL.InsertCRD(CRDObj);
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
                    Message = "Failed",
                    Data = ex.Message
                };
                return responseData;
            }

        }


        [HttpPut]
        public SBP_WebApiResponse UpdateCRD(Models.SBP_BlotterCRD blotterCRD)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD> mapObj = new EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD>();
                    DataAccessLayer.SBP_BlotterCRD CRDObj = new DataAccessLayer.SBP_BlotterCRD();
                    CRDObj = mapObj.Translate(blotterCRD);
                    status = DAL.UpdateCRD(CRDObj);

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


        [HttpDelete]
        public SBP_WebApiResponse DeleteCRD(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;

            try
            {
                status = DAL.DeleteCRD(id);

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
