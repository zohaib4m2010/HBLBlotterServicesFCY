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
    public class BlotterBreakupsController : ApiController
    {
        // GET: BlotterBreakups

        [HttpGet]
        public JsonResult<Models.SBP_BlotterBreakups> GetBlotterBreakups(int id)
        {
            EntityMapperBlotterBreakups<DataAccessLayer.SBP_BlotterBreakups, Models.SBP_BlotterBreakups> mapObj = new EntityMapperBlotterBreakups<DataAccessLayer.SBP_BlotterBreakups, Models.SBP_BlotterBreakups>();
            DataAccessLayer.SBP_BlotterBreakups dalBlotterBreakups = DAL.GetBlotterBreakups(id);
            Models.SBP_BlotterBreakups products = new Models.SBP_BlotterBreakups();
            products = mapObj.Translate(dalBlotterBreakups);
            return Json<Models.SBP_BlotterBreakups>(products);
        }
        [HttpGet]
        public JsonResult<Models.SP_GetLatestBreakup_Result> GetAllBlotterBreakups(int UserID, int BranchID, int CurID, int BR)
        {
            EntityMapperBlotterBreakups<DataAccessLayer.SP_GetLatestBreakup_Result, Models.SP_GetLatestBreakup_Result> mapObj = new EntityMapperBlotterBreakups<DataAccessLayer.SP_GetLatestBreakup_Result, Models.SP_GetLatestBreakup_Result>();

            DataAccessLayer.SP_GetLatestBreakup_Result SBP_BlotterBreakupsList = DAL.GetAllBlotterBreakups(UserID,BranchID,CurID,BR);
            Models.SP_GetLatestBreakup_Result blotterSBP_BlotterBreakups = new Models.SP_GetLatestBreakup_Result();
            //foreach (var item in SBP_BlotterBreakupsList)
            //{
                blotterSBP_BlotterBreakups = mapObj.Translate(SBP_BlotterBreakupsList);
            //}
            return Json<Models.SP_GetLatestBreakup_Result>(blotterSBP_BlotterBreakups);
        }
        [HttpPost]
        public bool InsertBlotterBreakups(Models.SBP_BlotterBreakups item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups> mapObj = new EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups>();
                DataAccessLayer.SBP_BlotterBreakups SBP_BlotterBreakupsObj = new DataAccessLayer.SBP_BlotterBreakups();
                SBP_BlotterBreakupsObj = mapObj.Translate(item);
                status = DAL.InsertBlotterBreakups(SBP_BlotterBreakupsObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateBlotterBreakups(Models.SBP_BlotterBreakups item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups> mapObj = new EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups>();
                DataAccessLayer.SBP_BlotterBreakups SBP_BlotterBreakupsObj = new DataAccessLayer.SBP_BlotterBreakups();
                SBP_BlotterBreakupsObj = mapObj.Translate(item);
                status = DAL.UpdateBlotterBreakups(SBP_BlotterBreakupsObj);
            }
            return status;

        }

        [HttpPut]
        public bool UpdateBreakupsOpngBal(Models.SBP_BlotterBreakups item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups> mapObj = new EntityMapperBlotterBreakups<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups>();
                DataAccessLayer.SBP_BlotterBreakups SBP_BlotterBreakupsObj = new DataAccessLayer.SBP_BlotterBreakups();
                SBP_BlotterBreakupsObj = mapObj.Translate(item);
                status = DAL.UpdateBreakupsOpngBal(SBP_BlotterBreakupsObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteBlotterBreakups(int id)
        {
            var status = DAL.DeleteBlotterBreakups(id);
            return status;
        }
    }
}