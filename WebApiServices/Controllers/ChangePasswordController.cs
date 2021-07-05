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
    public class ChangePasswordController : ApiController
    {



        [HttpPut]
        public bool UpdatePassword(Models.ChangePassword blotterCP)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                status = DAL.UpdateUserPassword(blotterCP.UserId,blotterCP.Password,blotterCP.NewPassword);
            }
            return status;

        }
    }
}
