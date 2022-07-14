using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class FeatureThirteenClass
    {
        GlobalConnection gc = new GlobalConnection();
        public DataTable DisplayRecords()
        {
            string sql = "Select dt.DVD_Title From dvd_title_table dt JOIN dvd_copy_table dc ON dt.DVD_Number = dc.DVD_Number JOIN loan_table lt ON dc.Copy_Number = lt.Copy_Number Where dt.DVD_Title NOT IN (SELECT dt.DVD_Title FROM dvd_title_table dt JOIN dvd_copy_table dc ON dt.DVD_Number = dc.DVD_Number  JOIN loan_table lt ON dc.Copy_number = lt.Copy_Number Where lt.Date_Out >= CURRENT_TIMESTAMP - 31) ";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
    }
}