using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Kentor.AuthServices;
using Kentor.AuthServices.HttpModule;
using Kentor.AuthServices.Configuration;
using Kentor.AuthServices.WebSso;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace WebformsSP
{
    public partial class SignIn : System.Web.UI.Page
    {
        private static IOptions options = null;

        public static IOptions Options
        {
            get
            {
                if (options == null)
                {
                    options = Kentor.AuthServices.Configuration.Options.FromConfiguration;
                }
                return options;
            }
            set
            {
                options = value;
            }
        }

        /// <summary>
        /// SignIn action that sends the AuthnRequest to the Idp.
        /// </summary>
        /// <returns>Redirect with sign in request</returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (options == null)
            {
                //sometimes this doesnt seem to be built correctly on the class constructor, depending how the link is navigated to so lets be sure
                options = Kentor.AuthServices.Configuration.Options.FromConfiguration;
            }

            if (options!=null)
            {
                //since we cant bring a 'page' into a dll like mvc, or easily make a variable in the webconfig,
                //we pass the return url as a parameter and override it after the options is built but before it is used.
                //we just need to make sure any call in another webconfig to a sign in includes this parameter, i.e.
                // <authentication mode="Forms">
                //      < forms loginUrl = "~/AuthServices/SignIn?rURL=[address to return to]" /> 
                //</ authentication >

                string returnUrl = Request.QueryString["rURL"];
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    options.SPOptions.ReturnUrl = new System.Uri(returnUrl);

                    var result = CommandFactory.GetCommand(CommandFactory.SignInCommandName).Run(
                        HttpRequestBaseExtensions.ToHttpRequestData(new HttpRequestWrapper(Request)), Options);
                    result.ApplyCookies(new HttpResponseWrapper(Response));

                    if (result != null)
                    {
                        if (result.HttpStatusCode == HttpStatusCode.SeeOther)
                        {
                            Response.Redirect(result.Location.OriginalString);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }
            }
        }
    }
}
