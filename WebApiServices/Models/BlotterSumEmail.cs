using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Models
{
    public class BlotterSumEmail
    {
        public Nullable<decimal> InFlow { get; set; }
        public Nullable<decimal> OutFlow { get; set; }
        public Nullable<decimal> Balance { get; set; }

    }
}
