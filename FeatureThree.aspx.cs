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
    public partial class FeatureThree : System.Web.UI.Page
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
                string memberSurname = "Select Member_Last_Name From member_table";

                SqlDataAdapter dtd = new SqlDataAdapter(memberSurname, gc.cn);
                DataTable dcdt = new DataTable();
                dtd.Fill(dcdt);
                foreach (DataRow dr in dcdt.Rows)
                {
                    MemberLastNameDropDownList.Items.Add(dr["Member_Last_Name"].ToString());
                }

            }
            SqlCommand cmdd = new SqlCommand();
            string actorData = "Select dt.DVD_Title, dc.Copy_Number, lt.Date_Out, mt.Member_Last_Name, lt.Date_Returned From member_table mt JOIN loan_table lt ON mt.Member_Number = lt.Member_Number JOIN dvd_copy_table dc ON lt.Copy_Number = dc.Copy_Number JOIN dvd_title_table dt ON dc.DVD_Number = dt.DVD_Number Where Date_Out >= CURRENT_TIMESTAMP-31 AND mt.Member_Last_Name = '" + MemberLastNameDropDownList.SelectedItem.Text + "'";


            SqlDataAdapter dtdd = new SqlDataAdapter(actorData, gc.cn);
            DataTable dcdtt = new DataTable();

            dtdd.Fill(dcdtt);
            GridView1.DataSource = dcdtt;
            GridView1.DataBind();
        }

        protected void MemberLastNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GlobalConnection gc = new GlobalConnection();
                SqlCommand cmd = new SqlCommand();
                string actorData = "Select dt.DVD_Title, dc.Copy_Number, lt.Date_Out, mt.Member_Last_Name, lt.Date_Returned From member_table mt JOIN loan_table lt ON mt.Member_Number = lt.Member_Number JOIN dvd_copy_table dc ON lt.Copy_Number = dc.Copy_Number JOIN dvd_title_table dt ON dc.DVD_Number = dt.DVD_Number Where Date_Out >= CURRENT_TIMESTAMP-31 AND mt.Member_Last_Name = '" + MemberLastNameDropDownList.SelectedItem.Text + "'";


                SqlDataAdapter dtd = new SqlDataAdapter(actorData, gc.cn);
                DataTable dcdt = new DataTable();

                dtd.Fill(dcdt);
                GridView1.DataSource = dcdt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalConnection gc = new GlobalConnection();
                SqlCommand cmd = new SqlCommand();
                string actorData = "Select mt.Member_Last_Name, mt.Member_First_Name, dt.DVD_Title, dc.Copy_Number, lt.Date_Returned From member_table mt LEFT JOIN loan_table lt ON mt.Member_Number = lt.Member_Number JOIN DVD_Copy dc ON lt.Copy_Number = dc.Copy_Number JOIN dvd_title_table dt ON dc.DVD_Number = dt.DVD_Number Where Date_Out >=CURRENT_TIMESTAMP -31 ";

                SqlDataAdapter dtd = new SqlDataAdapter(actorData, gc.cn);
                DataTable dcdt = new DataTable();

                dtd.Fill(dcdt);
                GridView1.DataSource = dcdt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }
    }
}