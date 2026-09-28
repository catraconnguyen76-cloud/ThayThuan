using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE
{
    public partial class MasterPageUser : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XULYDULIEU xuly = new XULYDULIEU();
                SqlParameter[] pr = new SqlParameter[1];
                pr[0] = new SqlParameter("@MADANHMUC", DBNull.Value);
                this.Repeater1.DataSource = xuly.getTable("psGetTableDANHMUC", pr);
                this.Repeater1.DataBind();
            }

            // Update Shopping Cart info
            int itemCount = 0;
            double total = 0;

            if (Session["CART"] != null)
            {
                CART cart = (CART)Session["CART"];
                foreach (var item in cart.LISTCARTS.Values)
                {
                    itemCount += item.SOLUONG;
                }
                total = cart.TotalBill();
            }

            lblCartItemCount.Text = itemCount + " items";
            lblCartTotal.Text = total + "$";
        }
    }
}