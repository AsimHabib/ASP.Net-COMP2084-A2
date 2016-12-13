using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.ModelBinding;

namespace assign2
{
    public partial class viewlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                   
                // display the items in gridView
                getList();

        }
        protected void getList()
        {
            // connect to DB
            var conn = new ATwoEntities();

            // run the query using LINQ
            var Lists = from i in conn.tbl_list_item
                        where i.UserName == User.Identity.Name
                        select i;
           
            // display query result in gridview
            grdList.DataSource = Lists.ToList();
            grdList.DataBind();

        }

        protected void grdList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Fuunction to delete item fom the gridview
            //1. determine which row in the grid  the user clicked
            Int32 gridIndex = e.RowIndex;

            //2.find the itemID value in the selected row
            Int32 itemID = Convert.ToInt32(grdList.DataKeys[gridIndex].Value);

            //3. connect to db
            var conn = new ATwoEntities();

            //4.delete the selected item
            tbl_list_item d = new tbl_list_item();
            d.itemID = itemID;
            conn.tbl_list_item.Attach(d);
            conn.tbl_list_item.Remove(d);
            conn.SaveChanges();

            //5. refreh the grid
            getList();

        }
    }
}