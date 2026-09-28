using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE
{
    public partial class pageLOGIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassWord.Text == "admin")
            {
                Session.Timeout = 2;
                Session["ADMIN"] = "admin";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng nhập quản trị thành công!'); window.location.href='Danhsachsanpham.aspx';", true);
            }
            else
            {
                XULYDULIEU xuly = new XULYDULIEU();
                SqlParameter[] pr = new SqlParameter[2];
                pr[0] = new SqlParameter("@USERNAME", txtUserName.Text);
                pr[1] = new SqlParameter("@PASSWORD", txtPassWord.Text);
                
                DataTable tbLOGIN = xuly.getTable("psGetTableLOGIN", pr);
                
                if (tbLOGIN.Rows.Count > 0)
                {
                    Session.Timeout = 2;
                    Session["LOGIN"] = tbLOGIN;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng nhập thành công!'); window.location.href='pageGIOHANG.aspx';", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng nhập thất bại. Vui lòng kiểm tra lại tài khoản hoặc mật khẩu!');", true);
                }
            }
        }
    }
}
