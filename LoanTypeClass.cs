using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class LoanTypeClass
    {

        GlobalConnection gc = new GlobalConnection();


        public void AddLoanType(string LoanType, int LoanDuration)
        {

            SqlCommand cmd = new SqlCommand("Insert into loan_type_table(Loan_Type,Loan_Duration)values (@LoanType,@LoanDuration)", gc.cn);
            cmd.Parameters.AddWithValue("@LoanType", LoanType);
            cmd.Parameters.AddWithValue("@LoanDuration", LoanDuration);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }
        public DataTable DisplayLoanTypeRecords()
        {
            string sql = "SELECT * FROM loan_type_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public void UpdateLoanType(int LoanTypeNumber, string LoanType, int LoanDuration)
        {
            SqlCommand cmd = new SqlCommand("Update loan_type_table set " +
                "Loan_Type=@LoanType,Loan_Duration=@LoanDuration where Loan_Type_Number=@LoanTypeNumber", gc.cn);
            cmd.Parameters.AddWithValue("@LoanType", LoanType);
            cmd.Parameters.AddWithValue("@LoanDuration", LoanDuration);

            cmd.Parameters.AddWithValue("@LoanTypeNumber", LoanTypeNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
        public void DeleteLoanType(int LoanTypeNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from actor_table where Loan_Type_Number=@LoanTypeNumber", gc.cn);
            cmd.Parameters.AddWithValue("@LoanTypeNumber", LoanTypeNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}