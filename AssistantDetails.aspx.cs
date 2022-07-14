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
    public partial class AssistantDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ListView();
        }
        public void ListView()
        {
            try
            {
                AssistantDetailsClass p = new AssistantDetailsClass();
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
            try
            {
                AssistantDetailsClass p = new AssistantDetailsClass();
                p.AddAssistant(TextBox1.Text, TextBox2.Text);

                resultLabel.Text = "New Assistant Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void GV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From user_table Where UserNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "user_table");
            DataTable dt = ds.Tables[0];
            usernumberlabel.Text = dt.Rows[0]["UserNumber"].ToString();
            TextBox1.Text = dt.Rows[0]["UserName"].ToString();
            TextBox2.Text = dt.Rows[0]["UserPassword"].ToString();

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                AssistantDetailsClass p = new AssistantDetailsClass();
                p.Delete(Convert.ToInt32(usernumberlabel.Text));

                resultLabel.Text = "Assistant Details Successfully Deleteted";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}