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
    public partial class FeatureTwo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            GlobalConnection gc = new GlobalConnection();
            if (!Page.IsPostBack)
            {

                SqlCommand cmd = new SqlCommand();
                string dvdTitleData = "Select * From actor_table";

                SqlDataAdapter dtd = new SqlDataAdapter(dvdTitleData, gc.cn);
                DataTable dtdt = new DataTable();
                dtd.Fill(dtdt);
                foreach (DataRow dr in dtdt.Rows)
                {
                    ActorSurnameDropDownList.Items.Add(dr["Actor_Surname"].ToString());
                }
            }

            SqlCommand cmdd = new SqlCommand();
            string data = "Select at.Actor_Surname, dt.DVD_Title, dc.Copy_number, COUNT(*) AS NumberOfCopies From actor_table at JOIN cast_member_table ct ON at.Actor_Number = ct.Actor_Number JOIN dvd_title_table dt ON ct.DVD_Number = dt.DVD_Number JOIN dvd_copy_table dc ON dt.DVD_Number = dc.DVD_Number LEFT JOIN loan_table lt ON dc.Copy_Number = lt.Copy_Number Group By at.Actor_Surname, dt.DVD_Title, dc.Copy_Number Having at.Actor_Surname ='" + ActorSurnameDropDownList.SelectedItem.Text + "'";


            SqlDataAdapter cd = new SqlDataAdapter(data, gc.cn);
            DataTable cdd = new DataTable();

            cd.Fill(cdd);
            GridView1.DataSource = cdd;
            GridView1.DataBind();
        }

        protected void ActorSurnameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                GlobalConnection gc = new GlobalConnection();
                SqlCommand cmd = new SqlCommand();
                string data = "Select at.Actor_Surname, dt.DVD_Title, dc.Copy_number, COUNT(*) AS NumberOfCopies From actor_table at JOIN cast_member_table ct ON at.Actor_Number = ct.Actor_Number JOIN dvd_title_table dt ON ct.DVD_Number = dt.DVD_Number JOIN dvd_copy_table dc ON dt.DVD_Number = dc.DVD_Number LEFT JOIN loan_table lt ON dc.Copy_Number = lt.Copy_Number Group By at.Actor_Surname, dt.DVD_Title, dc.Copy_Number Having at.Actor_Surname ='" + ActorSurnameDropDownList.SelectedItem.Text + "'";


                SqlDataAdapter cd = new SqlDataAdapter(data, gc.cn);
                DataTable cdd = new DataTable();

                cd.Fill(cdd);
                GridView1.DataSource = cdd;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }

        }
    }
}