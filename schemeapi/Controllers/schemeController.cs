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

        [Route("Api/Schemes/EditSchemeType")]
        [HttpPost()]

        public schememodel EditSchemeType(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.EditSType(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Scheme Type Updated" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/DeleteSchemeType")]
        [HttpPost()]

        public schememodel DeleteSchemeType(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.DeleteSType(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Scheme Type Deleted" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/AddScheme")]
        [HttpPost]

        public schememodel AddScheme(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.AddSchemes(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Scheme Added Successfully" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        List<schememodel> allschemelist = new List<schememodel>();
        [Route("Api/Schemes/GetAllSchemes")]
        [HttpGet]

        public IEnumerable<schememodel> GetAllSchemes()
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetAllScheme();
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                allschemelist.Add(new schememodel
                {
                    schemeid = int.Parse(tab.Rows[i]["schemeid"].ToString()),
                    schemetype = tab.Rows[i]["schemetype"].ToString(),
                    schemetitle = tab.Rows[i]["schemetitle"].ToString(),
                    schemedesc = tab.Rows[i]["schemedesc"].ToString(),

                });
            }
            return allschemelist;
        }

        [Route("Api/Schemes/EditScheme")]
        [HttpPost()]

        public schememodel EditScheme(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.EditSchemes(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Scheme Updated" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/DeleteScheme")]
        [HttpPost()]

        public schememodel DeleteScheme(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.DeleteSchemes(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Scheme Deleted" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        List<schememodel> memberlist = new List<schememodel>();
        [Route("Api/Schemes/GetMembers")]
        [HttpGet]

        public IEnumerable<schememodel> GetMembers()
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetAllMembers();
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                memberlist.Add(new schememodel
                {
                    memberid = tab.Rows[i]["memberid"].ToString(),
                    password = tab.Rows[i]["password"].ToString(),
                    name = tab.Rows[i]["name"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    usertypeid = int.Parse(tab.Rows[i]["usertypeid"].ToString()),
                    address = tab.Rows[i]["address"].ToString(),
                    aadhaarno = int.Parse(tab.Rows[i]["aadhaarno"].ToString()),
                    phoneno = int.Parse(tab.Rows[i]["phoneno"].ToString()),
                });
            }
            return memberlist;
        }


        [Route("Api/Schemes/EditMember")]
        [HttpPost()]
        public schememodel EditMember(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.EditMembers(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Member Updated" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/DeleteMember")]
        [HttpPost()]

        public schememodel DeleteMember(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.DeleteMembers(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Member Deleted" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }
    }
}
