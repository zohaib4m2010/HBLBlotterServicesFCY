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
    public class BlotterController : ApiController
    {
        // GET: Showroom  
        [HttpGet]
        public JsonResult<List<Models.SP_SBPBlotter_Result>> GetAllBlotterList()
        {
            EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result>();

            List<DataAccessLayer.SP_SBPBlotter_Result> blotterList = DAL.GetAllBlotterData();
            List<Models.SP_SBPBlotter_Result> blotter = new List<Models.SP_SBPBlotter_Result>();
            foreach (var item in blotterList)
            {
                blotter.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_SBPBlotter_Result>>(blotter);
        }
    }
}
