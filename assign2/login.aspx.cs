using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// identity references
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;

namespace assign2
{
    public partial class loging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //initialize a userstore, usermanager and user variables
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // try to find the user with the credentials entered
            var user = userManager.Find(txtUsername.Text, txtPassword.Text);

            // if the user is found, create a cookie to store their identity and log them in
            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties()
                { IsPersistent = false }, userIdentity);

                // show the desired page
                Response.Redirect("dummy.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Login";
                lblMessage.CssClass = "alert alert-danger col-sm-offset-3";
            }
        }
    }
}