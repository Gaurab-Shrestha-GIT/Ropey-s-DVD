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
    public partial class Member : System.Web.UI.Page
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
                string mCategoryData = "Select * From membership_category_table";

                SqlDataAdapter dcd = new SqlDataAdapter(mCategoryData, gc.cn);
                DataTable dcdt = new DataTable();

                dcd.Fill(dcdt);
                foreach (DataRow dr in dcdt.Rows)
                {
                    MembershipCategoryNumberDropDownList.Items.Add(dr["Membership_Category_Number"].ToString());
                }
            }




        }
        public void ListView()
        {
            try
            {
                MemberClass dtc = new MemberClass();
                MemberGridView.DataSource = dtc.DisplayMemberRecords();
                MemberGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void AddMemberButton_Click(object sender, EventArgs e)
        {

            try
            {
                MemberClass dtc = new MemberClass();
                dtc.AddMember(Convert.ToInt32(this.MembershipCategoryNumberDropDownList.SelectedItem.ToString()), Text_Member_Last_Name.Text, Text_Member_First_Name.Text, Text_Member_Address.Text, DateTime.Parse(Text_Member_Date_Of_Birth.Text));

                resultLabel.Text = "Member Added Succsesfully";

            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }
        protected void GVMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MembershipCategoryNumberDropDownList.Text = this.MembershipCategoryNumberDropDownList.SelectedItem.ToString();


            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);
            string strData = "Select * From member_table Where member_number ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "member_table");
            DataTable dt = ds.Tables[0];

            Text_Member_Number.Text = dt.Rows[0]["Member_Number"].ToString();
            MembershipCategoryNumberDropDownList.Text = dt.Rows[0]["Membership_Category_Number"].ToString();
            Text_Member_Last_Name.Text = dt.Rows[0]["Member_Last_Name"].ToString();
            Text_Member_First_Name.Text = dt.Rows[0]["Member_First_Name"].ToString();
            Text_Member_Address.Text = dt.Rows[0]["Member_Address"].ToString();
            Text_Member_Date_Of_Birth.Text = dt.Rows[0]["Member_Date_Of_Birth"].ToString();





        }


        protected void UpdateButton_Click(object sender, EventArgs e)
        {


            MembershipCategoryNumberDropDownList.Text = this.MembershipCategoryNumberDropDownList.SelectedItem.ToString();



            try
            {
                MemberClass mc = new MemberClass();
                mc.UpdateMember(Convert.ToInt32(Text_Member_Number.Text), Convert.ToInt32(this.MembershipCategoryNumberDropDownList.SelectedItem.ToString()), Text_Member_Last_Name.Text, Text_Member_First_Name.Text, Text_Member_Address.Text, DateTime.Parse(Text_Member_Date_Of_Birth.Text));
                resultLabel.Text = "Member Details Successfully Updated";
                Text_Member_Last_Name.Text = Text_Member_First_Name.Text = Text_Member_Address.Text = Text_Member_Date_Of_Birth.Text = "";
                ListView();

            }
            catch (Exception ex)
            {

                resultLabel.Text = ex.Message;
            }
        }
    }
}