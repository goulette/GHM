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
    public partial class EditCarrierCodes : System.Web.UI.Page
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(CarrierCodeDropDownList.SelectedValue.ToString());

            if (CodeTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter an Agency Code!";
                return;
            }

            if (i == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddCarrierCode", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                    cmd.Parameters.AddWithValue("@agencyid", AgencyDropDownList.SelectedValue);
                    cmd.Parameters.AddWithValue("@carriercode", CodeTextBox.Text);

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
                    SqlCommand cmd = new SqlCommand("spUpdateCarrierCode", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);
                    cmd.Parameters.AddWithValue("@CarrierCode", CodeTextBox.Text);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Close();
                    conn.Close();
                }
            }
            string TransferString;
            TransferString = "~/EditCarrierCodes.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void CarrierCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Int32.Parse(CarrierCodeDropDownList.SelectedValue.ToString());

            if (i == 0)
            {
                AgencyLabel.Visible = true;
                AgencyDropDownList.Visible = true;
                CodeTextBox.Text = "";
            }
            else
            {
                AgencyLabel.Visible = false;
                AgencyDropDownList.Visible = false;
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetCarrierCodeDetails", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    CodeTextBox.Text = rdr["CarrierCode"].ToString();
                    AgencyDropDownList.SelectedValue = rdr["AgencyID"].ToString();
                    rdr.Close();
                    conn.Close();
                }
            }

        }
    }
}