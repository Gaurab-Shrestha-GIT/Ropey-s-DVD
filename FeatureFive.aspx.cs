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
    public partial class DetailsByCopyNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie ck = Request.Cookies["ACK"];

            if (ck == null)
            {
                Response.Redirect("Login.aspx");
            }
            GlobalConnection gc = new GlobalConnection();
            if (!Page.IsPostBack)
            {

                SqlCommand cmd = new SqlCommand();
                string actorSurname = "Select Copy_Number From dvd_copy_table";

                SqlDataAdapter dtd = new SqlDataAdapter(actorSurname, gc.cn);
                DataTable dcdt = new DataTable();
                dtd.Fill(dcdt);
                foreach (DataRow dr in dcdt.Rows)
                {
                    CopyNumberDropDownList.Items.Add(dr["Copy_Number"].ToString());
                }
            }

            SqlCommand cmdd = new SqlCommand();
            string copyData = "Select dc.Copy_Number,dt.DVD_Title, l.Date_Out, l.Date_Due, l.Date_Returned, m.Member_First_Name, m.Member_Last_Name From dvd_title_table dt JOIN dvd_copy_table dc ON dt.DVD_Number = dc.DVD_Number JOIN loan_table l ON dc.Copy_Number = l.Copy_Number JOIN member_table m ON l.Member_Number = m.Member_Number Where dc.Copy_Number ='" + CopyNumberDropDownList.SelectedItem.Text + "'";


            SqlDataAdapter cd = new SqlDataAdapter(copyData, gc.cn);
            DataTable cdd = new DataTable();

            cd.Fill(cdd);
            GridView1.DataSource = cdd;
            GridView1.DataBind();
        }

        protected void CopyNumberDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string copyData = "Select dt.DVD_Title, dc.Copy_Number, l.Date_Out, l.Date_Due, l.Date_Returned, m.Member_First_Name, m.Member_Last_Name From dvd_title_table dt JOIN dvd_copy_table dc ON dt.DVD_Number = dc.DVD_Number JOIN loan_table l ON dc.Copy_Number = l.Copy_Number JOIN member_table m ON l.Member_Number = m.Member_Number Where dc.Copy_Number ='" + CopyNumberDropDownList.SelectedItem.Text + "'";


            SqlDataAdapter cd = new SqlDataAdapter(copyData, gc.cn);
            DataTable cdd = new DataTable();

            cd.Fill(cdd);
            GridView1.DataSource = cdd;
            GridView1.DataBind();
        }
    }
}