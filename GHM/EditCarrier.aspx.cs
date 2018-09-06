using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class EditCarrier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetailsLink.NavigateUrl = "~/EditCarrierDetails.aspx?id=" + Request.QueryString["id"];
            AddressLink.NavigateUrl = "~/EditCarrierAddress.aspx?id=" + Request.QueryString["id"];
            PhoneLink.NavigateUrl = "~/EditCarrierPhone.aspx?id=" + Request.QueryString["id"];
            FaxLink.NavigateUrl = "~/EditCarrierFax.aspx?id=" + Request.QueryString["id"];
            CodesLink.NavigateUrl = "~/EditCarrierCodes.aspx?id=" + Request.QueryString["id"];
            ContactsLink.NavigateUrl = "~/EditCarrierContacts.aspx?id=" + Request.QueryString["id"];
            WebsitesLink.NavigateUrl = "~/EditCarrierWebsites.aspx?id=" + Request.QueryString["id"];
            DocumentsLink.NavigateUrl = "~/EditCarrierDocuments.aspx?id=" + Request.QueryString["id"];
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "admin.aspx";
            Response.Redirect(TransferString);
        }
    }
}