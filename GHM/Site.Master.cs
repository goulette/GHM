using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CarrierDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("CarrierInfo.aspx?id=" + CarrierDropDownList.SelectedValue);
        }

        protected void UsefulSitesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("UsefulSite.aspx?id=" + UsefulSitesDropDownList.SelectedValue);
        }
    }
}