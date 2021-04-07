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
    public class BranchesController : ApiController
    {
        // GET: Branches


        [HttpGet]
        public JsonResult<Models.Branches> GetBranches(int id)
        {
            EntityMapperBranches<DataAccessLayer.Branches, Models.Branches> mapObj = new EntityMapperBranches<DataAccessLayer.Branches, Models.Branches>();
            DataAccessLayer.Branches dalBranches = DAL.GetBranches(id);
            Models.Branches products = new Models.Branches();
            products = mapObj.Translate(dalBranches);
            return Json<Models.Branches>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.Branches>> GetAllBranches()
        {
            EntityMapperBranches<DataAccessLayer.Branches, Models.Branches> mapObj = new EntityMapperBranches<DataAccessLayer.Branches, Models.Branches>();

            List<DataAccessLayer.Branches> BranchesList = DAL.GetAllBranches();
            List<Models.Branches> blotterBranches = new List<Models.Branches>();
            foreach (var item in BranchesList)
            {
                blotterBranches.Add(mapObj.Translate(item));
            }
            return Json<List<Models.Branches>>(blotterBranches);
        }
        [HttpPost]
        public bool InsertBranches(Models.Branches item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBranches<Models.Branches, DataAccessLayer.Branches> mapObj = new EntityMapperBranches<Models.Branches, DataAccessLayer.Branches>();
                DataAccessLayer.Branches BranchesObj = new DataAccessLayer.Branches();
                BranchesObj = mapObj.Translate(item);
                status = DAL.InsertBranches(BranchesObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateBranches(Models.Branches item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBranches<Models.Branches, DataAccessLayer.Branches> mapObj = new EntityMapperBranches<Models.Branches, DataAccessLayer.Branches>();
                DataAccessLayer.Branches BranchesObj = new DataAccessLayer.Branches();
                BranchesObj = mapObj.Translate(item);
                status = DAL.UpdateBranches(BranchesObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteBranches(int id)
        {
            var status = DAL.DeleteBranches(id);
            return status;
        }


    }
}