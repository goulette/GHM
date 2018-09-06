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
    public partial class EditUsefulSite : System.Web.UI.Page
    {
        int UsefulSiteID;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out UsefulSiteID);

            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetUsefulSiteDetail", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", UsefulSiteID);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    UsefulSiteTextBox.Text = rdr["UsefulSiteURL"].ToString();
                    DescriptionTextBox.Text = rdr["UsefulSiteDescription"].ToString();
                    if (rdr["CredentialsYN"].ToString() == "1")
                    {
                        UsefulSiteCredentialsCheckBox.Checked = true;
                        UsefulSiteUsernameTextBox.Text = rdr["UsefulSiteCredentialUsername"].ToString();
                        UsefulSitePasswordTextBox.Text = rdr["UsefulSiteCredentialPassword"].ToString();
                        UsefulSiteUsernameTextBox.Enabled = true;
                        UsefulSitePasswordTextBox.Enabled = true;
                    }
                    rdr.Close();
                    conn.Close();
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UsefulSiteDescription = DescriptionTextBox.Text.ToString();
            string UsefulSiteURL = UsefulSiteTextBox.Text.ToString();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateUsefulSite", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", UsefulSiteID);
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