<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QUANLYSANPHAM_GUI.aspx.cs" Inherits="QUANLYBANHANG_ONLINE.ADMIN.GUI.QUANLYSANPHAM_GUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý danh sách sản phẩm</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="margin-bottom: 15px;">
                <a href="../../Danhsachsanpham.aspx" style="text-decoration: none; padding: 8px 15px; background-color: #4CAF50; color: white; border-radius: 4px; font-family: Arial, sans-serif; font-size: 14px;">&laquo; Quay lại Trang chủ</a>
            </div>
            <h2>QUẢN LÝ DANH SÁCH SẢN PHẨM</h2>
            <table>
                <tr>
                    <td>Mã danh mục</td>
                    <td><asp:DropDownList ID="drpDANHMUC" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Mã sản phẩm</td>
                    <td><asp:TextBox ID="txtMASANPHAM" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Tên sản phẩm</td>
                    <td><asp:TextBox ID="txtTENSANPHAM" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Đơn giá</td>
                    <td><asp:TextBox ID="txtDONGIA" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Số lượng</td>
                    <td><asp:TextBox ID="txtSOLUONG" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Upload Ảnh</td>
                    <td><asp:FileUpload ID="FileANHSANPHAM" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">MÔ TẢ (ID=txtMOTA)<br />
                        <asp:TextBox ID="txtMOTA" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnInsert" runat="server" Text="Thêm mới" OnClick="btnInsert_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Sửa" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
            </table>

            <br />
            <asp:GridView ID="grvSANPHAM" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="MASANPHAM" OnSelectedIndexChanged="grvSANPHAM_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="MASANPHAM" HeaderText="Mã sản phẩm" />
                    <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên sản phẩm" />
                    <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" />
                    <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                    <asp:ImageField DataImageUrlField="HINHANH" DataImageUrlFormatString="~/images/{0}" HeaderText="Ảnh sản phẩm" ControlStyle-Width="100px" ControlStyle-Height="100px"></asp:ImageField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
