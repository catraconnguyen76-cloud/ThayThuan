<%@ Page Title="Giỏ hàng" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="pageGIOHANG.aspx.cs" Inherits="QUANLYBANHANG_ONLINE.pageGIOHANG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
        <div class="center_title_bar">Giỏ hàng của bạn</div>
        
        <asp:GridView ID="grvCART" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="MASANPHAM" HeaderText="Mã sản phẩm" />
                <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên sản phẩm" />
                <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" />
                <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                <asp:BoundField DataField="THANHTIEN" HeaderText="Thành tiền" />
                <asp:ImageField DataAlternateTextField="HINHANH" DataImageUrlField="HINHANH" DataImageUrlFormatString="images/{0}" HeaderText="Ảnh" ControlStyle-Width="100px" ControlStyle-Height="100px">
                </asp:ImageField>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckbREMOVEITEM" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
        <br />
        <asp:Button ID="btnDELETE" runat="server" Text="Xóa hàng" OnClick="btnDELETE_Click" />
    </div>
</asp:Content>
