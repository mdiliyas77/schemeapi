using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace schemeapi.Models
{
    public class schemeservice
    {

        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;

        public schemeservice()
        {
            con = new MySqlConnection("server=localhost; port=3306; userid=root; password=root; database=schemes");
            con.Open();
        }

        public int loginverify(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res;
            string sql;
            if (objModel.usertype=="admin")
            {
                sql = string.Format("select count(*) from adminlogin where userid='{0}' and password='{1}'", objModel.userid, objModel.password);
                cmd.CommandText = sql;
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            else
            {
                sql = string.Format("select count(*) from member where memberid='{0}' and password='{1}'", objModel.userid, objModel.password);
                cmd.CommandText = sql;
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return res;
        }

        public int AddType(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res;
            string sql;
            string sqlcnt = string.Format("select count(*) from usertypes where usertype='{0}'", objModel.usertype.ToLower());
            cmd.CommandText = sqlcnt;
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            if (count==0)
            {
                sql = string.Format("insert into usertypes (usertype) value ('{0}')", objModel.usertype.ToLower());
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }

            con.Close();
            return res;
           
        }


        public DataTable GetType()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from usertypes");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public int EditSType(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("update usertypes set usertype='{0}' where usertypeid={1}",objModel.usertype.ToLower(), objModel.usertypeid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteSType(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("delete from usertypes where usertype='{0}' and usertypeid={1}", objModel.usertype, objModel.usertypeid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int AddSchemes(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("insert into govtschemes (usertype,schemetitle,schemedesc,startage,caste,maritialstatus,docs,gender,status,endage) value ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','running','{8}')", objModel.usertype, objModel.schemetitle,objModel.schemedesc,objModel.startage,objModel.caste,objModel.maritialstatus,objModel.docs, objModel.gender, objModel.endage);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }


        public DataTable GetAllScheme()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from govtschemes");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public int EditSchemes(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("update govtschemes set usertype='{0}',schemetitle='{1}', schemedesc='{2}', startage='{3}', caste='{4}', maritialstatus='{5}', docs='{6}',gender='{7}', status='{8}', endage='{9}' where schemeid={10}", objModel.usertype, objModel.schemetitle, objModel.schemedesc,objModel.startage, objModel.caste, objModel.maritialstatus, objModel.docs, objModel.gender, objModel.status, objModel.endage, objModel.schemeid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteSchemes(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("delete from govtschemes where schemeid={0}", objModel.schemeid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public DataTable GetAllMembers()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from member");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public int EditMembers(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("update member set name='{0}',usertype='{1}', address='{2}',aadhaarno={3}, phoneno={4}, age={5}, caste='{6}', maritialstatus='{7}', gender='{8}' where memberid='{9}'", objModel.name, objModel.usertype, objModel.address, objModel.aadhaarno,objModel.phoneno,objModel.age, objModel.caste, objModel.maritialstatus, objModel.gender, objModel.memberid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteMembers(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("delete from member where memberid='{0}'", objModel.memberid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public DataTable GetAllQueries()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from query q inner join govtschemes s on q.schemeid=s.schemeid inner join member m on q.memberid=m.memberid");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public int Reply(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("update query set reply='{0}' where queryid={1} and memberid='{2}'", objModel.reply, objModel.queryid, objModel.memberid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public string Register(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res;
            Random rnd = new Random();
            int rnduserid = rnd.Next(1000, 9999);
            int rndpass = rnd.Next(1000, 9999);
            string sqlcnt = string.Format("select count(*) from member where aadhaarno={0}", objModel.aadhaarno);
            cmd.CommandText = sqlcnt;
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            if (count==0)
            {
                string sql = string.Format("insert into member (memberid,password,name,usertype,address,aadhaarno,phoneno,age,caste,maritialstatus,gender) value ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},'{8}','{9}','{10}')", rnduserid, rndpass, objModel.name, objModel.usertype, objModel.address, objModel.aadhaarno, objModel.phoneno, objModel.age, objModel.caste, objModel.maritialstatus,objModel.gender);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res + "," + rnduserid + "," + rndpass;
        }


        public int AddCaste(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res;
            string sql;
            string sqlcnt = string.Format("select count(*) from caste where caste='{0}'", objModel.caste.ToLower());
            cmd.CommandText = sqlcnt;
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            if (count == 0)
            {
                sql = string.Format("insert into caste (caste) value ('{0}')", objModel.caste.ToLower());
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }

            con.Close();
            return res;

        }

        public DataTable GetMembers(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from member where memberid='{0}'",objModel.memberid);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetCaste()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from caste");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public int EditCaste(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("update caste set caste='{0}' where casteid={1}", objModel.caste.ToLower(), objModel.casteid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteCaste(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("delete from caste where casteid={0}",objModel.casteid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public DataTable GetMyScheme(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlmem = string.Format("select * from member where memberid='{0}'", objModel.memberid);
            cmd.CommandText = sqlmem;
            adp = new MySqlDataAdapter(cmd);
            DataTable memtab = new DataTable();
            adp.Fill(memtab);

            string sql = string.Format("select * from govtschemes where ((startage<='{0}' and endage>='{0}') or (startage='all' and endage='all')) and (caste='{1}' or caste='all') and (maritialstatus='{2}' or maritialstatus='all' ) and (usertype='{3}' or usertype='all') and (gender='{4}' or gender='all')", memtab.Rows[0]["age"], memtab.Rows[0]["caste"], memtab.Rows[0]["maritialstatus"], memtab.Rows[0]["usertype"], memtab.Rows[0]["gender"]);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string Application(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res;
            Random rnd = new Random();
            int rndid = rnd.Next(1000, 9999);

            L1:

            string sqlcheck = string.Format("select count(*) from applications where applicationid={0}", rndid);
            cmd.CommandText = sqlcheck;
            int checkcount = int.Parse(cmd.ExecuteScalar().ToString());
            if (checkcount > 0)

            {
                rndid = rnd.Next(1000, 9999);
                goto L1;
            }

            string sqlcnt = string.Format("select count(*) from applications where schemeid={0} and memberid='{1}'", objModel.schemeid,objModel.memberid);
            cmd.CommandText = sqlcnt;
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            if (count == 0)
            {
                string sql = string.Format("insert into applications(applicationid,schemeid,memberid,status) value ({0},{1},'{2}','pending')", rndid, objModel.schemeid, objModel.memberid);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res + "," + rndid;
        }

        public string AddQuery(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res;
            Random rnd = new Random();
            int rndid = rnd.Next(1000, 9999);

            L1:

            string sqlcheck = string.Format("select count(*) from query where queryid={0}", rndid);
            cmd.CommandText = sqlcheck;
            int checkcount = int.Parse(cmd.ExecuteScalar().ToString());
            if(checkcount>0)

            {
                rndid = rnd.Next(1000, 9999);
                goto L1;
            }

            string sqlcnt = string.Format("select count(*) from query where schemeid={0} and memberid='{1}'", objModel.schemeid, objModel.memberid);
            cmd.CommandText = sqlcnt;
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            if (count == 0)
            {
                string sql = string.Format("insert into query(queryid,schemeid,memberid,query) value ({0},{1},'{2}','{3}')", rndid, objModel.schemeid, objModel.memberid, objModel.query);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            con.Close();
            return res + "," + rndid;
        }

        public int DeleteQueries(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("delete from query where queryid={0} and memberid='{1}'", objModel.queryid,objModel.memberid);
            cmd.CommandText = sql;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public DataTable GetApps()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select * from applications a inner join member m on a.memberid=m.memberid inner join govtschemes s on a.schemeid=s.schemeid");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public int ActionApp(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql;
            int res;

            if (objModel.condition=="approve")
            {
                sql = string.Format("update applications set status='approved' where applicationid={0} and memberid={1}", objModel.applicationid, objModel.memberid);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery();
            }

            else if (objModel.condition == "delete")
            {
                sql = string.Format("delete from applications where applicationid={0} and memberid={1}", objModel.applicationid, objModel.memberid);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery()+2;
            }
            else
            {
                sql = string.Format("update applications set status='rejected' where applicationid={0} and memberid={1}", objModel.applicationid, objModel.memberid);
                cmd.CommandText = sql;
                res = cmd.ExecuteNonQuery()+1;
            }

            con.Close();
            return res;
        }


        public string DownloadImg(schememodel objModel)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string name=null;
            string base64=null;
            int res=0;
            string sql = string.Format("select image from applications where applicationid={0}", objModel.applicationid);
            cmd.CommandText = sql;
            byte[] byteFile = (byte[])cmd.ExecuteScalar();
            if (byteFile!=null)
            {

            res = 1;
            base64 = Convert.ToBase64String(byteFile);

            sql = string.Format("select imagename from applications where applicationid={0}", objModel.applicationid);
            cmd.CommandText = sql;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            name = tab.Rows[0]["name"].ToString();
            con.Close();

            }
            else
            {
                res = 2;
            }

            return res + "," + base64 +","+ name;
        }
    }
}