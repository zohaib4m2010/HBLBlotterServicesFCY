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
        // GET: BlotterEstAdjBal

        [HttpGet]
        public JsonResult<Models.SBP_BlotterManualEstBalance> GetBlotterEstAdjBalById(int id)
        {
            EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualEstBalance, Models.SBP_BlotterManualEstBalance>
                mapObj = new EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualEstBalance, Models.SBP_BlotterManualEstBalance>();
            DataAccessLayer.SBP_BlotterManualEstBalance dalBlotterEstAdjBal = DAL.GetEstAdjBalById(id);
            Models.SBP_BlotterManualEstBalance products = new Models.SBP_BlotterManualEstBalance();
            products = mapObj.Translate(dalBlotterEstAdjBal);
            return Json<Models.SBP_BlotterManualEstBalance>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterManualEstBalance>> GetAllBlotterEstAdjBal(int UserID, int BranchID, int CurID, int BR)
        {
            EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualEstBalance, Models.SBP_BlotterManualEstBalance> mapObj = new EntityMapperBlotterManual<DataAccessLayer.SBP_BlotterManualEstBalance, Models.SBP_BlotterManualEstBalance>();

            List<DataAccessLayer.SBP_BlotterManualEstBalance> blotterEstAdjBalList = DAL.GetAllBlotterEstAdjBal(UserID, BranchID, CurID, BR);
            List<Models.SBP_BlotterManualEstBalance> blotterEstAdjBal = new List<Models.SBP_BlotterManualEstBalance>();
            foreach (var item in blotterEstAdjBalList)
            {
                blotterEstAdjBal.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterManualEstBalance>>(blotterEstAdjBal);
        }
        [HttpPost]
        public bool InsertEstAdjBal(Models.SBP_BlotterManualEstBalance blotterEstAdjBal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterManual<Models.SBP_BlotterManualEstBalance, DataAccessLayer.SBP_BlotterManualEstBalance> mapObj = new EntityMapperBlotterManual<Models.SBP_BlotterManualEstBalance, DataAccessLayer.SBP_BlotterManualEstBalance>();
                DataAccessLayer.SBP_BlotterManualEstBalance EstAdjBalObj = new DataAccessLayer.SBP_BlotterManualEstBalance();
                EstAdjBalObj = mapObj.Translate(blotterEstAdjBal);
                status = DAL.InsertEstAdjBal(EstAdjBalObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateEstAdjBal(Models.SBP_BlotterManualEstBalance blotterEstAdjBal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterManual<Models.SBP_BlotterManualEstBalance, DataAccessLayer.SBP_BlotterManualEstBalance> mapObj = new EntityMapperBlotterManual<Models.SBP_BlotterManualEstBalance, DataAccessLayer.SBP_BlotterManualEstBalance>();
                DataAccessLayer.SBP_BlotterManualEstBalance EstAdjBalObj = new DataAccessLayer.SBP_BlotterManualEstBalance();
                EstAdjBalObj = mapObj.Translate(blotterEstAdjBal);
                status = DAL.UpdateEstAdjBal(EstAdjBalObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteEstAdjBal(int id)
        {
            var status = DAL.DeleteEstAdjBal(id);
            return status;
        }


        [HttpDelete]
        public bool ResetEstAdjBal(int id)
        {
            var status = DAL.ResetEstAdjBal(id);
            return status;
        }




        // GET: SBP_BlotterManualDeals


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
