using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assign2
{
    public partial class addlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                

                // check the url for the an id so we know if we are adding or editing
                if (!String.IsNullOrEmpty(Request.QueryString["itemID"]))
                {
                    // get id from URL
                    Int32 itemID = Convert.ToInt32(Request.QueryString["itemID"]);

                    // connect DB
                    var conn = new ATwoEntities();

                    // look up the selected item
                    var objItem = (from i in conn.tbl_list_item
                                  where i.itemID == itemID
                                  select i).FirstOrDefault();

                    // populate the form
                    txtitemName.Text = objItem.itemName;
                }

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            // check if we have an id to decide if we are adding or editing
            Int32 itemID = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["itemID"]))
            {
                itemID = Convert.ToInt32(Request.QueryString["itemID"]);
            }

            // DB connection
            var conn = new ATwoEntities();

            // Create new Object          
            tbl_list_item i = new tbl_list_item();

            // fill the properties of new object
            i.itemName = txtitemName.Text;
            i.UserName = User.Identity.Name; 

            //save a new object to db
            if (itemID == 0)
            {
                conn.tbl_list_item.Add(i);                
            }
            else
            {
                i.itemID = itemID;
                conn.tbl_list_item.Attach(i);
                conn.Entry(i).State = System.Data.Entity.EntityState.Modified;
            }

            conn.SaveChanges();

            // page redirection
            Response.Redirect("viewlist.aspx");
        }
    }
}