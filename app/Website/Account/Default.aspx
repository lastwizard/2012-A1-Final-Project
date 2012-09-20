<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" MasterPageFile="~/MasterPages/Account.master" %>
<%@ MasterType VirtualPath="~/MasterPages/Account.master" %>

<asp:Content ID="conMain" runat="server" ContentPlaceHolderID="plcMain">

<asp:Label ID="lblResult" runat="Server" />

<asp:ValidationSummary ID="valSummary" runat="server" ForeColor="red" DisplayMode="bulletList" />

<table width="500" cellpadding="2" cellspacing="2">
<tr>
    <td class="label">First Name:</td>
    <td><asp:TextBox ID="txtFirstName" runat="server" TabIndex="1" /></td>
    <td style="width:30px;"></td>
    <td class="label">User Name:</td>
    <td><asp:TextBox ID="txtUserName" runat="server" TabIndex="4" /></td>
</tr>
<tr>
    <td class="label">Last Name:</td>
    <td><asp:TextBox ID="txtLastName" runat="Server" TabIndex="2" /></td>
    <td></td>
    <td class="label"><asp:label ID="lblPasswordText" runat="server" Text="Password:" /></td>
    <td><asp:TextBox ID="txtPassword" runat="Server" TextMode="Password" TabIndex="5" /></td>
</tr>
<tr>
    <td class="label">Email:</td>
    <td><asp:TextBox ID="txtEmail" runat="Server" TabIndex="3" /></td>
    <td></td>
<asp:PlaceHolder ID="plcNewPassword" runat="server">
    <td class="label">New Password:</td>
    <td>
        <asp:TextBox ID="txtPasswordNew" runat="Server" TextMode="Password" TabIndex="6" />
    </td>
</asp:PlaceHolder>
</tr>
<tr>
    <td colspan="5" align="right">
        <asp:Button ID="btnUpdate" runat="Server" Text="Go!" />
    </td>
</tr>
</table>

<asp:RequiredFieldValidator ID="reqFirstName" runat="Server" ControlToValidate="txtFirstName" ErrorMessage="First Name is a required value." EnableClientScript="true" Display="none" />
<asp:RequiredFieldValidator ID="reqLastName" runat="Server" ControlToValidate="txtLastName" ErrorMessage="Last Name is a required value." EnableClientScript="true" Display="none" />
<asp:RequiredFieldValidator ID="reqEmail" runat="Server" ControlToValidate="txtEmail" ErrorMessage="Email is a required value." EnableClientScript="true" Display="none" />
<asp:RequiredFieldValidator ID="reqUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="User Name is a required value." EnableClientScript="true" Display="none" />
<asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is a required value." EnableClientScript="true" Display="none" />

<asp:CustomValidator ID="custEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email must be in a valid format." Display="none" />
<asp:CustomValidator ID="custPassword" runat="server" ControlToValidate="txtPasswordNew" Display="None" />
<asp:CustomValidator ID="custUserName" runat="server" ControlToValidate="txtUserName" Display="None" />
</asp:Content>