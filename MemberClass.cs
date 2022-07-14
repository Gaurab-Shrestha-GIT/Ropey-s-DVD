using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class MemberClass
    {

        GlobalConnection gc = new GlobalConnection();

        public void AddMember(int MembershipCategoryNumber, string MemberLastName, string MemberFirstName, string MemberAddress, DateTime MemberDateOfBirth)
        {

            SqlCommand cmd = new SqlCommand("Insert into member_table(Membership_Category_Number,Member_Last_Name, Member_First_Name, Member_Address, Member_Date_Of_Birth)values (@MembershipCategoryNumber,@MemberLastName, @MemberFirstName, @MemberAddress, @MemberDateOfBirth)", gc.cn);
            cmd.Parameters.AddWithValue("@MembershipCategoryNumber", MembershipCategoryNumber);
            cmd.Parameters.AddWithValue("@MemberLastName", MemberLastName);
            cmd.Parameters.AddWithValue("@MemberFirstName", MemberFirstName);
            cmd.Parameters.AddWithValue("@MemberAddress", MemberAddress);
            cmd.Parameters.AddWithValue("@MemberDateOfBirth", MemberDateOfBirth);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }


        public DataTable DisplayMemberRecords()
        {
            string sql = "SELECT * FROM member_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
        public void UpdateMember(int MemberNumber ,int MembershipCategoryNumber, string MemberLastName, string MemberFirstName, string MemberAddress, DateTime MemberDateOfBirth)
        {
            SqlCommand cmd = new SqlCommand("Update member_table set " +
                "Membership_Category_Number=@MembershipCategoryNumber,Member_Last_Name=@MemberLastName, Member_First_Name=@MemberFirstName, Member_Address=@MemberAddress, Member_Date_Of_Birth=@MemberDateOfBirth Where Member_Number=@MemberNumber", gc.cn);

            
            cmd.Parameters.AddWithValue("@MembershipCategoryNumber", MembershipCategoryNumber);
            cmd.Parameters.AddWithValue("@MemberLastName", MemberLastName);
            cmd.Parameters.AddWithValue("@MemberFirstName", MemberFirstName);
            cmd.Parameters.AddWithValue("@MemberAddress", MemberAddress);
            cmd.Parameters.AddWithValue("@MemberDateOfBirth", MemberDateOfBirth);

            cmd.Parameters.AddWithValue("@MemberNumber", MemberNumber);



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