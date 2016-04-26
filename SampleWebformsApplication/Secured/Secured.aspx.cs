using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebformsApplication.Secured
{
    public partial class Secured : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var c in System.Security.Claims.ClaimsPrincipal.Current.Claims)
            {
                lblClaims.Text = lblClaims.Text + c.Type + " - " + c.Value + "<br>";
            }

            LogOutPageLink.NavigateUrl = "http://localhost:64827/Logout.aspx?rURL=" + HttpUtility.UrlEncode("http://localhost:53616/Default.aspx");
        }
    }
}