using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterCurrencyController : ApiController
    {
        public JsonResult<Models.SP_GetAllBlotterCurrencyById_Result> GetAllCurrencies(int userid)
        {
            EntityMapperCurrencies<DataAccessLayer.SP_GetAllBlotterCurrencyById_Result, Models.SP_GetAllBlotterCurrencyById_Result> mapObj = new EntityMapperCurrencies<DataAccessLayer.SP_GetAllBlotterCurrencyById_Result, Models.SP_GetAllBlotterCurrencyById_Result>();
            DataAccessLayer.SP_GetAllBlotterCurrencyById_Result dalcurrencies = DAL.GetAllCurrenciesbyid(userid);
            Models.SP_GetAllBlotterCurrencyById_Result currecies = new Models.SP_GetAllBlotterCurrencyById_Result();
            currecies = mapObj.Translate(dalcurrencies);
            return Json<Models.SP_GetAllBlotterCurrencyById_Result>(currecies);
        }

    }
}
