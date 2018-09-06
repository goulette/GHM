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
    public partial class EditCarrierAddress : System.Web.UI.Page
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetCarrierAddress", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", CarrierID);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                rdr.Close();
                conn.Close();
            }
            string getstates = "SELECT * from State";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(getstates, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                StateDropDownList.DataSource = rdr;
                StateDropDownList.DataTextField = "Name";
                StateDropDownList.DataValueField = "Id";
                StateDropDownList.DataBind();
                rdr.Close();
                conn.Close();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string DescriptionText = DescriptionTextBox.Text;
            string Address1Text = Address1TextBox.Text;
            string Address2Text = Address2TextBox.Text;
            string Address3Text = Address3TextBox.Text;
            string CityText = CityTextBox.Text;
            string ZipText = ZipTextBox.Text;
            int CountryID = Convert.ToInt32(CountryDropDownList.SelectedValue);
            int StateID = Int32.Parse(StateDropDownList.SelectedValue.ToString());

            int i = Int32.Parse(AddressDropDownList.SelectedValue.ToString());

            if (DescriptionTextBox.Text.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Description!";
                return;
            }

            if (i == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddCarrierAddress", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                    cmd.Parameters.AddWithValue("@addressdescription", DescriptionText);
                    cmd.Parameters.AddWithValue("@address1", Address1Text);
                    cmd.Parameters.AddWithValue("@address2", Address2Text);
                    cmd.Parameters.AddWithValue("@address3", Address3Text);
                    cmd.Parameters.AddWithValue("@countryid", CountryID);
                    cmd.Parameters.AddWithValue("@city", CityText);
                    cmd.Parameters.AddWithValue("@stateid", StateID);
                    cmd.Parameters.AddWithValue("@zip", ZipText);

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
                    SqlCommand cmd = new SqlCommand("spUpdateAddress", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);
                    cmd.Parameters.AddWithValue("@addressdescription", DescriptionText);
                    cmd.Parameters.AddWithValue("@addressline1", Address1Text);
                    cmd.Parameters.AddWithValue("@addressline2", Address2Text);
                    cmd.Parameters.AddWithValue("@addressline3", Address3Text);
                    cmd.Parameters.AddWithValue("@countryid", CountryID);
                    cmd.Parameters.AddWithValue("@city", CityText);
                    cmd.Parameters.AddWithValue("@stateid", StateID);
                    cmd.Parameters.AddWithValue("@zip", ZipText);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                    conn.Close();
                }
            }
            string TransferString;
            TransferString = "~/EditCarrierAddress.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void AddressDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Int32.Parse(AddressDropDownList.SelectedValue.ToString());

            if (i == 0)
            {
                DescriptionTextBox.Text = "";
                Address1TextBox.Text = "";
                Address2TextBox.Text = "";
                Address3TextBox.Text = "";
                CityTextBox.Text = "";
                ZipTextBox.Text = "";
                CountryDropDownList.SelectedValue = "1";
                StateDropDownList.SelectedValue = "1";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAddressDetails", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    DescriptionTextBox.Text = rdr["AddressDescription"].ToString();
                    Address1TextBox.Text = rdr["AddressLine1"].ToString();
                    Address2TextBox.Text = rdr["AddressLine2"].ToString();
                    Address3TextBox.Text = rdr["AddressLine3"].ToString();
                    CityTextBox.Text = rdr["City"].ToString();
                    ZipTextBox.Text = rdr["Zip"].ToString();
                    CountryDropDownList.SelectedValue = rdr["CountryID"].ToString();
                    if (CountryDropDownList.SelectedValue == "2")
                    {
                        StateLabel.Text = "Province:";
                        string getprovinces = "SELECT * from Province";
                        using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                        {
                            SqlCommand cmd2 = new SqlCommand(getprovinces, conn2);
                            conn2.Open();
                            SqlDataReader rdr2 = cmd2.ExecuteReader();
                            StateDropDownList.DataSource = rdr2;
                            StateDropDownList.DataTextField = "Name";
                            StateDropDownList.DataValueField = "Id";
                            StateDropDownList.DataBind();
                            rdr2.Close();
                            conn2.Close();
                        }
                    }
                    StateDropDownList.SelectedValue = rdr["StateID"].ToString();

                    rdr.Close();
                    conn.Close();
                }
            }

        }

        protected void CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountryDropDownList.SelectedValue == "1" )
            {
                StateLabel.Text = "State:";
                string getstates = "SELECT * from State";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(getstates, conn);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    StateDropDownList.DataSource = rdr;
                    StateDropDownList.DataTextField = "Name";
                    StateDropDownList.DataValueField = "Id";
                    StateDropDownList.DataBind();
                    rdr.Close();
                    conn.Close();
                }
                return;
            }
            if (CountryDropDownList.SelectedValue == "2")
            {
                StateLabel.Text = "Province:";
                string getprovinces = "SELECT * from Province";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(getprovinces, conn);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    StateDropDownList.DataSource = rdr;
                    StateDropDownList.DataTextField = "Name";
                    StateDropDownList.DataValueField = "Id";
                    StateDropDownList.DataBind();
                    rdr.Close();
                    conn.Close();
                }
                return;
            }
        }
    }
}