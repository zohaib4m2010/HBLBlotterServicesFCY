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
    public class BlotterRECONController : ApiController
    {
    
        [HttpGet]
        public JsonResult<Models.SBP_BlotterRECON> GetblotterRECON(int id)
        {
            EntitiyMapperBlotterRECON<DataAccessLayer.SBP_BlotterRECON, Models.SBP_BlotterRECON> mapObj = new EntitiyMapperBlotterRECON<DataAccessLayer.SBP_BlotterRECON, Models.SBP_BlotterRECON>();
            DataAccessLayer.SBP_BlotterRECON dalblotterRECON = DAL.GetRECONItem(id);
            Models.SBP_BlotterRECON products = new Models.SBP_BlotterRECON();
            products = mapObj.Translate(dalblotterRECON);
            return Json<Models.SBP_BlotterRECON>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.SP_GetSBPBlotterRECON_Result>> GetAllblotterRECON(int UserID, int BranchID, int CurID, int BR)
        {
            EntitiyMapperBlotterRECON<DataAccessLayer.SP_GetSBPBlotterRECON_Result, Models.SP_GetSBPBlotterRECON_Result> mapObj = new EntitiyMapperBlotterRECON<DataAccessLayer.SP_GetSBPBlotterRECON_Result, Models.SP_GetSBPBlotterRECON_Result>();

            List<DataAccessLayer.SP_GetSBPBlotterRECON_Result> blotterRECONList = DAL.GetAllBlotterRECON(UserID, BranchID, CurID, BR);
            List<Models.SP_GetSBPBlotterRECON_Result> blotterRECON = new List<Models.SP_GetSBPBlotterRECON_Result>();
            foreach (var item in blotterRECONList)
            {
                blotterRECON.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBPBlotterRECON_Result>>(blotterRECON);
        }
        [HttpPost]
        public bool InsertRECON(Models.SBP_BlotterRECON blotterRECON)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON> mapObj = new EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON>();
                DataAccessLayer.SBP_BlotterRECON RECONObj = new DataAccessLayer.SBP_BlotterRECON();
                RECONObj = mapObj.Translate(blotterRECON);
                status = DAL.InsertRECON(RECONObj);
            }
            return status;
        }


        [HttpPut]
        public bool UpdateRECON(Models.SBP_BlotterRECON blotterRECON)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON> mapObj = new EntitiyMapperBlotterRECON<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON>();
                DataAccessLayer.SBP_BlotterRECON RECONObj = new DataAccessLayer.SBP_BlotterRECON();
                RECONObj = mapObj.Translate(blotterRECON);
                status = DAL.UpdateRECON(RECONObj);
            }
            return status;
        }

        [HttpDelete]
        public bool DeleteRECON(int id)
        {
            var status = DAL.DeleteRECON(id);
            return status;
        }
    }
}
