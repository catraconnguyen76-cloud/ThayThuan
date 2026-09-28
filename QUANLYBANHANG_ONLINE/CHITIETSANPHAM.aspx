<%@ Page Title="Chi tiết sản phẩm" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="CHITIETSANPHAM.aspx.cs" Inherits="QUANLYBANHANG_ONLINE.CHITIETSANPHAM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
        <div class="center_title_bar">Chi tiết sản phẩm</div>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="prod_box_big">
                    <div class="top_prod_box_big"></div>
                    <div class="center_prod_box_big">
                        <div class="product_img_big">
                            <a href="javascript:popImage('images/<%# Eval("HINHANH") %>','Some Title')" title="header=[Zoom] body=[&nbsp;] fade=[on]">
                                <img src="images/<%# Eval("HINHANH") %>" alt="" border="0" width="150" />
                            </a>
                        </div>
                        <div class="details_big_box">
                            <div class="product_title_big"><%# Eval("TENSANPHAM") %></div>
                            <div class="specifications">
                                <p><%# Eval("MOTA") %></p>
                            </div>
                            <div class="prod_price_big">
                                <span class="reduce">350$</span> <span class="price"><%# Eval("DONGIA") %></span>
                            </div>
                            <asp:ImageButton ID="Imagecart" runat="server" ImageUrl="images/cart.gif" class="left_bt" OnClick="Imagecart_Click" />
                        </div>
                    </div>
                    <div class="bottom_prod_box_big"></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
