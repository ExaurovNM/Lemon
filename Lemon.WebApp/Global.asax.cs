using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lemon.WebApp
{
    using System.Security.Principal;
    using System.Web.Script.Serialization;
    using System.Web.Security;

    using Lemon.WebApp.WebHelpers;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            var customPrincipal = new CustomPrincipal(string.Empty);
            HttpContext.Current.User = customPrincipal;

            if (authCookie == null)
            {
                
                return;
            }
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            var serializer = new JavaScriptSerializer();

            var serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

            if (serializeModel == null)
            {
                return;
            }

            var newUser = new CustomPrincipal(authTicket.Name)
                {
                    Email = serializeModel.Email,
                    Id = serializeModel.Id
                };

            HttpContext.Current.User = newUser;
        }
    }
}