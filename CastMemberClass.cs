using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class CastMemberClass
    {
        // object for GlobalConnection of database connection
        GlobalConnection gc = new GlobalConnection();

        //add new cast member
        public void AddCastMember(int DVDNumber, int ActorNumber)
        {

            SqlCommand cmd = new SqlCommand("Insert into cast_member_table(DVD_Number,Actor_Number)values (@DVDNumber,@ActorNumber)", gc.cn);
            cmd.Parameters.AddWithValue("@DVDNumber", DVDNumber);
            cmd.Parameters.AddWithValue("@ActorNumber", ActorNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }


        //display cast member records
        public DataTable DisplayCastMemberRecords()
        {
            string sql = "SELECT * FROM cast_member_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        //update cast member details
        public void UpdateCastMember(int DVDNumber, int ActorNumber)
        {
            SqlCommand cmd = new SqlCommand("Update cast_member_table set " +
                "DVD_Number=@DVDActorNumDVDNumberber, Actor_Number=@ActorNumber where DVD_Number=@DVDNumber AND Actor_Number=@ActorNumber", gc.cn);

            cmd.Parameters.AddWithValue("@DVDNumber", DVDNumber);
            cmd.Parameters.AddWithValue("@ActorNumber", ActorNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}