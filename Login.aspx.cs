using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace GroupCoursework
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {


            if (UserDropDownList.SelectedIndex == 1)
            {
                try
                {
                    UserClass uc = new UserClass();
                    DataTable datatable = uc.CheckAssistant(TextBox1.Text, TextBox2.Text, UserDropDownList.SelectedItem.ToString());
                    if (datatable.Rows.Count > 0)
                    {
                        string usernumber = datatable.Rows[0]["UserNumber"].ToString();
                        string username = datatable.Rows[0]["UserName"].ToString();
                        string usertype = datatable.Rows[0]["UserType"].ToString();
                        string password = datatable.Rows[0]["UserPassword"].ToString();

                        if (username.Equals(TextBox1.Text.Trim()) && password.Equals(TextBox2.Text.Trim()) && usertype.Equals(UserDropDownList.SelectedItem.ToString()))
                        {


                            if (CheckBox1.Checked)
                            {


                                HttpCookie ack = new HttpCookie("ACK");
                                ack["username"] = TextBox1.Text;
                                ack["password"] = TextBox2.Text;
                                ack.Expires = DateTime.Now.AddHours(1);
                                Response.Cookies.Add(ack);



                            }


                            Session["username"] = username;
                            Session["usertype"] = UserDropDownList.SelectedValue;
                            Session["usernumber"] = usernumber;

                            Response.Redirect("AssistantDashboard.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Username and Password do not match');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Username and Password do not match');</script>");
                    }
                }
                catch (Exception ex)
                {
                    resultLabel.Text = ex.Message;
                }
            }
            else
            {
                try
                {
                    UserClass uc = new UserClass();
                    DataTable dataTable = uc.CheckManager(TextBox1.Text, TextBox2.Text, UserDropDownList.SelectedItem.ToString());
                    if (dataTable.Rows.Count > 0)
                    {
                        string usernumber = dataTable.Rows[0]["UserNumber"].ToString();
                        string username = dataTable.Rows[0]["UserName"].ToString();
                        string usertype = dataTable.Rows[0]["UserType"].ToString();
                        string password = dataTable.Rows[0]["UserPassword"].ToString();

                        if (username.Equals(TextBox1.Text.Trim()) && password.Equals(TextBox2.Text.Trim()) && usertype.Equals(UserDropDownList.SelectedItem.ToString()))
                        {

                            if (CheckBox1.Checked)
                            {


                                HttpCookie ack = new HttpCookie("ACK");
                                ack["username"] = TextBox1.Text;
                                ack["password"] = TextBox2.Text;
                                ack.Expires = DateTime.Now.AddHours(1);
                                Response.Cookies.Add(ack);



                            }
                            else
                            {
                                HttpCookie ack = new HttpCookie("ACK");
                                ack["username"] = TextBox1.Text;
                                ack["password"] = TextBox2.Text;
                                ack.Expires = DateTime.Now.AddMinutes(5);
                                Response.Cookies.Add(ack);

                            }
                            Session["username"] = username;
                            Session["usertype"] = UserDropDownList.SelectedValue;
                            Session["usernumber"] = usernumber;
                            Response.Redirect("ManagerDashboard.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Username and Password do not match');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Username and Password do not match');</script>");
                    }

                }
                catch (Exception ex)
                {

                    resultLabel.Text = ex.Message;
                }

            }
        }
    }
}