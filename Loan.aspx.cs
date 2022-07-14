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
    public partial class Loan : System.Web.UI.Page
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
                string loanTYpeNumberData = "Select * From loan_type_table";
                string copyNumberData = "Select * From dvd_copy_table";
                string memberNumberData = "Select * From member_table";
                SqlDataAdapter dcd = new SqlDataAdapter(loanTYpeNumberData, gc.cn);
                SqlDataAdapter sd = new SqlDataAdapter(copyNumberData, gc.cn);
                SqlDataAdapter pd = new SqlDataAdapter(memberNumberData, gc.cn);
                DataTable dcdt = new DataTable();
                DataTable sdt = new DataTable();
                DataTable pdt = new DataTable();
                dcd.Fill(dcdt);
                sd.Fill(sdt);
                pd.Fill(pdt);

                foreach (DataRow dr in dcdt.Rows)
                {
                    LoanTypeNumberDropDownList.Items.Add(dr["Loan_Type_Number"].ToString());
                }
                foreach (DataRow dr in sdt.Rows)
                {
                    CopyNumberDropDownList.Items.Add(dr["Copy_Number"].ToString());
                }
                foreach (DataRow dr in pdt.Rows)
                {
                    MemberDropDownList.Items.Add(dr["Member_Number"].ToString());
                }
                LoanDuration();
                ageRestriction();
                memberAge();
                standardCharge();
                Date_Out_Label.Text = DateTime.Now.ToLongDateString();
                TotalChargePerDayLabel.Text = (Convert.ToInt32(ChargePerDayLabel.Text) * Convert.ToInt32(Loan_Duration_Label.Text)).ToString();
                Date_Due_Label.Text = DateTime.Now.AddDays(Convert.ToInt32(Loan_Duration_Label.Text)).ToLongDateString();

            }


        }
        public void ListView()
        {
            try
            {
                LoanClass lc = new LoanClass();
                LoanGridView.DataSource = lc.DisplayLoanRecords();
                LoanGridView.DataBind();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }



        //protected void GVLoan_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    LoanTypeNumberDropDownList.Text = this.LoanTypeNumberDropDownList.SelectedItem.ToString();
        //    CopyNumberDropDownList.Text = this.CopyNumberDropDownList.SelectedItem.ToString();
        //    MemberDropDownList.Text = this.MemberDropDownList.SelectedItem.ToString();



        //    GlobalConnection gc = new GlobalConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = gc.cn;
        //    string index = Convert.ToString(e.CommandArgument);
        //    string strData = "Select * From loan_table Where Loan_Number ='" + index + "'";
        //    SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "loan_table");
        //    DataTable dt = ds.Tables[0];

        //    Text_Loan_Number.Text = dt.Rows[0]["Loan_Number"].ToString();

        //    LoanTypeNumberDropDownList.Text = dt.Rows[0]["Loan_Type_Number"].ToString();
        //    CopyNumberDropDownList.Text = dt.Rows[0]["Copy_Number"].ToString();
        //    MemberDropDownList.Text = dt.Rows[0]["Member_Number"].ToString();
        //    Date_Out_Label.Text = dt.Rows[0]["Date_Out"].ToString();
        //    Date_Due_Label.Text = dt.Rows[0]["Date_Due"].ToString();


        //}
        protected void UpdateButton_Click(object sender, EventArgs e)
        {

            //LoanTypeNumberDropDownList.Text = this.LoanTypeNumberDropDownList.SelectedItem.ToString();
            //CopyNumberDropDownList.Text = this.CopyNumberDropDownList.SelectedItem.ToString();
            //MemberDropDownList.Text = this.MemberDropDownList.SelectedItem.ToString();


            //try
            //{


            //    LoanClass lc = new LoanClass();
            //    lc.UpdateLoan(Convert.ToInt32(Text_Loan_Number.Text), Convert.ToInt32(this.LoanTypeNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.CopyNumberDropDownList.SelectedItem.ToString()), Convert.ToInt32(this.MemberDropDownList.SelectedItem.ToString()), (Text_Date_Out.Text), (Text_Date_Due.Text), Text_Date_Returned.Text);
            //        resultLabel.Text = "Loan Details Successfully Updated";
            //        Text_Loan_Number.Text = Text_Date_Due.Text = Text_Date_Returned.Text = "";
            //        ListView();

            //}
            //catch (Exception ex)
            //{

            //    resultLabel.Text = ex.Message;
            //}
        }


        protected void DisplayDueDate(int day)
        {
            Date_Due_Label.Text = DateTime.UtcNow.AddDays(day).ToLongDateString();

        }

        //calculating loan duration from loan type 
        protected void LoanDuration()
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string loanDuration = "SELECT Loan_Duration FROM loan_type_table WHERE Loan_Type_Number = '" + LoanTypeNumberDropDownList.SelectedValue + "'";
            SqlDataAdapter ld = new SqlDataAdapter(loanDuration, gc.cn);
            DataTable ldt = new DataTable();
            ld.Fill(ldt);
            foreach (DataRow dr in ldt.Rows)
            {
                Loan_Duration_Label.Text = dr[0].ToString();
            }


        }


        //standard charge from dvd title
        protected void standardCharge()
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string copyCharge = "SELECT dc.Copy_Number, dc.Dvd_Number, dt.Standard_Charge FROM dvd_copy_table dc INNER JOIN dvd_title_table dt ON dc.DVD_Number = dt.DVD_Number  WHERE dc.Copy_Number='" + CopyNumberDropDownList.SelectedValue + "'";


            SqlDataAdapter c = new SqlDataAdapter(copyCharge, gc.cn);
            DataTable cs = new DataTable();

            c.Fill(cs);
            foreach (DataRow dr in cs.Rows)
            {
                ChargePerDayLabel.Text = dr["Standard_Charge"].ToString();
            }
        }


        //calculate member age from member table date of birth
        protected void memberAge()
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            string memberAge = "SELECT datediff(YY, Member_Date_Of_Birth, getdate()) as age from member_table WHERE Member_Number = '" + MemberDropDownList.SelectedValue + "'";

            SqlDataAdapter age = new SqlDataAdapter(memberAge, gc.cn);
            DataTable dt = new DataTable();

            age.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MemberAgeLabel.Text = dr[0].ToString();
            }
        }

        //display the age restriction 
        protected void ageRestriction()
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();

            string ageRestrict = "SELECT dct.Age_Restricted FROM dvd_copy_table dc JOIN dvd_title_table dt ON dc.DVD_Number = dt.DVD_Number JOIN dvd_category_table dct ON dt.Category_Number = dct.Category_Number WHERE dc.Copy_Number='" + CopyNumberDropDownList.SelectedValue + "'";


            SqlDataAdapter ar = new SqlDataAdapter(ageRestrict, gc.cn);
            DataTable car = new DataTable();

            ar.Fill(car);
            foreach (DataRow dr in car.Rows)
            {
                AgeRestrictionLabel.Text = dr[0].ToString();
            }
        }

        //display total charges calculating with loan duration and charge perday

        protected void LoanTypeNumberDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoanDuration();

            Date_Due_Label.Text = DateTime.Now.AddDays(Convert.ToInt32(Loan_Duration_Label.Text)).ToLongDateString();
            TotalChargePerDayLabel.Text = (Convert.ToInt32(ChargePerDayLabel.Text) * Convert.ToInt32(Loan_Duration_Label.Text)).ToString();
        }


        protected void CopyNumberDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            standardCharge();
            ageRestriction();
            TotalChargePerDayLabel.Text = (Convert.ToInt32(ChargePerDayLabel.Text) * Convert.ToInt32(Loan_Duration_Label.Text)).ToString();
        }

        protected void MemberDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            memberAge();
        }


        //issue new loan
        protected void AddLoanButton_Click(object sender, EventArgs e)
        {




            try
            {
                string LoanNumberType = LoanTypeNumberDropDownList.SelectedValue;
                string CopyNumber = CopyNumberDropDownList.SelectedValue;
                string MemberNumber = MemberDropDownList.SelectedValue;
                string DateOut = DateTime.Now.ToShortDateString();
                string DateDue = DateTime.Now.AddDays(Int32.Parse(Loan_Duration_Label.Text)).ToShortDateString();

                //check the user age and the age restriction validation
                if (Int32.Parse(MemberAgeLabel.Text) < 18 && AgeRestrictionLabel.Text == "Age is Restricted")
                {
                    resultLabel.Text = "Age is Restricted";
                }
                else
                {

                    LoanClass dtc = new LoanClass();
                    dtc.AddLoann(Convert.ToInt32(LoanNumberType), Convert.ToInt32(CopyNumber), Convert.ToInt32(MemberNumber), DateOut, DateDue);
                    resultLabel.Text = "Loan Added Succsesfully";
                }




            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

    }
}