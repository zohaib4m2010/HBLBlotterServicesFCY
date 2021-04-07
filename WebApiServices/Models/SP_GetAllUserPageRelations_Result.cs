using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_GetAllUserPageRelations_Result
    {
        public int URID { get; set; }
        public int UPRID { get; set; }
        public int WPID { get; set; }
        public string RoleName { get; set; }
        public string PageName { get; set; }
        public string ControllerName { get; set; }
        public string DisplayName { get; set; }
        public Nullable<bool> DateChangeAccess { get; set; }
        public Nullable<bool> EditAccess { get; set; }
        public Nullable<bool> DeleteAccess { get; set; }
    }
}