using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System.Web.Helpers;
using System.Security.Claims;

[assembly: OwinStartup(typeof(ThemeParkManagementSystem.Startup1))]

namespace ThemeParkManagementSystem
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/LogOn")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
