using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class EditCarrierPhone : System.Web.UI.Page
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(PhoneDropDownList.SelectedValue.ToString());

            if (DescriptionTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Description!";
                return;
            }

            if (PhoneTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Phone Number!";
                return;
            }

            if (i == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddPhone", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                    cmd.Parameters.AddWithValue("@phonedescription", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", PhoneTextBox.Text);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Close();
                    conn.Close();
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdatePhone", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);
                    cmd.Parameters.AddWithValue("@phonedescription", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", PhoneTextBox.Text);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Close();
                    conn.Close();
                }
            }
            string TransferString;
            TransferString = "~/EditCarrierPhone.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void PhoneDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Int32.Parse(PhoneDropDownList.SelectedValue.ToString());

            if (i == 0)
            {
                DescriptionTextBox.Text = "";
                PhoneTextBox.Text = "";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetPhoneDetails", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    DescriptionTextBox.Text = rdr["PhoneDescription"].ToString();
                    PhoneTextBox.Text = rdr["PhoneNumber"].ToString();

                    rdr.Close();
                    conn.Close();
                }
            }
        }
    }
}