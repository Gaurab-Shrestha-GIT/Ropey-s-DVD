using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class StudioClass
    {
        GlobalConnection gc = new GlobalConnection();


        public void AddStudio(string StudioName)
        {

            SqlCommand cmd = new SqlCommand("Insert into studio_table(Studio_Name)values (@StudioName)", gc.cn);
            cmd.Parameters.AddWithValue("@StudioName", StudioName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }

        public DataTable DisplayStudioRecords()
        {
            string sql = "SELECT * FROM studio_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public void UpdateStudio(int StudioNumber, string StudioName)
        {
            SqlCommand cmd = new SqlCommand("Update studio_table set " +
                "Studio_Name=@StudioName where Studio_Number=@StudioNumber", gc.cn);
            cmd.Parameters.AddWithValue("@StudioName", StudioName);

            cmd.Parameters.AddWithValue("@StudioNumber", StudioNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteStudio(int StudioNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from studio_table where Studio_Number=@StudioNumber", gc.cn);
            cmd.Parameters.AddWithValue("@StudioNumber", StudioNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}