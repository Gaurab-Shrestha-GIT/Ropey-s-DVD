using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public class ActorClass
    {
        GlobalConnection gc = new GlobalConnection();

        //add new actor
        public void AddActor(string ActorSurname, string ActorFirstName)
        {

            SqlCommand cmd = new SqlCommand("Insert into actor_table(Actor_Surname,Actor_First_Name)values (@ActorSurname,@ActorFirstName)", gc.cn);
            cmd.Parameters.AddWithValue("@ActorSurname", ActorSurname);
            cmd.Parameters.AddWithValue("@ActorFirstName", ActorFirstName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();

        }
        //display actor details
        public DataTable DisplayActorRecords()
        {
            string sql = "SELECT * FROM actor_table";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];


        }

        //update actor details
        public void UpdateActor(int ActorNumber, string ActorSurname, string ActorFirstName)
        {
            SqlCommand cmd = new SqlCommand("Update actor_table set " +
                "Actor_Surname=@ActorSurname,Actor_First_Name=@ActorFirstName where Actor_Number=@ActorNumber", gc.cn);
            cmd.Parameters.AddWithValue("@ActorSurname", ActorSurname);
            cmd.Parameters.AddWithValue("@ActorFirstName", ActorFirstName);

            cmd.Parameters.AddWithValue("@ActorNumber", ActorNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        //delete actor details
        public void DeleteActor(int ActorNumber)
        {
            SqlCommand cmd = new SqlCommand("Delete from actor_table where Actor_Number=@ActorNumber", gc.cn);
            cmd.Parameters.AddWithValue("@ActorNumber", ActorNumber);
            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

    }
}