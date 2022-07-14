using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class DVDCopyClass

    {
        // object for GlobalConnection of database connection
        GlobalConnection gc = new GlobalConnection();

        //add new dvd copy
        public void AddDVDCopy(int DVDNumber, DateTime DatePurchased)
        {

            SqlCommand cmd = new SqlCommand("Insert into dvd_copy_table(DVD_Number,Date_Purchased)values (@DVDNumber,@DatePurchased)", gc.cn);
            cmd.Parameters.AddWithValue("@DVDNumber", DVDNumber);
            cmd.Parameters.AddWithValue("@DatePurchased", DatePurchased);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }

        //getting dvd category details
        public DataTable DisplayDVDCopyRecords()
        {
            string sql = "SELECT * FROM dvd_copy_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        //update dvd copy details
        public void UpdateDVDCopy(int CopyNumber, int DVDNumber, DateTime DatePurchased)
        {
            SqlCommand cmd = new SqlCommand("Update dvd_copy_table set " +
                "DVD_Number=@DVDNumber, Date_Purchased=@DatePurchased where Copy_Number=@CopyNumber", gc.cn);

            cmd.Parameters.AddWithValue("@CopyNumber", CopyNumber);
            cmd.Parameters.AddWithValue("@DVDNumber", DVDNumber);
            cmd.Parameters.AddWithValue("@DatePurchased", DatePurchased);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        //delete dvd copy details
        public void DeleteDVDCopy(int CopyNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from dvd_copy_table where Copy_Number=@CopyNumber", gc.cn);
            cmd.Parameters.AddWithValue("@CopyNumber", CopyNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        //getting records
        public DataTable DisplayRecords()
        {

            string sql = "SELECT dc.Copy_Number, dc.DVD_Number, dc.Date_Purchased From dvd_copy_table dc JOIN loan_table lt ON dc.Copy_Number = lt.Copy_Number Where dc.Date_Purchased <= CURRENT_TIMESTAMP -365  ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];

        }
    }
}