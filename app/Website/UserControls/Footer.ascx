<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="UserControls_Footer" %>

<!-- begin Footer.ascx -->

<table width="100%">
<tr>
<td align="center">
    <asp:HyperLink ID="lnkHome" runat="server" Text="What's in stock?" NavigateUrl="~/default.aspx" />
    |
    <asp:HyperLink ID="lnkSearch" runat="server" Text="Search" NavigateUrl="~/search.aspx" />
    |
    <asp:HyperLink ID="lnkAccount" runat="server" Text="My Account" NavigateUrl="~/Account/" />
    |
    <asp:HyperLink ID="lnkCart" runat="server" Text="Shopping Cart" NavigateUrl="~/cart.aspx" />
    |
    <asp:HyperLink ID="lnkLogin" runat="server" Text="Login" NavigateUrl="~/login.aspx" />
</td>
</tr>
</table>

<!-- end Footer.ascx -->