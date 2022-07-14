using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupCoursework
{
    public partial class FeatureTen : System.Web.UI.Page
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
                FeatureTenClass p = new FeatureTenClass();
                GridView1.DataSource = p.DisplayRecords();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FeatureTenClass p = new FeatureTenClass();
            try
            {
                p.DeleteDVD();
                resultLabel.Text = "DVDs Successfully Deleted";
            }
            catch (Exception ex)
            {
                //resultLabel.Text = "Could not delete DVDs";
                resultLabel.Text = ex.Message;
            }

        }
    }
}