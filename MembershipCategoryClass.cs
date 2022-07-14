using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class MembershipCategoryClass
    {
        GlobalConnection gc = new GlobalConnection();


        public void AddMembershipCategory(string MembershipCategoryDescription, int MembershipCategoryTotalLoans)
        {

            SqlCommand cmd = new SqlCommand("Insert into membership_category_table(Membership_Category_Description,Membership_Category_Total_Loans)values (@MembershipCategoryDescription,@MembershipCategoryTotalLoans)", gc.cn);
            cmd.Parameters.AddWithValue("@MembershipCategoryDescription", MembershipCategoryDescription);
            cmd.Parameters.AddWithValue("@MembershipCategoryTotalLoans", MembershipCategoryTotalLoans);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }

        public DataTable DisplayMembershipCategoryRecords()
        {
            string sql = "SELECT * FROM membership_category_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public void UpdateMembershipCategory(int MembershipCategoryNumber, string MembershipCategoryDescription, int MembershipCategoryTotalLoans)
        {
            SqlCommand cmd = new SqlCommand("Update membership_category_table set " +
                "Membership_Category_Description=@MembershipCategoryDescription,Membership_Category_Total_Loans=@MembershipCategoryTotalLoans where Membership_Category_Number=@MembershipCategoryNumber", gc.cn);
            cmd.Parameters.AddWithValue("@MembershipCategoryDescription", MembershipCategoryDescription);
            cmd.Parameters.AddWithValue("@MembershipCategoryTotalLoans", MembershipCategoryTotalLoans);

            cmd.Parameters.AddWithValue("@MembershipCategoryNumber", MembershipCategoryNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteMembershipCategory(int MembershipCategoryNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from membership_category_table where Membership_Category_Number=@MembershipCategoryNumber", gc.cn);
            cmd.Parameters.AddWithValue("@MembershipCategoryNumber", MembershipCategoryNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}