<%@ Page Title="Danh sách sản phẩm" Language="C#"
    MasterPageFile="~/MasterPageUser.Master"
    AutoEventWireup="true"
    CodeBehind="Danhsachsanpham.aspx.cs"
    Inherits="QUANLYBANHANG_ONLINE.Danhsachsanpham" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="center_content">
        <div class="center_title_bar">Latest Products</div>

        <!-- Sản phẩm mẫu -->
        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" RepeatColumns="3" RepeatDirection="Horizontal">
            <ItemTemplate>
                <div class="prod_box">
                    <div class="top_prod_box"></div>

                    <div class="center_prod_box">
                        <div class="product_title">
                            <a href="CHITIETSANPHAM.aspx?MASANPHAM=<%# Eval("MASANPHAM") %>"><%# Eval("TENSANPHAM") %></a>
                        </div>

                        <div class="product_img">
                            <a href="CHITIETSANPHAM.aspx?MASANPHAM=<%# Eval("MASANPHAM") %>"><img src="images/<%# Eval("HINHANH") %>"
                                alt="" border="0" width="100px" height="100px" /></a>
                        </div>

                        <div class="prod_price">
                            <span class="reduce">350$</span>
                            <span class="price"><%# Eval("DONGIA") %></span>
                        </div>
                    </div>

                    <div class="bottom_prod_box"></div>

                    <div class="prod_details_tab">
                        <asp:ImageButton ID="imgAddToCart" runat="server" ImageUrl="images/cart.gif" CommandName="AddToCart" CommandArgument='<%# Eval("MASANPHAM") + "|" + Eval("TENSANPHAM") + "|" + Eval("HINHANH") + "|" + Eval("DONGIA") %>' CssClass="left_bt" ToolTip="Add to cart" />

                        <a href="#" title="header=[Specials] body=[&nbsp;] fade=[on]">
                            <img src="images/favs.gif"
                                alt="Specials" border="0" class="left_bt" />
                        </a>

                        <a href="#" title="header=[Gifts] body=[&nbsp;] fade=[on]">
                            <img src="images/favorites.gif"
                                alt="Gifts" border="0" class="left_bt" />
                        </a>

                        <a href='CHITIETSANPHAM.aspx?MASANPHAM=<%# Eval("MASANPHAM") %>' class="prod_details">details</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>

    </div>

</asp:Content>