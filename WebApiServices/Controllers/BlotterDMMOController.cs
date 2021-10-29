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
    public class BlotterDMMOController : ApiController
    {
        // GET: blotterDMMO
  
        [HttpGet]
        public SBP_WebApiResponse GetAllblotterDMMO(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterDMMO<DataAccessLayer.SP_GetSBP_DMMO_Result, Models.SP_GetSBP_DMMO_Result> mapObj = new EntitiyMapperBlotterDMMO<DataAccessLayer.SP_GetSBP_DMMO_Result, Models.SP_GetSBP_DMMO_Result>();

                List<DataAccessLayer.SP_GetSBP_DMMO_Result> blotterDMMOList = DAL.GetAllBlotterDMMO(UserID, BranchID, BR, DateVal);
                List<Models.SP_GetSBP_DMMO_Result> blotterDMMO = new List<Models.SP_GetSBP_DMMO_Result>();
                foreach (var item in blotterDMMOList)
                {
                    blotterDMMO.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterDMMO.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterDMMO.Count > 0)
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
  

        [HttpPut]
        public SBP_WebApiResponse UpdateDMMO(Models.SBP_DMMO blotterDMMO)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    EntitiyMapperBlotterDMMO<Models.SBP_DMMO, DataAccessLayer.SBP_DMMO> mapObj = new EntitiyMapperBlotterDMMO<Models.SBP_DMMO, DataAccessLayer.SBP_DMMO>();
                    DataAccessLayer.SBP_DMMO DMMOObj = new DataAccessLayer.SBP_DMMO();
                    DMMOObj = mapObj.Translate(blotterDMMO);
                    status = DAL.UpdateDMMO(DMMOObj);

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


    }
}
