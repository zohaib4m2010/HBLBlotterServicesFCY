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
    public class UserRoleController : ApiController
    {
        // GET: UserRole

        [HttpGet]
        public JsonResult<Models.UserRole> GetUserRole(int id)
        {
            EntityMapperUserRole<DataAccessLayer.UserRole, Models.UserRole> mapObj = new EntityMapperUserRole<DataAccessLayer.UserRole, Models.UserRole>();
            DataAccessLayer.UserRole dalBlotterTBO = DAL.GetUserRole(id);
            Models.UserRole products = new Models.UserRole();
            products = mapObj.Translate(dalBlotterTBO);
            return Json<Models.UserRole>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.UserRole>> GetAllUserRole()
        {
            EntityMapperUserRole<DataAccessLayer.UserRole, Models.UserRole> mapObj = new EntityMapperUserRole<DataAccessLayer.UserRole, Models.UserRole>();

            List<DataAccessLayer.UserRole> UserRoleList = DAL.GetAllUserRole();
            List<Models.UserRole> blotterUserRole = new List<Models.UserRole>();
            foreach (var item in UserRoleList)
            {
                blotterUserRole.Add(mapObj.Translate(item));
            }
            return Json<List<Models.UserRole>>(blotterUserRole);
        }
        [HttpPost]
        public bool InsertUserRole(Models.UserRole item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperUserRole<Models.UserRole, DataAccessLayer.UserRole> mapObj = new EntityMapperUserRole<Models.UserRole, DataAccessLayer.UserRole>();
                DataAccessLayer.UserRole UserRoleObj = new DataAccessLayer.UserRole();
                UserRoleObj = mapObj.Translate(item);
                status = DAL.InsertUserRole(UserRoleObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateUserRole(Models.UserRole item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperUserRole<Models.UserRole, DataAccessLayer.UserRole> mapObj = new EntityMapperUserRole<Models.UserRole, DataAccessLayer.UserRole>();
                DataAccessLayer.UserRole UserRoleObj = new DataAccessLayer.UserRole();
                UserRoleObj = mapObj.Translate(item);
                status = DAL.UpdateUserRole(UserRoleObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteUserRole(int id)
        {
            var status = DAL.DeleteUserRole(id);
            return status;
        }
    }
}
