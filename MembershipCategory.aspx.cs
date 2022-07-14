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
    public partial class MembershipCategory : System.Web.UI.Page
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
                MembershipCategoryClass mcc = new MembershipCategoryClass();
                MembershipCaegoryGridView.DataSource = mcc.DisplayMembershipCategoryRecords();
                MembershipCaegoryGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }


        protected void AddMembershipCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipCategoryClass mcc = new MembershipCategoryClass();
                mcc.AddMembershipCategory(Text_Membership_Category_Description.Text, Convert.ToInt32(Text_Membership_Category_Total_Loans.Text));

                resultLabel.Text = "Membership Category Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }

        }

        protected void GVMembershipCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From membership_category_table Where Membership_Category_Number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "membership_category_table");
            DataTable dt = ds.Tables[0];

            Text_Membership_Category_Number.Text = dt.Rows[0]["Membership_Category_Number"].ToString();
            Text_Membership_Category_Description.Text = dt.Rows[0]["Membership_Category_Description"].ToString();
            Text_Membership_Category_Total_Loans.Text = dt.Rows[0]["Membership_Category_Total_Loans"].ToString();


        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

            try
            {
                MembershipCategoryClass mcc = new MembershipCategoryClass();
                mcc.UpdateMembershipCategory(Convert.ToInt32(Text_Membership_Category_Number.Text), Text_Membership_Category_Description.Text, Convert.ToInt32(Text_Membership_Category_Total_Loans.Text));
                resultLabel.Text = "Membershp Category Details Successfully Updated";
                Text_Membership_Category_Number.Text = Text_Membership_Category_Description.Text = Text_Membership_Category_Total_Loans.Text = "";
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
                MembershipCategoryClass mcc = new MembershipCategoryClass();
                mcc.DeleteMembershipCategory(Convert.ToInt32(Text_Membership_Category_Number.Text));
                // txtImage.SaveAs(Server.MapPath("~/admin/images/" + txtImage.FileName));

                resultLabel.Text = "Membership Category Details Successfully Deleteted";
                Text_Membership_Category_Number.Text = Text_Membership_Category_Description.Text = Text_Membership_Category_Total_Loans.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}