using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class AddContactType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            string ContactType = ContactTypeTextBox.Text.ToString();

            if (ContactType.Length == 0)
            {
                ErrorMsg.Text = "You must enter a contact type!";
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddContactType", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@contacttypedescription", ContactType);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                conn.Close();
                Response.Redirect("admin.aspx");
            }
        }
    }
}