using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

// add references for asp.net identity
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Week9.Startup))]

namespace Week9
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // set up cookie configuration to track authenticated users
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/login.aspx")
            });
        }
    }
}
