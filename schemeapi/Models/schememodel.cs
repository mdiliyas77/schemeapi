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

        public string schemetype { get; set; }

        public string schemetitle { get; set; }

        public string schemedesc { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public int aadhaarno { get; set; }

        public int phoneno { get; set; }

        public int queryid { get; set; }

        public string query { get; set; }

        public string reply { get; set; }
    }
}