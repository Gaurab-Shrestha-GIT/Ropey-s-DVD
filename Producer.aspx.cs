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
    public partial class Producer : System.Web.UI.Page
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
                ProducerClass pc = new ProducerClass();
                ProducerGridView.DataSource = pc.DisplayStudioRecords();
                ProducerGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void AddProducerButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProducerClass pc = new ProducerClass();
                pc.AddProducer(Text_Producer_Name.Text);

                resultLabel.Text = "Producer Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void GVProducer_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From producer_table Where Producer_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "producer_table");
            DataTable dt = ds.Tables[0];

            Text_Producer_Number.Text = dt.Rows[0]["Producer_Number"].ToString();
            Text_Producer_Name.Text = dt.Rows[0]["Producer_Name"].ToString();

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProducerClass pc = new ProducerClass();
                pc.UpdateProducer(Convert.ToInt32(Text_Producer_Number.Text), Text_Producer_Name.Text);
                resultLabel.Text = "Producer Details Successfully Updated";
                Text_Producer_Number.Text = Text_Producer_Name.Text = "";
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
                ProducerClass pc = new ProducerClass();
                pc.DeleteProducer(Convert.ToInt32(Text_Producer_Number.Text));
                // txtImage.SaveAs(Server.MapPath("~/admin/images/" + txtImage.FileName));

                resultLabel.Text = "Producer Details Successfully Deleteted";
                Text_Producer_Number.Text = Text_Producer_Name.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}