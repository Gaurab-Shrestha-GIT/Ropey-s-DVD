using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace GroupCoursework
{
    public partial class ActorFilm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            GlobalConnection gc = new GlobalConnection();
            if (!Page.IsPostBack)
            {

                SqlCommand cmd = new SqlCommand();
                string actorSurname = "Select * From actor_table";

                SqlDataAdapter dtd = new SqlDataAdapter(actorSurname, gc.cn);
                DataTable dcdt = new DataTable();
                dtd.Fill(dcdt);
                foreach (DataRow dr in dcdt.Rows)
                {
                    ActorLastNameDropDownList.Items.Add(dr["Actor_Surname"].ToString());
                }
            }


            SqlCommand cmdd = new SqlCommand();
            string actorData = "Select cmt.DVD_Number, cmt.Actor_Number, dtt.DVD_Title From actor_table at JOIN cast_member_table cmt ON at.Actor_Number = cmt.Actor_Number JOIN dvd_title_table dtt ON cmt.DVD_Number = dtt.DVD_Number Where at.Actor_Surname ='" + ActorLastNameDropDownList.SelectedItem.Text + "'";


            SqlDataAdapter dtdd = new SqlDataAdapter(actorData, gc.cn);
            DataTable dcdtt = new DataTable();

            dtdd.Fill(dcdtt);
            GridView1.DataSource = dcdtt;
            GridView1.DataBind();


        }

        protected void ActorLastNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {



            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string actorData = "Select cmt.DVD_Number, cmt.Actor_Number, dtt.DVD_Title From actor_table at JOIN cast_member_table cmt ON at.Actor_Number = cmt.Actor_Number JOIN dvd_title_table dtt ON cmt.DVD_Number = dtt.DVD_Number Where at.Actor_Surname ='" + ActorLastNameDropDownList.SelectedItem.Text + "'";


            SqlDataAdapter dtd = new SqlDataAdapter(actorData, gc.cn);
            DataTable dcdt = new DataTable();

            dtd.Fill(dcdt);
            GridView1.DataSource = dcdt;
            GridView1.DataBind();




        }


    }
}