using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QUANLYBANHANG_ONLINE.ADMIN.BUSINESSLOGIC;

namespace QUANLYBANHANG_ONLINE.ADMIN.GUI
{
    public partial class QUANLYSANPHAM_GUI : System.Web.UI.Page
    {
        QUANLYSANPHAM_BUSINESSLOGIC businesslogic;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMIN"] == null)
            {
                Response.Write("<script>alert('Bạn chưa đăng nhập! Bạn không có quyền truy cập trang quản trị.'); window.location.href='../../pageLOGIN.aspx';</script>");
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            businesslogic = new QUANLYSANPHAM_BUSINESSLOGIC(this);
            if (!IsPostBack)
            {
                businesslogic.SetValueDropdownlistDanhMuc();
                businesslogic.SetValueGridViewSanPham();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int k = businesslogic.InsertRecordSanPham();
            businesslogic.SetValueGridViewSanPham();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            businesslogic.DeleteRecordSanPham();
            businesslogic.SetValueGridViewSanPham();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int k = businesslogic.updateRecordSanPham();
            businesslogic.SetValueGridViewSanPham();
        }

        protected void grvSANPHAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMASANPHAM.Text = grvSANPHAM.SelectedRow.Cells[1].Text;
            txtTENSANPHAM.Text = grvSANPHAM.SelectedRow.Cells[2].Text;
            txtDONGIA.Text = grvSANPHAM.SelectedRow.Cells[3].Text;
            txtSOLUONG.Text = grvSANPHAM.SelectedRow.Cells[4].Text;
        }
    }
}
