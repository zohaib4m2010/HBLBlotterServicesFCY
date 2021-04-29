using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_LoginInfoWithRoleId
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<int> LoginFailedCount { get; set; }
        public string LoginIPAddress { get; set; }
        public string CustomerTimeZone { get; set; }
        public Nullable<System.DateTime> LastAccessedDate { get; set; }
        public Nullable<bool> AccountLocked { get; set; }
        public int BranchId { get; set; }
        public bool isActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<bool> isConventional { get; set; }
        public Nullable<bool> isislamic { get; set; }
        public int URID { get; set; }
        public string DefaultPage { get; set; }
        public string BlotterType { get; set; }
    }
}