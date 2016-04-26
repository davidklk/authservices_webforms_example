using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebformsApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //URL Encode the sign in hyperlink to apply a url in a parameter
            SignInPageLink.NavigateUrl = "http://localhost:64827/SignIn.aspx?rURL=" + HttpUtility.UrlEncode("http://localhost:53616/Secured/Secured.aspx");

            if (!User.Identity.IsAuthenticated)
            {
                status.Text = "not signed in";
                sctLoggedIn.Visible = false;
            }
            else
            {
                status.Text = "signed in";
                sctLoggedOut.Visible = false;
                foreach (var c in System.Security.Claims.ClaimsPrincipal.Current.Claims)
                {
                    lblClaims.Text = lblClaims.Text + c.Type + " - " + c.Value + "<br>";
                }
            }
        }
    }
}