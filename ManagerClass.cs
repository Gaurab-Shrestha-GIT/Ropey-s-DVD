using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class ManagerClass
    {

        GlobalConnection gc = new GlobalConnection();


        public DataTable SelectRecords()
        {

            string sql = "SELECT * FROM manager_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable CheckManager(string Username, string Password)
        {
            string sqlQuery = "SELECT * FROM manager_table where Username = '" + Username + "' and Password = '" + Password + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, gc.cn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "manager_table");
            return dataSet.Tables[0];
        }

        public void ChangePassword(string Username, string Password)
        {
            SqlCommand cmd = new SqlCommand("UPDATE manager_table set Password = @Password where Username = @Username", gc.cn);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}