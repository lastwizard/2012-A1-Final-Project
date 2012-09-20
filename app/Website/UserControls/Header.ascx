<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControls_Header" %>

<!-- begin Header.ascx -->
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td>
        <asp:image ID="imgTitle" runat="server" ImageUrl="~/images/title.gif" AlternateText="title image" />
    </td>
    <td align="right" valign="bottom" style="font-size: 10pt;">
        <asp:Label ID="lblHello" runat="server" ForeColor="CadetBlue" />
        <asp:PlaceHolder ID="plcLinks" runat="server">
            <asp:HyperLink ID="lnkRegister" runat="Server" NavigateUrl="~/Account/Default.aspx" Text="Register" />
            or
        </asp:PlaceHolder>
        <asp:LoginStatus ID="loginStatus" runat="server" LogoutPageUrl="~/logout.aspx" />
    </td>
</tr>
<tr>
    <td colspan="2" style="height: 5px;"></td>
</tr>
<tr>
    <td colspan="2" style="height: 5px; background-color: BurlyWood;"></td>
</tr>
</table>

<p></p>

<asp:Label ID="lblHeader" runat="server" Font-Size="16pt" ForeColor="CadetBlue" />

<p></p>

<!-- end Header.ascx -->