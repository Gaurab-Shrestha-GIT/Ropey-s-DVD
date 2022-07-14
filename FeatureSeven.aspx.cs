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
    public partial class FeatureSeven : System.Web.UI.Page
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
            Date_Return_Label.Text = DateTime.Now.ToLongDateString();

        }

        public void ListView()
        {
            try
            {
                FeatureSevenClass p = new FeatureSevenClass();
                GridView1.DataSource = p.DisplayRecords();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void penaltyCharge()
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string penaltyCharge = "SELECT dt.Penalty_Charge From loan_table lt JOIN dvd_copy_table dc ON lt.Copy_Number = dc.Copy_Number JOIN dvd_title_table dt ON dc.DVD_Number = dt.DVD_Number where lt.Loan_Number='" + Text_Loan_Number.Text + "'";

            SqlDataAdapter sa = new SqlDataAdapter(penaltyCharge, gc.cn);
            DataTable dt = new DataTable();

            sa.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PenaltyChargeLabel.Text = dr[0].ToString();
            }
        }

        protected void GV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From loan_table Where Loan_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "loan_table");
            DataTable dt = ds.Tables[0];

            Text_Loan_Number.Text = dt.Rows[0]["Loan_Number"].ToString();
            Date_Due_Label.Text = dt.Rows[0]["Date_Due"].ToString();

            penaltyCharge();


            var dueDate = DateTime.Parse(dt.Rows[0]["Date_Due"].ToString());
            var returnedDate = DateTime.Now;
            var diffDate = returnedDate - dueDate;

            if (Convert.ToInt32(diffDate.Days.ToString()) > 0)
            {
                Date_Duration_Label.Text = (diffDate.Days).ToString();
                TotalPenaltyChargeLabel.Text = (Convert.ToInt32(PenaltyChargeLabel.Text) * Convert.ToInt32(Date_Duration_Label.Text)).ToString(); // set total charge
            }
            else
            {
                PenaltyChargeLabel.Text = "0";
                TotalPenaltyChargeLabel.Text = "0";
                Date_Duration_Label.Text = "0";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                FeatureSevenClass p = new FeatureSevenClass();
                p.Update(Text_Loan_Number.Text, DateTime.Now.ToShortDateString());
                resultLabel.Text = "Loan Details Successfully Updated";
                ListView();
                PenaltyChargeLabel.Text = "0";
                TotalPenaltyChargeLabel.Text = "0";
                Date_Due_Label.Text = "0";
                Date_Duration_Label.Text = "0";

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}