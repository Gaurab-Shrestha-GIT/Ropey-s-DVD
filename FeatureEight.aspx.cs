using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupCoursework
{
    public partial class FeatureEight : System.Web.UI.Page
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
                FeatureEightClass p = new FeatureEightClass();
                GridView1.DataSource = p.memberNoLoan();
                GridView1.DataBind();
                GridView2.DataSource = p.memberWithLoan();
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }
    }
}