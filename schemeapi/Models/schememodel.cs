using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schemeapi.Models
{
    public class schememodel
    {
        public string userid { get; set; }

        public string password { get; set; }

        public int applicationid { get; set; }

        public int schemeid { get; set; }

        public string memberid { get; set; }

        public int usertypeid { get; set; }

        public string usertype { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }
    }
}