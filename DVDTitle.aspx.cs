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
    public partial class DVDTitle : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                GlobalConnection gc = new GlobalConnection();
                SqlCommand cmd = new SqlCommand();
                string dvdCategoryData = "Select * From dvd_category_table";
                string stdData = "Select * From studio_table";
                string producerData = "Select * From producer_table";

                SqlDataAdapter dcd = new SqlDataAdapter(dvdCategoryData, gc.cn);
                SqlDataAdapter sd = new SqlDataAdapter(stdData, gc.cn);
                SqlDataAdapter pd = new SqlDataAdapter(producerData, gc.cn);
                DataTable dcdt = new DataTable();
                DataTable sdt = new DataTable();
                DataTable pdt = new DataTable();
                dcd.Fill(dcdt);
                sd.Fill(sdt);
                pd.Fill(pdt);
                foreach (DataRow dr in dcdt.Rows)
                {
                    CategoryNumberDropDownList.Items.Add(dr["Category_Number"].ToString());
                }
                foreach (DataRow dr in sdt.Rows)
                {
                    StudioNumberDropDownList.Items.Add(dr["Studio_Number"].ToString());
                }
                foreach (DataRow dr in pdt.Rows)
                {
                    ProducerDropDownList.Items.Add(dr["Producer_Number"].ToString());
                }
            }


        }
        public void ListView()
        {
            try
            {
                DVDTitleClass dtc = new DVDTitleClass();
                DVDTitleGridView.DataSource = dtc.DisplayDVDTitleRecords();
                DVDTitleGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void AddDVDTitleButton_Click(object sender, EventArgs e)
        {

            if (Text_DVD_Title.Text.Trim() == "" && Text_Date_Released.Text.Trim() == "" && Text_Standard_Charge.Text.Trim() == "" && Text_Penalty_Charge.Text.Trim() == "")
            {

                resultLabel.Text = "Fields Empty!";
            }
            else
            {
                try
                {
                    DVDTitleClass dtc = new DVDTitleClass();
                    dtc.AddDVDTitle(Convert.ToInt32(this.CategoryNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.StudioNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.ProducerDropDownList.SelectedItem.ToString()), Text_DVD_Title.Text, DateTime.Parse(Text_Date_Released.Text), Convert.ToInt32(Text_Standard_Charge.Text), Convert.ToInt32(Text_Penalty_Charge.Text));

                    resultLabel.Text = "DVD Title Added Succsesfully";

                }
                catch (Exception ex)
                {
                    resultLabel.Text = ex.Message;
                }
            }


        }

        protected void GVDVDTitle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CategoryNumberDropDownList.Text = this.CategoryNumberDropDownList.SelectedItem.ToString();
            StudioNumberDropDownList.Text = this.StudioNumberDropDownList.SelectedItem.ToString();
            ProducerDropDownList.Text = this.ProducerDropDownList.SelectedItem.ToString();



            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From dvd_title_table Where DVD_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "dvd_title_table");
            DataTable dt = ds.Tables[0];

            Text_DVD_Number.Text = dt.Rows[0]["DVD_Number"].ToString();

            CategoryNumberDropDownList.Text = dt.Rows[0]["Category_Number"].ToString();
            StudioNumberDropDownList.Text = dt.Rows[0]["Studio_Number"].ToString();
            ProducerDropDownList.Text = dt.Rows[0]["Producer_Number"].ToString();




            Text_DVD_Title.Text = dt.Rows[0]["DVD_Title"].ToString();
            Text_Date_Released.Text = dt.Rows[0]["Date_Released"].ToString();
            Text_Standard_Charge.Text = dt.Rows[0]["Standard_Charge"].ToString();
            Text_Penalty_Charge.Text = dt.Rows[0]["Penalty_Charge"].ToString();


        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            CategoryNumberDropDownList.Text = this.CategoryNumberDropDownList.SelectedItem.ToString();
            StudioNumberDropDownList.Text = this.StudioNumberDropDownList.SelectedItem.ToString();
            ProducerDropDownList.Text = this.ProducerDropDownList.SelectedItem.ToString();


            try
            {
                DVDTitleClass dtc = new DVDTitleClass();
                dtc.UpdateDVDTitle(Convert.ToInt32(Text_DVD_Number.Text), Convert.ToInt32(this.CategoryNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.StudioNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.ProducerDropDownList.SelectedItem.ToString()), Text_DVD_Title.Text, DateTime.Parse(Text_Date_Released.Text), Convert.ToInt32(Text_Standard_Charge.Text), Convert.ToInt32(Text_Penalty_Charge.Text));
                resultLabel.Text = "DVD Title Details Successfully Updated";
                Text_DVD_Title.Text = Text_Date_Released.Text = Text_Standard_Charge.Text = Text_Penalty_Charge.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DVDCategoryClass dcc = new DVDCategoryClass();
        //        dcc.DeleteDVDCategory(Convert.ToInt32(Text_DVD_Number.Text));
        //        // txtImage.SaveAs(Server.MapPath("~/admin/images/" + txtImage.FileName));

        //        resultLabel.Text = "DVD Title Details Successfully Deleteted";
        //        Text_DVD_Title.Text = Text_Date_Released.Text = Text_Standard_Charge.Text = Text_Penalty_Charge.Text = "";
        //        ListView();

        //    }
        //    catch (Exception ex)
        //    {

        //        resultLabel.Text = ex.Message;
        //    }

        //}
    }
}