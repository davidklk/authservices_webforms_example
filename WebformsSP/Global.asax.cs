using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebformsSP
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            //returnURL overrides the rURL parameter's redirect, can't be disabled and will send back to [SP]/[originalRequestPath]
            //without EnableCrossAppRedirects = true, which has security concerns. Better to just strip it.
            if (HttpContext.Current.Request.Url.ToString().Contains("ReturnUrl") && !System.Web.HttpContext.Current.Request.Url.ToString().Contains("Logout.aspx"))
            {
                HttpContext.Current.Response.Redirect(
                    HttpContext.Current.Request.Url.ToString().Substring(0,
                                HttpContext.Current.Request.Url.ToString().IndexOf("ReturnUrl") - 1)
                );
            }

            //except if we're logging out, then authservices uses the returnURL from the querystring and not the spOptions returnurl property
            if (System.Web.HttpContext.Current.Request.Url.AbsolutePath == "/Logout.aspx" && HttpContext.Current.Request.Url.ToString().Contains("rURL"))
            {
                HttpContext.Current.Response.Redirect(
                   HttpContext.Current.Request.Url.ToString().Substring(0,
                               HttpContext.Current.Request.Url.ToString().IndexOf("rURL=")) + "ReturnUrl" +
                                HttpContext.Current.Request.Url.ToString().Substring(HttpContext.Current.Request.Url.ToString().IndexOf("rURL=") + 4)
               );
            }
        }
    }
}