using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterCashFlowController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPostAttribute]
        public bool UpdateRunningBal(String BranchCode) //,DateTime StartDate,DateTime Endate)
        {
            EntityMapperBlotterDTLDB<DataAccessLayer.SBP_BlotterDTLDaysWiseBal, Models.SBP_BlotterDTLDaysWiseBal> mapObj =
                new EntityMapperBlotterDTLDB<DataAccessLayer.SBP_BlotterDTLDaysWiseBal, Models.SBP_BlotterDTLDaysWiseBal>();

            DataAccessLayer.SBP_BlotterDTLDaysWiseBal blotter = DAL.GetDTLDeskBoard(BranchCode);

            bool status=false;
            if (blotter.Id > 0)
            {
                var StartDate = blotter.DTL_Date;
                var Endate = blotter.NextDate;
                status = DAL.UpdateRunningBal(BranchCode, StartDate, Endate);
            }
            return status;

        }


    }
}
