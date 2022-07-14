using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace GroupCoursework
{
    public class FeatureElevenClass
    {
        GlobalConnection gc = new GlobalConnection();
        public DataTable DisplayRecords()
        {
            string sql = "SELECT lt.Copy_Number, mt.Member_First_Name, mt.Member_Last_Name, dt.DVD_Title FROM loan_table lt INNER JOIN member_table mt ON lt.Member_Number = mt.Member_Number INNER JOIN dvd_copy_table dc ON lt.Copy_Number = dc.Copy_Number INNER JOIN dvd_title_table dt ON dc.DVD_Number = dt.DVD_Number AND lt.Date_Returned IS NULL ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
    }
}