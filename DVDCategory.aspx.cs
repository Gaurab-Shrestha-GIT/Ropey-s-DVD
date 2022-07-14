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
    public partial class DVDCategory : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            //checking cookie for user login
            HttpCookie ck = Request.Cookies["ACK"];

            if (ck == null)
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
                ListView();
        }

        //displaying dvd category data in grid view
        public void ListView()
        {
            try
            {
                DVDCategoryClass dcc = new DVDCategoryClass();
                DVDCategoryGridView.DataSource = dcc.DisplayDVDCategoryRecords();
                DVDCategoryGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }




        protected void ageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //add new dvd category
        protected void AddDVDCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                DVDCategoryClass dcc = new DVDCategoryClass();
                dcc.AddDVDCategory(this.ageDropDown.SelectedItem.ToString(), Text_Category_Description.Text);

                resultLabel.Text = "DVD Category Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }


        //getting data in text box from grid view
        protected void GVDVDCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ageDropDown.Text = this.ageDropDown.SelectedItem.ToString();

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From dvd_category_table Where Category_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "dvd_category_table");
            DataTable dt = ds.Tables[0];

            Text_Category_Number.Text = dt.Rows[0]["Category_Number"].ToString();
            Text_Category_Description.Text = dt.Rows[0]["Category_Description"].ToString();
            ageDropDown.Text = dt.Rows[0]["Age_Restricted"].ToString();

        }

        //update dvd category details
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            ageDropDown.Text = this.ageDropDown.SelectedItem.ToString();


            try
            {
                DVDCategoryClass dc = new DVDCategoryClass();
                dc.UpdateDVDCategory(Convert.ToInt32(Text_Category_Number.Text), Text_Category_Description.Text, ageDropDown.Text);
                resultLabel.Text = "Category Details Successfully Updated";
                Text_Category_Number.Text = Text_Category_Description.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
        //deleting dvd category details
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DVDCategoryClass dcc = new DVDCategoryClass();
                dcc.DeleteDVDCategory(Convert.ToInt32(Text_Category_Number.Text));

                resultLabel.Text = "Category Details Successfully Deleteted";
                Text_Category_Number.Text = Text_Category_Description.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}