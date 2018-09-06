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
    public partial class UsefulSite : System.Web.UI.Page
    {
        int UsefulSiteID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out UsefulSiteID);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUsefulSiteDetail", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", UsefulSiteID);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                string SiteURL = rdr["UsefulSiteURL"].ToString();
                string UseCredentials = rdr["CredentialsYN"].ToString();
                string CredentialUsername = rdr["UsefulSiteCredentialUsername"].ToString();
                string CredentialPassword = rdr["UsefulSiteCredentialPassword"].ToString();
                string UsefulSiteDescription = rdr["UsefulSiteDescription"].ToString();

                rdr.Close();
                conn.Close();
                if (UseCredentials == "0")
                {
                    Response.Redirect(SiteURL);
                }
                else
                {
                    CredentialUserNameData.Text = CredentialUsername;
                    CredentialPasswordData.Text = CredentialPassword;
                    UsefulSiteLink.Text = UsefulSiteDescription;
                    UsefulSiteLink.NavigateUrl = SiteURL;
                }
            }
        }
    }
}