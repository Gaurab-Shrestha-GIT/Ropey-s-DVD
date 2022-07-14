using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class FeatureTenClass
    {

        GlobalConnection gc = new GlobalConnection();

        //display data about dvd which are more than a year old and not currently on loan
        public DataTable DisplayRecords()
        {
            string sql = "Select dc.Copy_Number, dc.DVD_Number, dc.Date_Purchased from dvd_copy_table dc Where dc.Date_Purchased < CURRENT_TIMESTAMP - 365 AND dc.Copy_Number NOT IN (Select lt.Copy_Number From loan_table lt Where lt.Date_Returned IS NULL) ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        //delete the dvd
        public void DeleteDVD()
        {
            string deleteFromLoanTable = "DELETE from loan_table WHERE Copy_Number IN (Select Copy_Number from dvd_copy_table Where Date_Purchased < CURRENT_TIMESTAMP - 365 AND Copy_Number NOT IN (Select Copy_Number From loan_table Where Date_Returned IS NULL))";

            SqlCommand sql = new SqlCommand(deleteFromLoanTable, gc.cn);
            sql.ExecuteNonQuery();



            string deleteFromDVDCopy = "DELETE FROM dvd_copy_table WHERE Date_Purchased < CURRENT_TIMESTAMP - 365 AND Copy_Number NOT IN (SELECT Copy_Number FROM loan_table WHERE Date_Returned IS NULL)";

            SqlCommand sqll = new SqlCommand(deleteFromDVDCopy, gc.cn);

            sqll.ExecuteNonQuery();
            gc.cn.Close();


        }

    }
}