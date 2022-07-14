using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupCoursework
{
    public partial class AssistantDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //checking cookie for user login
            HttpCookie ck = Request.Cookies["ACK"];

            //if there is no any cookie it will redirect to login
            if (ck == null)
            {
                Response.Redirect("Login.aspx");
            }


            //checking logged in user name with session
            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
            }





        }

        //button to logout user
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            HttpCookie ck = Request.Cookies["ACK"];
            ck.Expires = DateTime.Now.AddMilliseconds(-10);
            Response.Cookies.Add(ck);
            Response.Redirect("Login.aspx");
        }
    }
}