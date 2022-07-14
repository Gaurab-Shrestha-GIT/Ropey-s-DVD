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
    public partial class FeatureTwelve : System.Web.UI.Page
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
                FeatureTwelveClass p = new FeatureTwelveClass();
                GridView1.DataSource = p.DisplayRecords();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }
    }
}