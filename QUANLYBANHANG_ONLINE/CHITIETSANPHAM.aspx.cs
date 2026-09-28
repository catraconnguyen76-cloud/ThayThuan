using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace QUANLYBANHANG_ONLINE
{
    public partial class CHITIETSANPHAM : System.Web.UI.Page
    {
        DataTable tbSANPHAM;

        protected void Page_Load(object sender, EventArgs e)
        {
            XULYDULIEU xuly = new XULYDULIEU();
            string masanpham = Request.QueryString.Get("MASANPHAM");
            
            string sql = "SELECT * FROM tbSANPHAM";
            if (!string.IsNullOrEmpty(masanpham))
            {
                sql += " WHERE MASANPHAM=" + masanpham;
            }

            tbSANPHAM = xuly.getTable(sql);

            if (!IsPostBack)
            {
                this.Repeater1.DataSource = tbSANPHAM;
                this.Repeater1.DataBind();
            }
        }

        protected void Imagecart_Click(object sender, ImageClickEventArgs e)
        {
            Session.Timeout = 2;
            CART cart = new CART();
            if (Session["CART"] != null)
            {
                cart = (CART)Session["CART"];
            }

            if (tbSANPHAM != null && tbSANPHAM.Rows.Count > 0)
            {
                string masanpham = tbSANPHAM.Rows[0]["MASANPHAM"].ToString();
                string tensanpham = tbSANPHAM.Rows[0]["TENSANPHAM"].ToString();
                double dongia = Double.Parse(tbSANPHAM.Rows[0]["DONGIA"].ToString());
                string hinhanh = tbSANPHAM.Rows[0]["HINHANH"].ToString();

                cart.AddCart(masanpham, tensanpham, hinhanh, 1, dongia);
                Session["CART"] = cart;
                Response.Redirect("pageGIOHANG.aspx");
            }
        }
    }
}
