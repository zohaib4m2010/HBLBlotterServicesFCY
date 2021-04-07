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
    public class BlotterDTLController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterDTL>> GetAllDTLDeals(String BrCode)
        {
            EntityMapperBlotterDTL<DataAccessLayer.SBP_BlotterDTL, Models.SBP_BlotterDTL> mapObj = new EntityMapperBlotterDTL<DataAccessLayer.SBP_BlotterDTL, Models.SBP_BlotterDTL>();

            List<DataAccessLayer.SBP_BlotterDTL> blotterDealList = DAL.GetAllDTLDeals(BrCode);
            List<Models.SBP_BlotterDTL> blotterDeal = new List<Models.SBP_BlotterDTL>();
            foreach (var item in blotterDealList)
            {
                blotterDeal.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterDTL>>(blotterDeal);
        }
        [HttpGet]
        public JsonResult<Models.SBP_BlotterDTL> GetDTLDeal(int id)
        {
            EntityMapperBlotterDTL<DataAccessLayer.SBP_BlotterDTL, Models.SBP_BlotterDTL> mapObj = new EntityMapperBlotterDTL<DataAccessLayer.SBP_BlotterDTL, Models.SBP_BlotterDTL>();
            DataAccessLayer.SBP_BlotterDTL dalDTLDeal = DAL.GetDTLDeal(id);
            Models.SBP_BlotterDTL products = new Models.SBP_BlotterDTL();
            products = mapObj.Translate(dalDTLDeal);
            return Json<Models.SBP_BlotterDTL>(products);
        }
        [HttpPost]
        public bool InsertDTLDeal(Models.SBP_BlotterDTL blotterDeal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterDTL<Models.SBP_BlotterDTL, DataAccessLayer.SBP_BlotterDTL> mapObj = new EntityMapperBlotterDTL<Models.SBP_BlotterDTL, DataAccessLayer.SBP_BlotterDTL>();
                DataAccessLayer.SBP_BlotterDTL DTLDealObj = new DataAccessLayer.SBP_BlotterDTL();
                DTLDealObj = mapObj.Translate(blotterDeal);
                status = DAL.InsertDTLDeals(DTLDealObj);
            }
            return status;

        }
        [HttpPut]
        public bool UpdateDTLDeal(Models.SBP_BlotterDTL blotterDeal)
        {
            EntityMapperBlotterDTL<Models.SBP_BlotterDTL, DataAccessLayer.SBP_BlotterDTL> mapObj = new EntityMapperBlotterDTL<Models.SBP_BlotterDTL, DataAccessLayer.SBP_BlotterDTL>();
            DataAccessLayer.SBP_BlotterDTL DTLDealObj = new DataAccessLayer.SBP_BlotterDTL();
            DTLDealObj = mapObj.Translate(blotterDeal);
            var status = DAL.UpdateDTLDeals(DTLDealObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteDTLDeal(int id)
        {
            var status = DAL.DeleteDTLDeals(id);
            return status;
        }
    }
}
