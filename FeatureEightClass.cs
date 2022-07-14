using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
namespace GroupCoursework
{
    public class FeatureEightClass
    {
        GlobalConnection gc = new GlobalConnection();

        public DataTable memberWithLoan()
        {

            string sql = "SELECT mt.Member_Number, mt.Member_Last_Name, mt.Member_First_Name, mt.Member_Address, mt.Member_Date_Of_Birth, mt.Membership_Category_Number, mct.Membership_Category_Total_Loans, COUNT(mt.Member_Number) as NumberOfLoan, CASE WHEN mct.Membership_Category_Total_Loans < COUNT(mt.Member_Number) THEN ' *Too many DVDs* ' ELSE ' *Limit Not Exceed* ' END as 'Message' FROM member_table mt LEFT JOIN loan_table lt ON mt.Member_Number = lt.Member_Number JOIN membership_category_table mct ON mt.Membership_Category_Number = mct.Membership_Category_Number WHERE lt.Member_Number IS NOT NULL GROUP BY mt.Member_Number, mt.Membership_Category_Number, mt.Member_Last_Name, mt.Member_First_Name, mt.Member_Address, mt.Member_Date_Of_Birth, mct.Membership_Category_Total_Loans";

            SqlDataAdapter sqll = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sqll.Fill(ds, "loan_table");
            return ds.Tables[0];
        }

        // Get Members who do not have loan
        public DataTable memberNoLoan()
        {
            string sql = "SELECT mt.Member_Number, mt.Member_Last_Name, mt.Member_First_Name, mt.Member_Address, mt.Member_Date_Of_Birth, mt.Membership_Category_Number, mct.Membership_Category_Total_Loans FROM member_table mt LEFT JOIN loan_table lt ON mt.Member_Number = lt.Member_Number JOIN membership_category_table mct ON mt.Membership_Category_Number = mct.Membership_Category_Number WHERE lt.Member_Number IS NULL";
            SqlDataAdapter sqll = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sqll.Fill(ds, "loan_table");
            return ds.Tables[0];
        }

        // Get only Loan Data
        public DataTable onlyLoan()
        {
            string sql = "SELECT * FROM loan_table WHERE Date_Returned IS NULL";
            SqlDataAdapter sqll = new SqlDataAdapter(sql, gc.cn);
            DataSet dol = new DataSet();
            sqll.Fill(dol, "loan_table");
            return dol.Tables[0];
        }
    }
}