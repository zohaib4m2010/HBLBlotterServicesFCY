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
    public class BlotterDTController : ApiController
    {

        [HttpGet]
        public JsonResult<List<Models.SP_SBPOpicsSystemDate_Result>> GetBlotterSysDT(String BrCode)
        {
            EntityMapperBlotterCurrentDT<DataAccessLayer.SP_SBPOpicsSystemDate_Result, Models.SP_SBPOpicsSystemDate_Result> mapObj = 
            new EntityMapperBlotterCurrentDT<DataAccessLayer.SP_SBPOpicsSystemDate_Result, Models.SP_SBPOpicsSystemDate_Result>();

            List<DataAccessLayer.SP_SBPOpicsSystemDate_Result> blotterListDT = DAL.GetSystemDT(BrCode);
            List<Models.SP_SBPOpicsSystemDate_Result> blotter = new List<Models.SP_SBPOpicsSystemDate_Result>();
            foreach (var item in blotterListDT)
            {
                blotter.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_SBPOpicsSystemDate_Result>>(blotter);
        }
    }
}
