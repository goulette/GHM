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
    public partial class EditCarrierContacts : System.Web.UI.Page
    {
        int CarrierID;
        int ContactTypeID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out CarrierID);
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ContactTypeID = CarrierContactTypeDropDownList.SelectedValue.ToString();
                string getcontacts = "SELECT * from CarrierContacts WHERE CarrierID = " + CarrierID + " AND ContactTypeID = " + ContactTypeID;
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(getcontacts, conn);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    CarrierContactList.DataSource = rdr;
                    CarrierContactList.DataTextField = "ContactName";
                    CarrierContactList.DataValueField = "Id";
                    CarrierContactList.DataBind();
                    rdr.Close();
                    conn.Close();
                }
                string AddString = "Add New " + CarrierContactTypeDropDownList.SelectedItem.Text + " Contact...";
                CarrierContactList.Items.Insert(0, new ListItem(AddString, "0"));
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(CarrierContactList.SelectedValue.ToString());
            ContactTypeID = Int32.Parse(CarrierContactTypeDropDownList.SelectedValue.ToString());
            string ContactNameText = ContactNameTextBox.Text;
            string ContactTitleText = ContactTitleTextBox.Text;
            string ContactPhoneText = ContactPhoneTextBox.Text;
            string ContactFaxText = ContactFaxTextBox.Text;
            string ContactEmailText = ContactEmailTextBox.Text;

            string getcontacts = "SELECT * from CarrierContacts WHERE CarrierID = " + CarrierID + " AND ContactTypeID = " + CarrierContactTypeDropDownList.SelectedValue;
            EditCarrierContactLabel.Text = getcontacts;
            if (ContactNameText.Length == 0)
            {
                ErrorMsg.Text = "You must enter a Contact Name!";
                return;
            }

            if (i == 0)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddCarrierContact", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                    cmd.Parameters.AddWithValue("@contacttypeid", ContactTypeID);
                    cmd.Parameters.AddWithValue("@contactname", ContactNameText);
                    cmd.Parameters.AddWithValue("@contacttitle", ContactTitleText);
                    cmd.Parameters.AddWithValue("@contactphone", ContactPhoneText);
                    cmd.Parameters.AddWithValue("@contactfax", ContactFaxText);
                    cmd.Parameters.AddWithValue("@contactemail", ContactEmailText);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                    conn.Close();
                }
            }
            else
            {
            }
            string TransferString;
            TransferString = "~/EditCarrierContacts.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }

        protected void CarrierContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Int32.Parse(CarrierContactList.SelectedValue.ToString());

            if (i == 0)
            {
                ContactNameTextBox.Text = "";
                ContactTitleTextBox.Text = "";
                ContactPhoneTextBox.Text = "";
                ContactFaxTextBox.Text = "";
                ContactEmailTextBox.Text = "";
                //CarrierContactList.Items.Clear();
            }
            else
            {
                ContactTypeID = Int32.Parse(CarrierContactTypeDropDownList.SelectedValue.ToString());
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetCarrierContacts", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", i);
                    cmd.Parameters.AddWithValue("@carrierid", CarrierID);
                    cmd.Parameters.AddWithValue("@contacttypeid", ContactTypeID);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        ContactNameTextBox.Text = rdr["ContactName"].ToString();
                        ContactTitleTextBox.Text = rdr["ContactTitle"].ToString();
                        ContactPhoneTextBox.Text = rdr["ContactPhone"].ToString();
                        ContactFaxTextBox.Text = rdr["ContactFax"].ToString();
                        ContactEmailTextBox.Text = rdr["ContactEmail"].ToString();
                    }
                    rdr.Close();
                    conn.Close();
                }
            }
        }

        protected void CarrierContactTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarrierContactList.Items.Clear();
            ContactTypeID = Int32.Parse(CarrierContactTypeDropDownList.SelectedValue.ToString());
            string getcontacts = "SELECT * from CarrierContacts WHERE CarrierID = " + CarrierID + " AND ContactTypeID = " + ContactTypeID;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(getcontacts, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                CarrierContactList.DataSource = rdr;
                CarrierContactList.DataTextField = "ContactName";
                CarrierContactList.DataValueField = "Id";
                CarrierContactList.DataBind();
                rdr.Close();
                conn.Close();
            }
            string AddString = "Add New " + CarrierContactTypeDropDownList.SelectedItem.Text + " Contact...";
            CarrierContactList.Items.Insert(0, new ListItem(AddString, "0"));
            ContactNameTextBox.Text = "";
            ContactTitleTextBox.Text = "";
            ContactPhoneTextBox.Text = "";
            ContactFaxTextBox.Text = "";
            ContactEmailTextBox.Text = "";
        }

        protected void CarrierContactTypeDropDownList_DataBound(object sender, EventArgs e)
        {
            ContactTypeID = CarrierContactTypeDropDownList.SelectedIndex;
            string getcontacts = "SELECT * from CarrierContacts WHERE CarrierID = " + CarrierID + " AND ContactTypeID = " + ContactTypeID;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GHMConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(getcontacts, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                CarrierContactList.DataSource = rdr;
                CarrierContactList.DataTextField = "ContactName";
                CarrierContactList.DataValueField = "Id";
                CarrierContactList.DataBind();
                rdr.Close();
                conn.Close();
            }
        }
    }
}