using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QUANLYBANHANG_ONLINE
{
    public partial class Danhsachsanpham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XULYDULIEU xuly = new XULYDULIEU();
                string madanhmuc = Request.QueryString.Get("MADANHMUC");
                
                string sql = "SELECT * FROM tbSANPHAM";
                if (!string.IsNullOrEmpty(madanhmuc))
                {
                    sql += " WHERE MADANHMUC=" + madanhmuc;
                }

                this.DataList1.RepeatColumns = 3;
                this.DataList1.DataSource = xuly.getTable(sql);
                this.DataList1.DataBind();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                string[] args = e.CommandArgument.ToString().Split('|');
                if (args.Length == 4)
                {
                    string masanpham = args[0];
                    string tensanpham = args[1];
                    string hinhanh = args[2];
                    double dongia = 0;
                    Double.TryParse(args[3], out dongia);

                    Session.Timeout = 2;
                    CART cart = new CART();
                    if (Session["CART"] != null)
                    {
                        cart = (CART)Session["CART"];
                    }

                    cart.AddCart(masanpham, tensanpham, hinhanh, 1, dongia);
                    Session["CART"] = cart;
                    Response.Redirect("pageGIOHANG.aspx");
                }
            }
        }
    }
}