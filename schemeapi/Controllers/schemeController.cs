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
                    age = int.Parse(tab.Rows[i]["age"].ToString()),
                    caste = tab.Rows[i]["caste"].ToString(),
                    maritialstatus = tab.Rows[i]["maritialstatus"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    schemetitle = tab.Rows[i]["schemetitle"].ToString(),
                    schemedesc = tab.Rows[i]["schemedesc"].ToString(),
                    docs = tab.Rows[i]["docs"].ToString(),

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
                    caste = tab.Rows[i]["caste"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    address = tab.Rows[i]["address"].ToString(),
                    aadhaarno = int.Parse(tab.Rows[i]["aadhaarno"].ToString()),
                    age = int.Parse(tab.Rows[i]["age"].ToString()),
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


        List<schememodel> allquerylist = new List<schememodel>();
        [Route("Api/Schemes/GetAllQuery")]
        [HttpGet]
        public IEnumerable<schememodel> GetAllQuery()
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetAllQueries();
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                allquerylist.Add(new schememodel
                {
                    queryid = int.Parse(tab.Rows[i]["queryid"].ToString()),
                    schemeid = int.Parse(tab.Rows[i]["schemeid"].ToString()),
                    schemetitle = tab.Rows[i]["schemetitle"].ToString(),
                    memberid = tab.Rows[i]["memberid"].ToString(),
                    name = tab.Rows[i]["name"].ToString(),
                    query = tab.Rows[i]["query"].ToString(),
                    reply = tab.Rows[i]["reply"].ToString(),
                });
            }
            return allquerylist;
        }

        [Route("Api/Schemes/GiveReply")]
        [HttpPost()]
        public schememodel GiveReply(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.Reply(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Replied Successfully" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/MemberRegister")]
        [HttpPost()]
        public schememodel MemberRegister(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            string result = db.Register(objModel);
            if (result.Split(',')[0] == "1")
            {
                return new schememodel { Status = "Success", Message = "Member Id :" + result.Split(',')[1] + ", Password : "+ result.Split(',')[1] };
            }
            else if (result.Split(',')[0] == "2")
            {
                return new schememodel { Status = "Success", Message = "Member Already Registered" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/AddCastes")]
        [HttpPost]

        public schememodel AddCastes(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.AddCaste(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Caste Added Successfully" };
            }
            else if (result == 2)
            {
                return new schememodel { Status = "Error", Message = "Caste Already Added" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        List<schememodel> castelist = new List<schememodel>();
        [Route("Api/Schemes/GetCastes")]
        [HttpGet]

        public IEnumerable<schememodel> GetCastes()
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetCaste();
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                castelist.Add(new schememodel
                {
                    casteid = int.Parse(tab.Rows[i]["casteid"].ToString()),
                    caste = tab.Rows[i]["caste"].ToString(),

                });
            }
            return castelist;
        }

        [Route("Api/Schemes/EditCastes")]
        [HttpPost()]

        public schememodel EditCastes(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.EditCaste(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Caste Updated" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/DeleteCastes")]
        [HttpPost()]

        public schememodel DeleteCastes(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.DeleteCaste(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Caste Deleted" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        List<schememodel> myschemelist = new List<schememodel>();
        [Route("Api/Schemes/GetMySchemes")]
        [HttpPost]

        public IEnumerable<schememodel> GetMySchemes(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetMyScheme(objModel);
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                myschemelist.Add(new schememodel
                {
                    schemeid = int.Parse(tab.Rows[i]["schemeid"].ToString()),
                    age = int.Parse(tab.Rows[i]["age"].ToString()),
                    caste = tab.Rows[i]["caste"].ToString(),
                    maritialstatus = tab.Rows[i]["maritialstatus"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    schemetitle = tab.Rows[i]["schemetitle"].ToString(),
                    schemedesc = tab.Rows[i]["schemedesc"].ToString(),
                    docs = tab.Rows[i]["docs"].ToString(),

                });
            }
            return myschemelist;
        }

        List<schememodel> mlist = new List<schememodel>();
        [Route("Api/Schemes/GetMemberById")]
        [HttpPost]
        public IEnumerable<schememodel> GetMemberById(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetMembers(objModel);
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                mlist.Add(new schememodel
                {
                    memberid = tab.Rows[i]["memberid"].ToString(),
                    password = tab.Rows[i]["password"].ToString(),
                    name = tab.Rows[i]["name"].ToString(),
                    caste = tab.Rows[i]["caste"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    address = tab.Rows[i]["address"].ToString(),
                    aadhaarno = int.Parse(tab.Rows[i]["aadhaarno"].ToString()),
                    age = int.Parse(tab.Rows[i]["age"].ToString()),
                    phoneno = int.Parse(tab.Rows[i]["phoneno"].ToString()),
                });
            }
            return mlist;
        }
    }
}
