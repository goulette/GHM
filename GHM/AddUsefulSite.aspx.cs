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
    public partial class AddUsefulSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UsefulSiteDescription = DescriptionTextBox.Text.ToString();
            string UsefulSiteURL = UsefulSiteTextBox.Text.ToString();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUsefulSite", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usefulsitedescription", UsefulSiteDescription);
                cmd.Parameters.AddWithValue("@usefulsiteURL", UsefulSiteURL);

                if (UsefulSiteCredentialsCheckBox.Checked == true)
                {
                    string UsefulSiteCredentialUsername = UsefulSiteUsernameTextBox.Text.ToString();
                    string UsefulSiteCredentialPassword = UsefulSitePasswordTextBox.Text.ToString();

                    cmd.Parameters.AddWithValue("@credentials", 1);
                    cmd.Parameters.AddWithValue("@usefulsitecredentialusername", UsefulSiteCredentialUsername);
                    cmd.Parameters.AddWithValue("@usefulsitecredentialpassword", UsefulSiteCredentialPassword);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@credentials", 0);
                    cmd.Parameters.AddWithValue("@usefulsitecredentialusername", DBNull.Value);
                    cmd.Parameters.AddWithValue("@usefulsitecredentialpassword", DBNull.Value);
                }

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                conn.Close();
                Response.Redirect("admin.aspx");
            }
        }

        protected void UsefulSiteCredentialsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UsefulSiteCredentialsCheckBox.Checked == true)
            {
                UsefulSiteUsernameTextBox.Enabled = true;
                UsefulSitePasswordTextBox.Enabled = true;
            }
            else
            {
                UsefulSiteUsernameTextBox.Enabled = false;
                UsefulSitePasswordTextBox.Enabled = false;
            }
        }
    }
}