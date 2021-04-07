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
    public class BlotterOpeningController : ApiController
    {
        //*****************************************************
        //Opening Deals Producers
        //*****************************************************


        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterOpening>> GetAllOpeningDeals(String BrCode)
        {
            EntityMapperBlotter<DataAccessLayer.SBP_BlotterOpening, Models.SBP_BlotterOpening> mapObj =    new EntityMapperBlotter<DataAccessLayer.SBP_BlotterOpening, Models.SBP_BlotterOpening>();

            List<DataAccessLayer.SBP_BlotterOpening> blotterDealList = DAL.GetAllOpeningAmount(BrCode);
            List<Models.SBP_BlotterOpening> blotterDeal = new List<Models.SBP_BlotterOpening>();
            foreach (var item in blotterDealList)
            {
                blotterDeal.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterOpening>>(blotterDeal);
        }
        [HttpGet]
        public JsonResult<Models.SBP_BlotterOpening> GetOpeningDeal(int id)
        {
            EntityMapperBlotter<DataAccessLayer.SBP_BlotterOpening, Models.SBP_BlotterOpening> mapObj = 
                new EntityMapperBlotter<DataAccessLayer.SBP_BlotterOpening, Models.SBP_BlotterOpening>();
            DataAccessLayer.SBP_BlotterOpening dalOpeningDeal = DAL.GetOpeningDeal(id);
            Models.SBP_BlotterOpening products = new Models.SBP_BlotterOpening();
            products = mapObj.Translate(dalOpeningDeal);
            return Json<Models.SBP_BlotterOpening>(products);
        }
        [HttpPost]
        public bool Insert(Models.SBP_BlotterOpening blotterDeal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotter<Models.SBP_BlotterOpening, DataAccessLayer.SBP_BlotterOpening> mapObj = 
                    new EntityMapperBlotter<Models.SBP_BlotterOpening, DataAccessLayer.SBP_BlotterOpening>();
                DataAccessLayer.SBP_BlotterOpening OpeningDealObj = new DataAccessLayer.SBP_BlotterOpening();
                OpeningDealObj = mapObj.Translate(blotterDeal);
                status = DAL.InsertOpeningDeals(OpeningDealObj);
            }
            return status;

        }
        [HttpPut]
        public bool Update(Models.SBP_BlotterOpening blotterDeal)
        {
            EntityMapperBlotter<Models.SBP_BlotterOpening, DataAccessLayer.SBP_BlotterOpening> mapObj = new EntityMapperBlotter<Models.SBP_BlotterOpening, DataAccessLayer.SBP_BlotterOpening>();
            DataAccessLayer.SBP_BlotterOpening OpeningDealObj = new DataAccessLayer.SBP_BlotterOpening();
            OpeningDealObj = mapObj.Translate(blotterDeal);
            var status = DAL.UpdateOpeningDeals(OpeningDealObj);
            return status;

        }
        [HttpDelete]
        public bool Delete(int id)
        {
            var status = DAL.DeleteOpeningDeals(id);
            return status;
        }
    }
}
