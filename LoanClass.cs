using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class LoanClass
    {
        GlobalConnection gc = new GlobalConnection();

        //public void AddLoan(int LoanTypeNumber, int CopyNumber, int MemberNumber, string DateOut, string DateDue, string DateReturned)
        //{

        //    SqlCommand cmd = new SqlCommand("Insert into loan_table(Loan_Type_Number,Copy_Number, Member_Number, Date_Out, Date_Due, Date_Returned)values (@LoanTypeNumber,@CopyNumber, @MemberNumber, @DateOut, @DateDue, @DateReturned)", gc.cn);
        //    cmd.Parameters.AddWithValue("@LoanTypeNumber", LoanTypeNumber);
        //    cmd.Parameters.AddWithValue("@CopyNumber", CopyNumber);
        //    cmd.Parameters.AddWithValue("@MemberNumber", MemberNumber);
        //    cmd.Parameters.AddWithValue("@DateOut", DateOut);
        //    cmd.Parameters.AddWithValue("@DateDue", DateDue);

        //    cmd.Parameters.AddWithValue("@DateReturned", DateReturned);

        //    cmd.ExecuteNonQuery();
        //    gc.cn.Close();

        //}

        public void AddLoann(int LoanTypeNumber, int CopyNumber, int MemberNumber, string DateOut, string DateDue)
        {

            SqlCommand cmd = new SqlCommand("Insert into loan_table(Loan_Type_Number,Copy_Number, Member_Number, Date_Out, Date_Due)values (@LoanTypeNumber,@CopyNumber, @MemberNumber, @DateOut, @DateDue)", gc.cn);
            cmd.Parameters.AddWithValue("@LoanTypeNumber", LoanTypeNumber);
            cmd.Parameters.AddWithValue("@CopyNumber", CopyNumber);
            cmd.Parameters.AddWithValue("@MemberNumber", MemberNumber);
            cmd.Parameters.AddWithValue("@DateOut", DateOut);
            cmd.Parameters.AddWithValue("@DateDue", DateDue);


            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }


        public DataTable DisplayLoanRecords()
        {
            string sql = "SELECT * FROM loan_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
        public void UpdateLoan(int LoanNumber, int LoanTypeNumber, int CopyNumber, int MemberNumber, string DateOut, string DateDue, string DateReturned)
        {
            SqlCommand cmd = new SqlCommand("Update loan_table set " +
                "Loan_Type_Number=@LoanTypeNumber,Copy_Number=@CopyNumber, Member_Number=@MemberNumber, Date_Out=@DateOut, Date_Due=@DateDue, Date_Returned=@DateReturned where Loan_Number=@LoanNumber", gc.cn);

            cmd.Parameters.AddWithValue("@LoanTypeNumber", LoanTypeNumber);
            cmd.Parameters.AddWithValue("@CopyNumber", CopyNumber);
            cmd.Parameters.AddWithValue("@MemberNumber", MemberNumber);
            cmd.Parameters.AddWithValue("@DateOut", DateOut);
            cmd.Parameters.AddWithValue("@DateDue", DateDue);

            cmd.Parameters.AddWithValue("@DateReturned", DateReturned);
            cmd.Parameters.AddWithValue("@LoanNumber", LoanNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
        //public void DeleteDVDCategory(int DVDNumber)
        //{
        //    SqlCommand cmd = new SqlCommand("Delete from dvd_title_table where DVD_Number=@DVDNumber", gc.cn);
        //    cmd.Parameters.AddWithValue("@DVDNumber", DVDNumber);
        //    cmd.ExecuteNonQuery();
        //    gc.cn.Close();
        //}
    }
}