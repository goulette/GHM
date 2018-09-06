using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void EditButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCarrier.aspx?id=" + CarriersDropDownList.SelectedValue);
        }

        protected void EditUsefulSiteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUsefulSite.aspx?id=" + UsefulSitesDropDownList.SelectedValue);
        }

        protected void EditContactType_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditContactType.aspx?id=" + ContactTypeDropDownList.SelectedValue);
        }

        protected void EditCompanyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCompanyNameCodes.aspx?id=" + CompanyNameDropDownList.SelectedValue);
        }

        protected void DeleteUsefulSiteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteUsefulSite.aspx?id=" + UsefulSitesDropDownList.SelectedValue);
        }
    }
}