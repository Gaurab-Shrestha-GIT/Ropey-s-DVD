using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class ProducerClass
    {

        GlobalConnection gc = new GlobalConnection();


        public void AddProducer(string ProducerName)
        {

            SqlCommand cmd = new SqlCommand("Insert into producer_table(Producer_Name)values (@ProducerName)", gc.cn);
            cmd.Parameters.AddWithValue("@ProducerName", ProducerName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }

        public DataTable DisplayStudioRecords()
        {
            string sql = "SELECT * FROM producer_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public void UpdateProducer(int ProducerNumber, string ProducerName)
        {
            SqlCommand cmd = new SqlCommand("Update producer_table set " +
                "Producer_Name=@ProducerName where Producer_Number=@ProducerNumber", gc.cn);
            cmd.Parameters.AddWithValue("@ProducerName", ProducerName);

            cmd.Parameters.AddWithValue("@ProducerNumber", ProducerNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteProducer(int ProducerNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from producer_table where Producer_Number=@ProducerNumber", gc.cn);
            cmd.Parameters.AddWithValue("@ProducerNumber", ProducerNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}