using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMarket.Models
{
    public class Response
    {
        public bool Result { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}