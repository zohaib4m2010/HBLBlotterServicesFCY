﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_GetSBP_Reserved_Result
    {
        public int sno { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> ReservedBalance { get; set; }
        public Nullable<decimal> SBPBalanace { get; set; }
        public Nullable<decimal> BalanceDifference { get; set; }
    }
}