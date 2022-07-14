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
    public partial class CastMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie ck = Request.Cookies["ACK"];

            if (ck == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
                ListView();
            if (!Page.IsPostBack)
            {
                // object for GlobalConnection of database connection
                GlobalConnection gc = new GlobalConnection();
                SqlCommand cmd = new SqlCommand();

                //query to display details
                string dvdTitleData = "Select * From dvd_title_table";
                string actorData = "Select * From actor_table";

                SqlDataAdapter dtd = new SqlDataAdapter(dvdTitleData, gc.cn);
                SqlDataAdapter ad = new SqlDataAdapter(actorData, gc.cn);
                DataTable dcdt = new DataTable();
                DataTable sdt = new DataTable();
                DataTable pdt = new DataTable();
                dtd.Fill(dcdt);
                ad.Fill(sdt);
                //displaying dvd number in drop down list
                foreach (DataRow dr in dcdt.Rows)
                {
                    DVDNumberDropDownList.Items.Add(dr["DVD_Number"].ToString());
                }
                //displaying actor number in drop down list
                foreach (DataRow dr in sdt.Rows)
                {
                    ActorNumberDropDownList.Items.Add(dr["Actor_Number"].ToString());
                }
            }


        }

        //display data in grid view
        public void ListView()
        {
            try
            {
                CastMemberClass cmc = new CastMemberClass();
                CastMemberGridView.DataSource = cmc.DisplayCastMemberRecords();
                CastMemberGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        //add new cast member
        protected void AddCastMemberButton_Click(object sender, EventArgs e)
        {
            try
            {
                CastMemberClass dcc = new CastMemberClass();
                dcc.AddCastMember(Convert.ToInt32(this.DVDNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.ActorNumberDropDownList.SelectedItem.ToString()));

                resultLabel.Text = "Cast Member Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        //display data in respective text box from grid view
        protected void GVCastMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DVDNumberDropDownList.Text = this.DVDNumberDropDownList.SelectedItem.ToString();
            ActorNumberDropDownList.Text = this.ActorNumberDropDownList.SelectedItem.ToString();



            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From cast_member_table Where DVD_Number AND Actor_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "cast_member_table");
            DataTable dt = ds.Tables[0];


            ActorNumberDropDownList.Text = dt.Rows[0]["Actor_Number"].ToString();
            DVDNumberDropDownList.Text = dt.Rows[0]["DVD_Number"].ToString();

        }

        //update cast member
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            DVDNumberDropDownList.Text = this.DVDNumberDropDownList.SelectedItem.ToString();
            ActorNumberDropDownList.Text = this.ActorNumberDropDownList.SelectedItem.ToString();


            try
            {
                CastMemberClass cmc = new CastMemberClass();
                cmc.UpdateCastMember(Convert.ToInt32(this.DVDNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.ActorNumberDropDownList.SelectedItem.ToString()));
                resultLabel.Text = "Cast Member Details Successfully Updated";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }

        }
    }
}