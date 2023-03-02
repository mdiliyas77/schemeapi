using schemeapi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using MySql.Data.MySqlClient;

namespace schemeapi.Controllers
{
    public class schemeController : ApiController
    {

        MySqlConnection con = null;
        MySqlCommand cmd = null;

        public schemeController()
        {
            con = new MySqlConnection("server=localhost;database=schemes;user id=root;password=root;port=3306;");
            con.Open();
        }

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
                    startage = tab.Rows[i]["startage"].ToString(),
                    endage = tab.Rows[i]["endage"].ToString(),
                    caste = tab.Rows[i]["caste"].ToString(),
                    maritialstatus = tab.Rows[i]["maritialstatus"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    schemetitle = tab.Rows[i]["schemetitle"].ToString(),
                    schemedesc = tab.Rows[i]["schemedesc"].ToString(),
                    docs = tab.Rows[i]["docs"].ToString(),
                    gender = tab.Rows[i]["gender"].ToString(),
                    status = tab.Rows[i]["status"].ToString(),

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
                    maritialstatus = tab.Rows[i]["maritialstatus"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    address = tab.Rows[i]["address"].ToString(),
                    aadhaarno = long.Parse(tab.Rows[i]["aadhaarno"].ToString()),
                    age = int.Parse(tab.Rows[i]["age"].ToString()),
                    phoneno = long.Parse(tab.Rows[i]["phoneno"].ToString()),
                    gender = tab.Rows[i]["gender"].ToString(),
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

        [Route("Api/Schemes/DeleteQuery")]
        [HttpPost()]
        public schememodel DeleteQuery(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.DeleteQueries(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Success", Message = "Query Deleted Successfully" };
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
                return new schememodel { Status = "Success", Message = "Member Id :" + result.Split(',')[1] + ", Password : "+ result.Split(',')[2] };
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
                    startage = tab.Rows[i]["startage"].ToString(),
                    endage = tab.Rows[i]["endage"].ToString(),
                    caste = tab.Rows[i]["caste"].ToString(),
                    maritialstatus = tab.Rows[i]["maritialstatus"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    schemetitle = tab.Rows[i]["schemetitle"].ToString(),
                    schemedesc = tab.Rows[i]["schemedesc"].ToString(),
                    docs = tab.Rows[i]["docs"].ToString(),
                    gender = tab.Rows[i]["gender"].ToString(),
                    status = tab.Rows[i]["status"].ToString(),

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
                    maritialstatus = tab.Rows[i]["maritialstatus"].ToString(),
                    usertype = tab.Rows[i]["usertype"].ToString(),
                    address = tab.Rows[i]["address"].ToString(),
                    aadhaarno = long.Parse(tab.Rows[i]["aadhaarno"].ToString()),
                    age = int.Parse(tab.Rows[i]["age"].ToString()),
                    phoneno = long.Parse(tab.Rows[i]["phoneno"].ToString()),
                    gender = tab.Rows[i]["gender"].ToString(),
                });
            }
            return mlist;
        }


        [Route("Api/Schemes/Apply")]
        [HttpPost()]
        public schememodel Apply(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            string result = db.Application(objModel);
            if (result.Split(',')[0] == "1")
            {
                return new schememodel { Status = "Success", Message = result.Split(',')[1]};
            }
            else if (result.Split(',')[0] == "2")
            {
                return new schememodel { Status = "Exist", Message = "Already Applied" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }


        [Route("Api/Schemes/AddQuery")]
        [HttpPost()]
        public schememodel AddQuery(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            string result = db.AddQuery(objModel);
            if (result.Split(',')[0] == "1")
            {
                return new schememodel { Status = "Success", Message = result.Split(',')[1] };
            }
            else if (result.Split(',')[0] == "2")
            {
                return new schememodel { Status = "Exist", Message = "Query Posted Already" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }


        List<schememodel> applist = new List<schememodel>();
        [Route("Api/Schemes/GetAllApps")]
        [HttpGet]
        public IEnumerable<schememodel> GetAllApps()
        {
            schemeservice db = new schemeservice();
            DataTable tab = new DataTable();
            tab = db.GetApps();
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                applist.Add(new schememodel
                {
                    applicationid = int.Parse(tab.Rows[i]["applicationid"].ToString()),
                    schemeid = int.Parse(tab.Rows[i]["schemeid"].ToString()),
                    memberid = tab.Rows[i]["memberid"].ToString(),
                    schemetitle = tab.Rows[i]["schemetitle"].ToString(),
                    name = tab.Rows[i]["name"].ToString(),
                    appstatus = tab.Rows[i]["status"].ToString(),
                    gender = tab.Rows[i]["gender"].ToString(),
                });
            }
            return applist;
        }

        [Route("Api/Schemes/ActionOnApp")]
        [HttpPost()]

        public schememodel ActionOnApp(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            int result = db.ActionApp(objModel);
            if (result == 1)
            {
                return new schememodel { Status = "Approved", Message = "Application Approved" };
            }
            else if (result == 2)
            {
                return new schememodel { Status = "Rejected", Message = "Application Rejected" };
            }
            else if (result == 3)
            {
                return new schememodel { Status = "Deleted", Message = "Application Successfully Deleted!!" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }
        }

        [Route("Api/Schemes/Download")]
        [HttpPost()]

        public schememodel Download(schememodel objModel)
        {
            schemeservice db = new schemeservice();
            string result = db.DownloadFile(objModel);
            if (result.Split(',')[0] == "1")
            {
                return new schememodel { Status = "Success", base64String = result.Split(',')[1], name = result.Split(',')[2], Message = "File Downloaded" };
            }
            else if (result.Split(',')[0] == "2")
            {
                return new schememodel { Status = "Error", Message = "File Not Found" };
            }
            else
            {
                return new schememodel { Status = "Error", Message = "Error" };
            }

        }


        [Route("Api/Schemes/UploadFiles")]
        [HttpPost()]
        public IHttpActionResult UploadFiles()
        { 
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            schememodel objModel = new schememodel();
            objModel.filetype = HttpContext.Current.Request.Form["filetype"];
            objModel.applicationid = Convert.ToInt32(HttpContext.Current.Request.Form["applicationid"]);
            int res = 0;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    byte[] fileData;
                    string Name;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        hpf.InputStream.CopyTo(ms);
                        fileData = ms.ToArray();
                        Name = hpf.FileName;
                    }

                        cmd = new MySqlCommand();
                        cmd.Connection = con;
                        string sql = string.Format("update applications set filename = @name, file = @data where applicationid = @id");
                        cmd.CommandText = sql;

                        cmd.Parameters.Add("@data", MySqlDbType.Blob).Value = fileData;
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@id", objModel.applicationid);
                        res = cmd.ExecuteNonQuery();
                    
                }
            }
            con.Close();
            if(res == 1)
            {
                return Ok("Upload successful.");
            }
            else
                return Ok("Upload failed.");

        }
    }
}
