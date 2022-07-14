using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class DVDCategoryClass
    {
        // object for GlobalConnection of database connection

        GlobalConnection gc = new GlobalConnection();

        //add new dvd category
        public void AddDVDCategory(string CategoryDescription, string AgeRestricted)
        {

            SqlCommand cmd = new SqlCommand("Insert into dvd_category_table(Category_Description,Age_Restricted)values (@CategoryDescription,@AgeRestricted)", gc.cn);
            cmd.Parameters.AddWithValue("@CategoryDescription", CategoryDescription);
            cmd.Parameters.AddWithValue("@AgeRestricted", AgeRestricted);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }

        //geting all dvd category details
        public DataTable DisplayDVDCategoryRecords()
        {
            string sql = "SELECT * FROM dvd_category_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        //updating dvd category details
        public void UpdateDVDCategory(int CategoryNumber, string CategoryDescription, string AgeRestricted)
        {
            SqlCommand cmd = new SqlCommand("Update dvd_category_table set " +
                "Category_Description=@CategoryDescription,Age_Restricted=@AgeRestricted where Category_Number=@CategoryNumber", gc.cn);

            cmd.Parameters.AddWithValue("@CategoryDescription", CategoryDescription);
            cmd.Parameters.AddWithValue("@AgeRestricted", AgeRestricted);

            cmd.Parameters.AddWithValue("@CategoryNumber", CategoryNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        //deleting dvd category details
        public void DeleteDVDCategory(int CategoryNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from dvd_category_table where Category_Number=@CategoryNumber", gc.cn);
            cmd.Parameters.AddWithValue("@CategoryNumber", CategoryNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}