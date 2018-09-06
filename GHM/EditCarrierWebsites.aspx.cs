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
    public partial class EditCarrierWebsites : System.Web.UI.Page
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(WebsiteDropDownList.SelectedValue.ToString());

            if (DescriptionTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Description!";
                return;
            }

            if (WebsiteTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Website URL!";
                return;
            }
            string DescriptionText = DescriptionTextBox.Text;
            string WebsiteText = WebsiteTextBox.Text;
            int WebsiteID = WebsiteDropDownList.SelectedIndex;

            if (i == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddWebsite", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                    cmd.Parameters.AddWithValue("@websitedescription", DescriptionText);
                    cmd.Parameters.AddWithValue("@URL", WebsiteText);

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
                    SqlCommand cmd = new SqlCommand("spUpdateWebsite", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);
                    cmd.Parameters.AddWithValue("@websitedescription", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@URL", WebsiteTextBox.Text);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Close();
                    conn.Close();
                }
            }
            string TransferString;
            TransferString = "~/EditCarrierWebsites.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void WebsiteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Int32.Parse(WebsiteDropDownList.SelectedValue.ToString());

            if (i == 0)
            {
                DescriptionTextBox.Text = "";
                WebsiteTextBox.Text = "";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetWebsiteDetails", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    DescriptionTextBox.Text = rdr["WebsiteDescription"].ToString();
                    WebsiteTextBox.Text = rdr["URL"].ToString();

                    rdr.Close();
                    conn.Close();
                }
            }
        }
    }
}