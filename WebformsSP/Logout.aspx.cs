using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kentor.AuthServices.HttpModule;
using Kentor.AuthServices.Configuration;
using Kentor.AuthServices.WebSso;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace WebformsSP
{
    public partial class Logout : System.Web.UI.Page
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
        /// Logout locally and if Idp supports it, perform a federated logout
        /// </summary>
        /// <returns>ActionResult</returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (options == null)
            {
                options = Kentor.AuthServices.Configuration.Options.FromConfiguration;
            }
            if (options != null)
            {
                    var result = CommandFactory.GetCommand(CommandFactory.LogoutCommandName).Run(
                        HttpRequestBaseExtensions.ToHttpRequestData(new HttpRequestWrapper(Request)), Options);
                    result.SignInOrOutSessionAuthenticationModule();
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