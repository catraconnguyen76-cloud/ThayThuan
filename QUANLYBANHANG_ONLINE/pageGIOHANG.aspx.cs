using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace QUANLYBANHANG_ONLINE
{
    public partial class pageGIOHANG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        public void LoadCart()
        {
            if (Session["CART"] != null)
            {
                CART cart = (CART)Session["CART"];
                this.grvCART.DataSource = cart.LISTCARTS.Values.ToList();
                this.grvCART.DataBind();
                
                if (this.grvCART.Rows.Count > 0)
                {
                    this.grvCART.FooterRow.Cells[0].Text = "Tổng tiền =";
                    this.grvCART.FooterRow.Cells[4].Text = cart.TotalBill().ToString();
                }
            }
        }

        protected void btnDELETE_Click(object sender, EventArgs e)
        {
            if (Session["CART"] != null)
            {
                CART cart = (CART)Session["CART"];
                foreach (GridViewRow row in grvCART.Rows)
                {
                    CheckBox ckb = (CheckBox)row.FindControl("ckbREMOVEITEM");
                    if (ckb != null && ckb.Checked)
                    {
                        string masanpham = row.Cells[0].Text;
                        cart.RemoveCart(masanpham);
                    }
                }
                Session["CART"] = cart;
                LoadCart();
            }
        }
    }
}
