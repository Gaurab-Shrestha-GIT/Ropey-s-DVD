using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class UserClass
    {

        GlobalConnection gc = new GlobalConnection();

        //details for assistant
        public DataTable CheckAssistant(string UserName, string UserPassword, string UserType)
        {
            string sql = "SELECT * FROM user_table where UserName = '" + UserName + "' and UserPassword = '" + UserPassword + "' and UserType = '" + UserType + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, gc.cn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "user_table");
            return dataSet.Tables[0];
        }

        //details for manager
        public DataTable CheckManager(string UserName, string UserPassword, string UserType)
        {
            string sql = "SELECT * FROM user_table where UserName = '" + UserName + "' and UserPassword = '" + UserPassword + "' and UserType = '" + UserType + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, gc.cn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "user_table");
            return dataSet.Tables[0];
        }

        //change manager password
        public void ChangeManagerPassword(int UserNumber, string UserPassword)
        {
            SqlCommand cmd = new SqlCommand("UPDATE user_table set UserPassword = @UserPassword where UserNumber = @UserNumber", gc.cn);
            cmd.Parameters.AddWithValue("@UserNumber", UserNumber);
            cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        //change assistant password
        public void ChangeAssistantPassword(int UserNumber, string UserPassword)
        {
            SqlCommand cmd = new SqlCommand("UPDATE user_table set UserPassword = @UserPassword where UserNumber = @UserNumber", gc.cn);
            cmd.Parameters.AddWithValue("@UserNumber", UserNumber);
            cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

    }
}