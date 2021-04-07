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
    public class BlotterSetupController : ApiController
    {
 
        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterSetup>> GetAllSetupItems()
        {
            EntityMapperBlotter<DataAccessLayer.SBP_BlotterSetup, Models.SBP_BlotterSetup> mapObj = new EntityMapperBlotter<DataAccessLayer.SBP_BlotterSetup, Models.SBP_BlotterSetup>();

            List<DataAccessLayer.SBP_BlotterSetup> blotterSetupList = DAL.GetAllSetUpItems();
            List<Models.SBP_BlotterSetup> blottersetup = new List<Models.SBP_BlotterSetup>();
            foreach (var item in blotterSetupList)
            {
                blottersetup.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterSetup>>(blottersetup);
        }

        [HttpGet]
        public JsonResult<Models.SBP_BlotterSetup> GetSetUpItem(int id)
        {
            EntityMapperBlotter<DataAccessLayer.SBP_BlotterSetup, Models.SBP_BlotterSetup> mapObj = new EntityMapperBlotter<DataAccessLayer.SBP_BlotterSetup, Models.SBP_BlotterSetup>();
            DataAccessLayer.SBP_BlotterSetup dalsetup = DAL.GetSetUpItem(id);
            Models.SBP_BlotterSetup products = new Models.SBP_BlotterSetup();
            products = mapObj.Translate(dalsetup);
            return Json<Models.SBP_BlotterSetup>(products);
        }
        [HttpPost]
        public bool InsertSetup(Models.SBP_BlotterSetup blottersetup)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotter<Models.SBP_BlotterSetup, DataAccessLayer.SBP_BlotterSetup> mapObj = new EntityMapperBlotter<Models.SBP_BlotterSetup, DataAccessLayer.SBP_BlotterSetup>();
                DataAccessLayer.SBP_BlotterSetup setupObj = new DataAccessLayer.SBP_BlotterSetup();
                setupObj = mapObj.Translate(blottersetup);
                status = DAL.InsertSetUp(setupObj);
            }
            return status;

        }
        [HttpPut]
        public bool UpdateSetUp(Models.SBP_BlotterSetup blottersetup)
        {
            EntityMapperBlotter<Models.SBP_BlotterSetup, DataAccessLayer.SBP_BlotterSetup> mapObj = new EntityMapperBlotter<Models.SBP_BlotterSetup, DataAccessLayer.SBP_BlotterSetup>();
            DataAccessLayer.SBP_BlotterSetup setupObj = new DataAccessLayer.SBP_BlotterSetup();
            setupObj = mapObj.Translate(blottersetup);
            var status = DAL.UpdateSetUp(setupObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteSetUp(int id)
        {
            var status = DAL.DeleteSetUp(id);
            return status;
        }
        //// Prevent Memory Leak  
        //protected override void Dispose(bool disposing)
        //{
        //    using (dbEntities db = new dbEntities())
        //        db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}

