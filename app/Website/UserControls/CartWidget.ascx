<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CartWidget.ascx.cs" Inherits="UserControls_CartWidget" %>

<!-- begin CartWidget.ascx -->

<div class="sideBox">
    <div class="title">
        Your Cart
    </div>
    
    <asp:Label ID="lblEmpty" runat="server" Text="There are no items in your cart." />
    <asp:Repeater ID="rpCartItems" runat="server" OnItemDataBound="SetInternals">
        <HeaderTemplate>
            <!-- begin header -->
            <table style="width: 100%;">
            <tr>
                <th align="left">Item</th>
                <th align="right">Count</th>
            </tr>
            <!-- end header -->
        </HeaderTemplate>
        
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="litName" runat="server" /></td>
                <td align="right"><asp:Literal ID="litCount" runat="server" /></td>
            </tr>
        </ItemTemplate>
    
        <FooterTemplate>
            <!-- begin footer -->
            <tr class="totalLine">
                <td>Total</td>
                <td align="right"><asp:Literal ID="litTotal" runat="server" /></td>
            </tr>
            </table>
            <div class="leftHalf">
                <asp:HyperLink ID="lnkCart" runat="server" Text="Edit Cart" NavigateUrl="~/cart.aspx" />
            </div>
            <div class="rightHalf">
                <asp:HyperLink ID="lnkCheckout" runat="server" Text="Check out" NavigateUrl="~/purchase.aspx" />
            </div>
            <div class="clr"></div>
            <!-- end footer -->
        </FooterTemplate>
    </asp:Repeater>
</div>

<!-- end CartWidget.ascx -->