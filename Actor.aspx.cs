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
    public partial class Actor : System.Web.UI.Page
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
            if (!IsPostBack)
                ListView(); //calling method to display data in grid view while page load
        }



        //method to display data in actorgridview Grid View
        public void ListView()
        {
            try
            {

                ActorClass p = new ActorClass();
                ActorGridView.DataSource = p.DisplayActorRecords();
                ActorGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }


        //add new actor
        protected void AddActorButton_Click(object sender, EventArgs e)
        {
            try
            {
                ActorClass p = new ActorClass();
                p.AddActor(Text_Actor_Surname.Text, Text_Actor_First_Name.Text);

                resultLabel.Text = "Actor Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }


        //display data in text box in the form 
        protected void GV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From actor_table Where Actor_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "actor_table");
            DataTable dt = ds.Tables[0];

            Text_Actor_Number.Text = dt.Rows[0]["Actor_Number"].ToString();
            Text_Actor_Surname.Text = dt.Rows[0]["Actor_Surname"].ToString();
            Text_Actor_First_Name.Text = dt.Rows[0]["Actor_First_Name"].ToString();

        }

        //update actor details 
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                ActorClass p = new ActorClass();
                p.UpdateActor(Convert.ToInt32(Text_Actor_Number.Text), Text_Actor_Surname.Text, Text_Actor_First_Name.Text);
                resultLabel.Text = "Actor Details Successfully Updated";
                Text_Actor_Number.Text = Text_Actor_Surname.Text = Text_Actor_First_Name.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }

        //delete actor details
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ActorClass p = new ActorClass();
                p.DeleteActor(Convert.ToInt32(Text_Actor_Number.Text));
                resultLabel.Text = "Actor Details Successfully Deleteted";
                Text_Actor_Number.Text = Text_Actor_Surname.Text = Text_Actor_First_Name.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}