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
    public partial class Studio : System.Web.UI.Page
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
        }

        public void ListView()
        {
            try
            {
                StudioClass sc = new StudioClass();
                StudioGridView.DataSource = sc.DisplayStudioRecords();
                StudioGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void AddStudioButton_Click(object sender, EventArgs e)
        {
            try
            {
                StudioClass sc = new StudioClass();
                sc.AddStudio(Text_Studio_Name.Text);

                resultLabel.Text = "Studio Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void GVStudio_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From studio_table Where Studio_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "studio_table");
            DataTable dt = ds.Tables[0];

            Text_Studio_Number.Text = dt.Rows[0]["Studio_Number"].ToString();
            Text_Studio_Name.Text = dt.Rows[0]["Studio_Name"].ToString();

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                StudioClass sc = new StudioClass();
                sc.UpdateStudio(Convert.ToInt32(Text_Studio_Number.Text),Text_Studio_Name.Text);
                resultLabel.Text = "Studio Details Successfully Updated";
                Text_Studio_Number.Text = Text_Studio_Name.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                StudioClass sc = new StudioClass();
                sc.DeleteStudio(Convert.ToInt32(Text_Studio_Number.Text));
                // txtImage.SaveAs(Server.MapPath("~/admin/images/" + txtImage.FileName));

                resultLabel.Text = "Actor Details Successfully Deleteted";
                Text_Studio_Number.Text = Text_Studio_Name.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}