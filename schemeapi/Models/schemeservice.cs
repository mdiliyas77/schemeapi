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
            string sql = string.Format("insert into govtschemes (schemetype,schemetitle,schemedesc) value ('{0}','{1}','{2}')", objModel.schemetype,objModel.schemetitle,objModel.schemedesc);
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
            string sql = string.Format("update govtschemes set schemetype='{0}',schemetitle='{1}', schemedesc='{2}' where schemeid={3}", objModel.schemetype, objModel.schemetitle, objModel.schemedesc,objModel.schemeid);
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
            string sql = string.Format("select * from member m inner join usertypes u on m.usertypeid=u.usertypeid");
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
            string sql = string.Format("update member set name='{0}',usertypeid={1}, address='{2}',aadhaarno={3}, phoneno={4} where memberid='{5}'", objModel.name, objModel.usertypeid, objModel.address, objModel.aadhaarno,objModel.phoneno,objModel.memberid);
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
    }
}