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
    }
}