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
    public class BlotterManualDealsController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterManualDeals >> GetAllManualDeals(String BrCode)
        {
            EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualDeals, Models.SBP_BlotterManualDeals> mapObj = new EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualDeals, Models.SBP_BlotterManualDeals>();

            List<DataAccessLayer.SBP_BlotterManualDeals> blotterDealList = DAL.GetAllDeals(BrCode);
            List<Models.SBP_BlotterManualDeals> blotterDeal = new List<Models.SBP_BlotterManualDeals>();
            foreach (var item in blotterDealList)
            {
                blotterDeal.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterManualDeals>>(blotterDeal);
        }
        [HttpGet]
        public JsonResult<Models.SBP_BlotterManualDeals> GetManualDeal(int id)
        {
            EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualDeals, Models.SBP_BlotterManualDeals> mapObj = new EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualDeals, Models.SBP_BlotterManualDeals>();
            DataAccessLayer.SBP_BlotterManualDeals dalManualDeal = DAL.GetManualDeal(id);
            Models.SBP_BlotterManualDeals products = new Models.SBP_BlotterManualDeals();
            products = mapObj.Translate(dalManualDeal);
            return Json<Models.SBP_BlotterManualDeals>(products);
        }
        [HttpPost]
        public bool InsertManualDeal(Models.SBP_BlotterManualDeals blotterDeal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterManual<Models.SBP_BlotterManualDeals, DataAccessLayer.SBP_BlotterManualDeals> mapObj = new EntityMapperBlotterManual<Models.SBP_BlotterManualDeals, DataAccessLayer.SBP_BlotterManualDeals>();
                DataAccessLayer.SBP_BlotterManualDeals ManualDealObj = new DataAccessLayer.SBP_BlotterManualDeals();
                ManualDealObj = mapObj.Translate(blotterDeal);
                status = DAL.InsertManualDeals(ManualDealObj);
            }
            return status;

        }
        [HttpPut]
        public bool UpdateManualDeal(Models.SBP_BlotterManualDeals blotterDeal)
        {
            EntityMapperBlotterManual<Models.SBP_BlotterManualDeals, DataAccessLayer.SBP_BlotterManualDeals> mapObj = new EntityMapperBlotterManual<Models.SBP_BlotterManualDeals, DataAccessLayer.SBP_BlotterManualDeals>();
            DataAccessLayer.SBP_BlotterManualDeals ManualDealObj = new DataAccessLayer.SBP_BlotterManualDeals();
            ManualDealObj = mapObj.Translate(blotterDeal);
            var status = DAL.UpdateManualDeals(ManualDealObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteManualDeal(int id)
        {
            var status = DAL.DeleteManualDeals(id);
            return status;
        }

      
    }
}
