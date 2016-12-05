using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// reference owin to see if the user is logged in
using Microsoft.Owin.Security;

namespace assign2
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // determine which links to show in the navbar
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                plhPrivate.Visible = true;
                plhPublic.Visible = false;
            }
            else
            {
                plhPrivate.Visible = false;
                plhPublic.Visible = true;
            }
        }
    }
}