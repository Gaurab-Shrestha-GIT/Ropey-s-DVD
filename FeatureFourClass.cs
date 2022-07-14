using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
namespace GroupCoursework
{
    public class FeatureFourClass
    {

        GlobalConnection gc = new GlobalConnection();

        public DataTable DisplayCastRecords()
        {
            string sql = "SELECT at.Actor_Surname, at.Actor_First_Name, dt.DVD_Title, dt.Date_Released, st.Studio_Name, pt.Producer_Name FROM actor_table at JOIN cast_member_table cmt ON at.Actor_Number = cmt.Actor_Number JOIN dvd_title_table dt ON cmt.DVD_Number = dt.DVD_Number JOIN studio_table st ON dt.Studio_Number = st.Studio_Number JOIN producer_table pt ON dt.Producer_Number = pt.Producer_Number";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable DisplayCastNRecords()
        {
            string sql = "SELECT at.Actor_Surname, at.Actor_First_Name, dt.DVD_Title, dt.Date_Released, st.Studio_Name, pt.Producer_Name FROM actor_table at JOIN cast_member_table cmt ON at.Actor_Number = cmt.Actor_Number JOIN dvd_title_table dt ON cmt.DVD_Number = dt.DVD_Number JOIN studio_table st ON dt.Studio_Number = st.Studio_Number JOIN producer_table pt ON dt.Producer_Number = pt.Producer_Number ORDER BY at.Actor_Surname";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable DisplayCastDRecords()
        {
            string sql = "SELECT at.Actor_Surname, at.Actor_First_Name, dt.DVD_Title, dt.Date_Released, st.Studio_Name, pt.Producer_Name FROM actor_table at JOIN cast_member_table cmt ON at.Actor_Number = cmt.Actor_Number JOIN dvd_title_table dt ON cmt.DVD_Number = dt.DVD_Number JOIN studio_table st ON dt.Studio_Number = st.Studio_Number JOIN producer_table pt ON dt.Producer_Number = pt.Producer_Number ORDER BY dt.Date_Released";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
    }
}