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
    public class BlotterCRRReportFCYController : ApiController
    {        // GET: blotterCRRReportFCY
        [HttpGet]
        public SBP_WebApiResponse GetblotterCRRReportFCY(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterCRRReportFCY<DataAccessLayer.SBP_BlotterCRRReportFCY, Models.SBP_BlotterCRRReportFCY> mapObj = new EntitiyMapperBlotterCRRReportFCY<DataAccessLayer.SBP_BlotterCRRReportFCY, Models.SBP_BlotterCRRReportFCY>();
                DataAccessLayer.SBP_BlotterCRRReportFCY dalblotterCRRReportFCY = DAL.GetCRRReportFCYItem(id);
                Models.SBP_BlotterCRRReportFCY products = new Models.SBP_BlotterCRRReportFCY();
                products = mapObj.Translate(dalblotterCRRReportFCY);
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
        public SBP_WebApiResponse GetAllblotterCRRReportFCY(int UserID, int BranchID, int BR)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterCRRReportFCY<DataAccessLayer.SP_GetSBPBlotterCRRReportFCY_Result, Models.SP_GetSBPBlotterCRRReportFCY_Result> mapObj = new EntitiyMapperBlotterCRRReportFCY<DataAccessLayer.SP_GetSBPBlotterCRRReportFCY_Result, Models.SP_GetSBPBlotterCRRReportFCY_Result>();

                List<DataAccessLayer.SP_GetSBPBlotterCRRReportFCY_Result> blotterCRRReportFCYList = DAL.GetAllBlotterCRRReportFCY(UserID, BranchID, BR);
                List<Models.SP_GetSBPBlotterCRRReportFCY_Result> blotterCRRReportFCY = new List<Models.SP_GetSBPBlotterCRRReportFCY_Result>();
                foreach (var item in blotterCRRReportFCYList)
                {
                    blotterCRRReportFCY.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterCRRReportFCY.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterCRRReportFCY.Count > 0)
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
        public SBP_WebApiResponse InsertCRRReportFCY(Models.BlotterCRRFCYModel blotterCRRReportFCY)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterCRRReportFCY<Models.SBP_BlotterCRRReportFCY, DataAccessLayer.SBP_BlotterCRRReportFCY> mapObj = new EntitiyMapperBlotterCRRReportFCY<Models.SBP_BlotterCRRReportFCY, DataAccessLayer.SBP_BlotterCRRReportFCY>();
                    DataAccessLayer.SBP_BlotterCRRReportFCY CRRReportFCYObj = new DataAccessLayer.SBP_BlotterCRRReportFCY();
                    CRRReportFCYObj = mapObj.Translate(blotterCRRReportFCY.CRRReportFCY);
                    status = DAL.InsertCRRReportFCY(CRRReportFCYObj);

                    EntitiyMapperBlotterCRRReportFCY<Models.SBP_BlotterCRRReportingCurrencyWise, DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise>
                        mapObjCurWise = new EntitiyMapperBlotterCRRReportFCY<Models.SBP_BlotterCRRReportingCurrencyWise, DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise>();
                    DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise CRRReportFCYCurWiseObj = new DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise();

                    for (int i = 0; i < blotterCRRReportFCY.CRRReportingCurrencyWise.Count; i++)
                    {
                        CRRReportFCYCurWiseObj = mapObjCurWise.Translate(blotterCRRReportFCY.CRRReportingCurrencyWise[i]);
                        status = DAL.InsertCRRReportFCYCurrencyWise(CRRReportFCYCurWiseObj);
                    }

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
        public SBP_WebApiResponse UpdateCRRReportFCY(Models.BlotterCRRFCYModel blotterCRRReportFCY)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterCRRReportFCY<Models.SBP_BlotterCRRReportFCY, DataAccessLayer.SBP_BlotterCRRReportFCY> mapObj = new EntitiyMapperBlotterCRRReportFCY<Models.SBP_BlotterCRRReportFCY, DataAccessLayer.SBP_BlotterCRRReportFCY>();
                    DataAccessLayer.SBP_BlotterCRRReportFCY CRRReportFCYObj = new DataAccessLayer.SBP_BlotterCRRReportFCY();
                    CRRReportFCYObj = mapObj.Translate(blotterCRRReportFCY.CRRReportFCY);
                    status = DAL.UpdateCRRReportFCY(CRRReportFCYObj);

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
        public SBP_WebApiResponse DeleteCRRReportFCY(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;

            try
            {
                status = DAL.DeleteCRRReportFCY(id);

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
