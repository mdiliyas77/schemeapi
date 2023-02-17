using schemeapi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace schemeapi.Controllers
{
    public class schemeController : ApiController
    {

        [Route("Api/Schemes/Login")]
        [HttpPost]

        public schememodel Login(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.loginverify(objModel);
            if (result==1)
            {
                return new schememodel { Status = "Success", Message = "Success" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Userid & Password is Incorrect" };
            }
        }

        [Route("Api/Schemes/AddUserType")]
        [HttpPost]

        public schememodel AddUserType(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.AddType(objModel);
            if (result==1)
            {
                return new schememodel { Status = "Success", Message = "Scheme Type Added Successfully" };
            }
            else if(result==2)
            {
                return new schememodel { Status = "Error", Message = "Scheme Type Already Added" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        List<schememodel> typelist = new List<schememodel>();
        [Route("Api/Schemes/GetUserTypes")]
        [HttpGet]

        public IEnumerable<schememodel> GetUserTypes()
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetType();
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                typelist.Add(new schememodel
                {
                    usertypeid = int.Parse(tab.Rows[i]["usertypeid"].ToString()),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    
                });
            }
            return typelist;
        }
    }
}
