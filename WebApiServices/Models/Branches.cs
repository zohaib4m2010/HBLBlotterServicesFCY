using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class Branches
    {
        public int BID { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BrachDescription { get; set; }
        public string BranchLocation { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}