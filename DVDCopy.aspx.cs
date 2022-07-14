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
    public partial class DVDCopy : System.Web.UI.Page
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
            if (!Page.IsPostBack) {
                GlobalConnection gc = new GlobalConnection();
                SqlCommand cmd = new SqlCommand();

                //query to get details for 
                string dvdTitleData = "Select * From dvd_title_table";

                SqlDataAdapter dtd = new SqlDataAdapter(dvdTitleData, gc.cn);
                DataTable dtdt = new DataTable();
                dtd.Fill(dtdt);
                foreach (DataRow dr in dtdt.Rows)
                {
                    DVDNumberDropDownList.Items.Add(dr["DVD_Number"].ToString());
                }
            }
          

            
            
        }

        public void ListView()
        {
            try
            {
                DVDCopyClass dcc = new DVDCopyClass();
                DVDCopyGridView.DataSource = dcc.DisplayDVDCopyRecords();
                DVDCopyGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }
        protected void AddDVDCopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                DVDCopyClass dcc = new DVDCopyClass();
                dcc.AddDVDCopy(Convert.ToInt32(this.DVDNumberDropDownList.SelectedItem.ToString()), DateTime.Parse(Text_Purchased_Date.Text));

                resultLabel.Text = "DVD Copy Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }
        protected void GVDVDCopy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DVDNumberDropDownList.Text = this.DVDNumberDropDownList.SelectedItem.ToString();



            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From dvd_copy_table Where Copy_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "dvd_copy_table");
            DataTable dt = ds.Tables[0];

            Text_Copy_Number.Text = dt.Rows[0]["Copy_Number"].ToString();

            DVDNumberDropDownList.Text = dt.Rows[0]["DVD_Number"].ToString();
            Text_Purchased_Date.Text = dt.Rows[0]["Date_Purchased"].ToString();

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            DVDNumberDropDownList.Text = this.DVDNumberDropDownList.SelectedItem.ToString();


            try
            {
                DVDCopyClass dcc = new DVDCopyClass();
                dcc.UpdateDVDCopy(Convert.ToInt32(Text_Copy_Number.Text), Convert.ToInt32(this.DVDNumberDropDownList.SelectedItem.ToString()), DateTime.Parse(Text_Purchased_Date.Text));
                resultLabel.Text = "DVD Title Details Successfully Updated";
                Text_Copy_Number.Text = Text_Purchased_Date.Text =  "";
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
                DVDCopyClass p = new DVDCopyClass();
                p.DeleteDVDCopy(Convert.ToInt32(Text_Copy_Number.Text));

                resultLabel.Text = "Actor Details Successfully Deleteted";
                Text_Copy_Number.Text = Text_Purchased_Date.Text = "";
                ListView();

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
                DVDCopyClass p = new DVDCopyClass();
                DVDCopyGridView.DataSource = p.DisplayRecords();
                DVDCopyGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

      
    }
}