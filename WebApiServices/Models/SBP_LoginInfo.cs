using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_LoginInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<int> LoginFailedCount { get; set; }
        public string LoginIPAddress { get; set; }
        public string CustomerTimeZone { get; set; }
        public Nullable<System.DateTime> LastAccessedDate { get; set; }
        public Nullable<bool> AccountLocked { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DefaultPage { get; set; }
        public Nullable<bool> isConventional { get; set; }
        public Nullable<bool> isislamic { get; set; }
        public string BlotterType { get; set; }
        public Nullable<bool> isLoggedIn { get; set; }
        public string Department { get; set; }
        public Nullable<bool> ChangePassword { get; set; }
    }
}