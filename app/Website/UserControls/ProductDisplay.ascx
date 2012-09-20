<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDisplay.ascx.cs" Inherits="UserControls_ProductDisplay" %>

<!-- begin ProductDisplay.ascx -->

<table cellpadding="2" cellspacing="2">
<tr>
    <td valign="Top">
        <asp:Image ID="imgProduct" runat="server" AlternateText="" />
    </td>
    <td valign="top">
        <b>Name:</b> <asp:Label ID="lblName" runat="server" /><br />
        <b>Price:</b> <asp:Label ID="lblPrice" runat="Server" /><br />
        <b>Availability:</b> <asp:Label ID="lblAvailability" runat="Server" />
        &nbsp;&nbsp;        
        <asp:HyperLink ID="lnkMore" runat="server" Text="More..." />
        
        <asp:PlaceHolder ID="plcDescription" runat="server" Visible="false">
            <p>
            <b>Description:</b><br />
            <asp:Label ID="lblDescription" runat="server" />
            </p>
        </asp:PlaceHolder>

        <br /><br />
        <asp:LinkButton id="lnkPurchase" runat="server" Text="Add to Cart" OnClick="PurchaseClicked" />
    </td>
</tr>
</table>

<!-- end ProductDisplay.ascx -->