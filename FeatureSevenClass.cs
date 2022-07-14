using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace GroupCoursework
{
    public class FeatureSevenClass
    {
        GlobalConnection gc = new GlobalConnection();

        public DataTable DisplayRecords()
        {
            string sql = "SELECT * FROM loan_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];


        }

        public void Update(string LoanNumber, string DateReturn)
        {
            SqlCommand cmd = new SqlCommand("Update loan_table set " +
                "Date_Returned=@DateReturn where Loan_Number=@LoanNumber", gc.cn);
            cmd.Parameters.AddWithValue("@LoanNumber", LoanNumber);
            cmd.Parameters.AddWithValue("@DateReturn", DateReturn);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

    }
}