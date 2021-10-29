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
    public class BlotterImportExportController : ApiController
    {
        [HttpGet]
        public SBP_WebApiResponse GetblotterImportExport(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterImportExport<DataAccessLayer.SBP_BlotterImportExport, Models.SBP_BlotterImportExport> mapObj = new EntitiyMapperBlotterImportExport<DataAccessLayer.SBP_BlotterImportExport, Models.SBP_BlotterImportExport>();
                DataAccessLayer.SBP_BlotterImportExport dalblotterImportExport = DAL.GetImportExportItem(id);
                Models.SBP_BlotterImportExport products = new Models.SBP_BlotterImportExport();
                products = mapObj.Translate(dalblotterImportExport);

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
        public SBP_WebApiResponse GetAllblotterImportExport(int UserID, int BranchID, int BR, string DateVal)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterImportExport<DataAccessLayer.SP_GetSBP_BlotterImportExport_Result, Models.SP_GetSBP_BlotterImportExport_Result> mapObj = new EntitiyMapperBlotterImportExport<DataAccessLayer.SP_GetSBP_BlotterImportExport_Result, Models.SP_GetSBP_BlotterImportExport_Result>();
                List<DataAccessLayer.SP_GetSBP_BlotterImportExport_Result> blotterImportExportList = DAL.GetAllBlotterImportExport(UserID, BranchID, BR, DateVal);
                List<Models.SP_GetSBP_BlotterImportExport_Result> blotterImportExport = new List<Models.SP_GetSBP_BlotterImportExport_Result>();
                foreach (var item in blotterImportExportList)
                {
                    blotterImportExport.Add(mapObj.Translate(item));
                }
                ////HTTP Json Response
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);

                var jsonresponse = JsonConvert.SerializeObject(blotterImportExport.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonresponse, Encoding.UTF8, "application/json");

                if (blotterImportExport.Count > 0)
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
        public SBP_WebApiResponse InsertImportExport(Models.SBP_BlotterImportExport blotterImportExport)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterImportExport<Models.SBP_BlotterImportExport, DataAccessLayer.SBP_BlotterImportExport> mapObj = new EntitiyMapperBlotterImportExport<Models.SBP_BlotterImportExport, DataAccessLayer.SBP_BlotterImportExport>();
                    DataAccessLayer.SBP_BlotterImportExport ImportExportObj = new DataAccessLayer.SBP_BlotterImportExport();
                    ImportExportObj = mapObj.Translate(blotterImportExport);
                    status = DAL.InsertImportExport(ImportExportObj);

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
        public SBP_WebApiResponse UpdateImportExport(Models.SBP_BlotterImportExport blotterImportExport)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterImportExport<Models.SBP_BlotterImportExport, DataAccessLayer.SBP_BlotterImportExport> mapObj = new EntitiyMapperBlotterImportExport<Models.SBP_BlotterImportExport, DataAccessLayer.SBP_BlotterImportExport>();
                    DataAccessLayer.SBP_BlotterImportExport ImportExportObj = new DataAccessLayer.SBP_BlotterImportExport();
                    ImportExportObj = mapObj.Translate(blotterImportExport);
                    status = DAL.UpdateImportExport(ImportExportObj);

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
        public SBP_WebApiResponse DeleteImportExport(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                status = DAL.DeleteImportExport(id);

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
