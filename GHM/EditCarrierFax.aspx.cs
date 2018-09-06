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
    public partial class EditCarrierFax : System.Web.UI.Page
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(FaxDropDownList.SelectedValue.ToString());

            if (DescriptionTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Description!";
                return;
            }

            if (FaxTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Fax Number!";
                return;
            }

            if (i == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddFax", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                    cmd.Parameters.AddWithValue("@faxdescription", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@faxnumber", FaxTextBox.Text);

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
                    SqlCommand cmd = new SqlCommand("spUpdateFax", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);
                    cmd.Parameters.AddWithValue("@faxdescription", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@faxnumber", FaxTextBox.Text);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Close();
                    conn.Close();
                }
            }
            string TransferString;
            TransferString = "~/EditCarrierFax.aspx?id=" + CarrierID;
            Server.Transfer(TransferString);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;
            Server.Transfer(TransferString);
        }

        protected void FaxDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Int32.Parse(FaxDropDownList.SelectedValue.ToString());

            if (i == 0)
            {
                DescriptionTextBox.Text = "";
                FaxTextBox.Text = "";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetFaxDetails", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    DescriptionTextBox.Text = rdr["FaxDescription"].ToString();
                    FaxTextBox.Text = rdr["FaxNumber"].ToString();

                    rdr.Close();
                    conn.Close();
                }
            }
        }
    }
}