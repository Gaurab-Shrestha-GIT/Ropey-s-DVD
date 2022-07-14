using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class AssistantDetailsClass
    {
        // object for GlobalConnection of database connection
        GlobalConnection gc = new GlobalConnection();

        string aa = "Assistant";

        //adding new assistant
        public void AddAssistant(string UserName, string UserPassword)
        {

            SqlCommand cmd = new SqlCommand("Insert into user_table(UserName,UserType, UserPassword)values (@UserName, @UserType, @UserPassword)", gc.cn);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@UserType", aa);
            cmd.Parameters.AddWithValue("@UserPassword", UserPassword);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }

        //displaying details of assistant
        public DataTable DisplayRecords()
        {
            string sql = "SELECT * FROM user_table where UserType ='Assistant'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];


        }

        //delete assistant details
        public void Delete(int UserNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from user_table where UserNumber=@UserNumber", gc.cn);
            cmd.Parameters.AddWithValue("@UserNumber", UserNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}