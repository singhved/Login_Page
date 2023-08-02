using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Login_Page.Models
{
    public class AllProcs
    {
        //Create connection along with DBContext File
        public static string Getconnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ADSContext"].ConnectionString;
            }
        }

        //cmd.ExecuteNonQuery(); Execute Procedure in sql and does not take back any value from SQL.
        //Calling a procedure
        public static string CheckUser(string uid, string pwd)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("CheckUser", con);
            cmd.Parameters.AddWithValue("@uid", uid);
            //cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.CommandType = CommandType.StoredProcedure;
            string res = "-1";
            try
            {
                con.Open();
                var r = cmd.ExecuteScalar(); //Execute Procedure and return a single value from sql.
                if (r != null)
                {
                    res = r.ToString();
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return res;
        }

        public static Boolean AuthenticateUser
        {
            get
            {
                string uid = Cookies.GetUserDetails.Userid;
                string pwd = Cookies.GetUserDetails.Password;
                string res = CheckUser(uid, pwd);
                if (Convert.ToInt32(res) > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}