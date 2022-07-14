using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class FeatureTwelveClass
    {
        GlobalConnection gc = new GlobalConnection();
        public DataTable DisplayRecords()
        {


            string sql = "Select mt.Member_Number, mt.Member_First_Name, mt.Member_Last_Name, DATEDIFF(day, lt.Date_Out, CURRENT_TIMESTAMP) AS 'Days count' From member_table mt JOIN loan_table lt ON mt.Member_Number = lt.Member_Number where mt.Member_Number NOT IN(Select mt.Member_Number from member_table mt JOIN loan_table lt ON mt.Member_Number = lt.Member_Number Where lt.Date_Out >= CURRENT_TIMESTAMP - 31 AND lt.Date_Returned IS NOT NULL)";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];


        }
    }
}