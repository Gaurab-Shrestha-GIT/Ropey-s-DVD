using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class DVDTitleClass
    {

        GlobalConnection gc = new GlobalConnection();

        public void AddDVDTitle(int CategoryNumber, int StudioNumber, int ProducerNumber, string DVDTitle, DateTime DateReleased, int StandardCharge, int PenaltyCharge)
        {

            SqlCommand cmd = new SqlCommand("Insert into dvd_title_table(Category_Number,Studio_Number, Producer_Number, DVD_Title, Date_Released, Standard_Charge, Penalty_Charge)values (@CategoryNumber,@StudioNumber, @ProducerNumber, @DVDTitle, @DateReleased, @StandardCharge, @PenaltyCharge)", gc.cn);
            cmd.Parameters.AddWithValue("@CategoryNumber", CategoryNumber);
            cmd.Parameters.AddWithValue("@StudioNumber", StudioNumber);
            cmd.Parameters.AddWithValue("@ProducerNumber", ProducerNumber);
            cmd.Parameters.AddWithValue("@DVDTitle", DVDTitle);
            cmd.Parameters.AddWithValue("@DateReleased", DateReleased);
            cmd.Parameters.AddWithValue("@StandardCharge", StandardCharge);

            cmd.Parameters.AddWithValue("@PenaltyCharge", PenaltyCharge);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }


        public DataTable DisplayDVDTitleRecords()
        {
            string sql = "SELECT * FROM dvd_title_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
        public void UpdateDVDTitle(int DVDNumber, int CategoryNumber, int StudioNumber, int ProducerNumber, string DVDTitle, DateTime DateReleased, int StandardCharge, int PenaltyCharge)
        {
            SqlCommand cmd = new SqlCommand("Update dvd_title_table set " +
                "Category_Number=@CategoryNumber,Studio_Number=@StudioNumber, Producer_Number=@ProducerNumber, DVD_Title=@DVDTitle, Date_Released=@DateReleased, Standard_Charge=@StandardCharge, Penalty_Charge=@PenaltyCharge where DVD_Number=@DVDNumber", gc.cn);

            cmd.Parameters.AddWithValue("@CategoryNumber", CategoryNumber);
            cmd.Parameters.AddWithValue("@StudioNumber", StudioNumber);
            cmd.Parameters.AddWithValue("@ProducerNumber", ProducerNumber);
            cmd.Parameters.AddWithValue("@DVDTitle", DVDTitle);
            cmd.Parameters.AddWithValue("@DateReleased", DateReleased);
            cmd.Parameters.AddWithValue("@StandardCharge", StandardCharge);


            cmd.Parameters.AddWithValue("@PenaltyCharge", PenaltyCharge);
            cmd.Parameters.AddWithValue("@DVDNumber", DVDNumber);

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