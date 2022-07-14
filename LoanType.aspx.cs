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
    public partial class LoanType : System.Web.UI.Page
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
                LoanTypeClass ltc = new LoanTypeClass();
                LoanTypeGridView.DataSource = ltc.DisplayLoanTypeRecords();
                LoanTypeGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void AddLoanTypeButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoanTypeClass ltc = new LoanTypeClass();
                ltc.AddLoanType(this.LoanTypeDropDown.SelectedItem.ToString(), Convert.ToInt32(Text_Loan_Duration.Text));

                resultLabel.Text = "Loan Type Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }

        }
        protected void GVLoanType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LoanTypeDropDown.Text = this.LoanTypeDropDown.SelectedItem.ToString();

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From loan_type_table Where Loan_Type_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "loan_type_table");
            DataTable dt = ds.Tables[0];

            Text_Loan_Type_Number.Text = dt.Rows[0]["Loan_Type_Number"].ToString();
            Text_Loan_Duration.Text = dt.Rows[0]["Loan_Duration"].ToString();
            LoanTypeDropDown.Text = dt.Rows[0]["Loan_Type"].ToString();


        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            LoanTypeDropDown.Text = this.LoanTypeDropDown.SelectedItem.ToString();


            try
            {
                LoanTypeClass ltc = new LoanTypeClass();
                ltc.UpdateLoanType(Convert.ToInt32(Text_Loan_Type_Number.Text), LoanTypeDropDown.Text, Convert.ToInt32(Text_Loan_Duration.Text));
                resultLabel.Text = "Loan Type Details Successfully Updated";
                Text_Loan_Type_Number.Text = Text_Loan_Duration.Text = "";
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
                LoanTypeClass ltc = new LoanTypeClass();
                ltc.DeleteLoanType(Convert.ToInt32(Text_Loan_Type_Number.Text));
                // txtImage.SaveAs(Server.MapPath("~/admin/images/" + txtImage.FileName));

                resultLabel.Text = "Loan Type Details Successfully Deleteted";
                Text_Loan_Type_Number.Text = Text_Loan_Duration.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}