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
    public class NostroBankController : ApiController
    {
        // GET: NostroBank

        [HttpGet]
        public JsonResult<Models.NostroBank> GetNostroBank(int id)
        {
            EntityMapperNostroBank<DataAccessLayer.NostroBank, Models.NostroBank> mapObj = new EntityMapperNostroBank<DataAccessLayer.NostroBank, Models.NostroBank>();
            DataAccessLayer.NostroBank dalBlotterTBO = DAL.GetNostroBank(id);
            Models.NostroBank products = new Models.NostroBank();
            products = mapObj.Translate(dalBlotterTBO);
            return Json<Models.NostroBank>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.NostroBank>> GetAllNostroBank()
        {
            EntityMapperNostroBank<DataAccessLayer.NostroBank, Models.NostroBank> mapObj = new EntityMapperNostroBank<DataAccessLayer.NostroBank, Models.NostroBank>();

            List<DataAccessLayer.NostroBank> NostroBankList = DAL.GetAllNostroBank();
            List<Models.NostroBank> blotterNostroBank = new List<Models.NostroBank>();
            foreach (var item in NostroBankList)
            {
                blotterNostroBank.Add(mapObj.Translate(item));
            }
            return Json<List<Models.NostroBank>>(blotterNostroBank);
        }
        [HttpPost]
        public bool InsertNostroBank(Models.NostroBank item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank> mapObj = new EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank>();
                DataAccessLayer.NostroBank NostroBankObj = new DataAccessLayer.NostroBank();
                NostroBankObj = mapObj.Translate(item);
                status = DAL.InsertNostroBank(NostroBankObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateNostroBank(Models.NostroBank item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank> mapObj = new EntityMapperNostroBank<Models.NostroBank, DataAccessLayer.NostroBank>();
                DataAccessLayer.NostroBank NostroBankObj = new DataAccessLayer.NostroBank();
                NostroBankObj = mapObj.Translate(item);
                status = DAL.UpdateNostroBank(NostroBankObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteNostroBank(int id)
        {
            var status = DAL.DeleteNostroBank(id);
            return status;
        }
    }
}