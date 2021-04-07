using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class UserPageRelation
    {
        public int UPRID { get; set; }
        public int URID { get; set; }
        public int WPID { get; set; }
        public bool DateChangeAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool DeleteAccess { get; set; }
    }
}