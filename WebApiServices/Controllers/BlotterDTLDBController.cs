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
    public class BlotterDTLDBController : ApiController
    {
        // GET: Showroom  
        [HttpGet]
        public JsonResult<Models.SBP_BlotterDTLDaysWiseBal> GetBlotterDBList(String BrCode)
        {
            EntityMapperBlotterDTLDB<DataAccessLayer.SBP_BlotterDTLDaysWiseBal, Models.SBP_BlotterDTLDaysWiseBal> mapObj = 
                new EntityMapperBlotterDTLDB<DataAccessLayer.SBP_BlotterDTLDaysWiseBal, Models.SBP_BlotterDTLDaysWiseBal>();

            DataAccessLayer.SBP_BlotterDTLDaysWiseBal blotterList = DAL.GetDTLDeskBoard(BrCode);
            Models.SBP_BlotterDTLDaysWiseBal blotter = new Models.SBP_BlotterDTLDaysWiseBal();


            blotter = mapObj.Translate(blotterList); 
            return Json<Models.SBP_BlotterDTLDaysWiseBal>(blotter);
        }

        [HttpPut]
        public bool UpdateWiseBal(Models.SBP_BlotterDTLDaysWiseBal blotterWiseBal)
        {
            EntityMapperBlotterDTLDB<Models.SBP_BlotterDTLDaysWiseBal, DataAccessLayer.SBP_BlotterDTLDaysWiseBal> mapObj =
                new EntityMapperBlotterDTLDB<Models.SBP_BlotterDTLDaysWiseBal, DataAccessLayer.SBP_BlotterDTLDaysWiseBal>();
            DataAccessLayer.SBP_BlotterDTLDaysWiseBal WiseBalObj = new DataAccessLayer.SBP_BlotterDTLDaysWiseBal();
            WiseBalObj = mapObj.Translate(blotterWiseBal);
            var status = DAL.UpdateWiseBal(WiseBalObj);
            return status;

        }


    }
}
