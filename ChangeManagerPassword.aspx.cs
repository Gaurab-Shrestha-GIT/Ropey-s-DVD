using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupCoursework
{
    public partial class ChangeManagerPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //checking cookie for user login
            HttpCookie ck = Request.Cookies["ACK"];

            if (ck == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
            }

        }

        //changing password for manager


        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (NewPasswordText.Text.Trim() == "" && ConfirmPasswordText.Text.Trim() == "")
                {
                    resultLabel.Text = "Fields Empty!";
                }
                else if (NewPasswordText.Text == ConfirmPasswordText.Text)
                {
                    try
                    {
                        UserClass uc = new UserClass();
                        uc.ChangeManagerPassword(Convert.ToInt32(Session["usernumber"]), NewPasswordText.Text);
                        resultLabel.Text = "Password Successfully Changed";
                    }
                    catch (Exception ex)
                    {
                        resultLabel.Text = ex.Message;
                    }

                }
                else
                {
                    resultLabel.Text = "Password Do not Matched";
                }
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }
    }
}