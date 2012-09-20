<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddressDataEntry.ascx.cs" Inherits="UserControls_AddressDataEntry" %>

<!-- begin AddressDataEntry.ascx -->

<table cellpadding="2" cellspacing="2">
<tr>
    <td class="label">Name:</td>
    <td colspan="3"><asp:TextBox ID="txtName" runat="server" Width="250" /></td>
</tr>
<tr>
    <td rowspan="2" valign="top" class="label">Address:</td>
    <td colspan="3"><asp:TextBox ID="txtLine1" runat="server" Width="250" /></td>
</tr>
<tr>
    <td colspan="3" class="label"><asp:TextBox ID="txtLine2" runat="server" Width="250" /></td>
</tr>
<tr>
    <td rowspan="2" class="label">City/State/Zip:</td>
    <td><asp:TextBox ID="txtCity" runat="server" Width="100" /></td>
    <td><asp:DropDownList ID="ddlState" runat="server" /></td>
    <td><asp:TextBox ID="txtZipCode" runat="Server" Width="70" /></td>
</tr>
</table>

<asp:RequiredFieldValidator ID="reqLine1" runat="server" ControlToValidate="txtLine1" Display="none" EnableClientScript="true" ErrorMessage="Address (Line 1) is a required field." />
<asp:RequiredFieldValidator ID="reqCity" runat="server" ControlToValidate="txtCity" Display="none" EnableClientScript="true" ErrorMessage="City is a required field." />
<asp:RequiredFieldValidator ID="reqZip" runat="server" ControlToValidate="txtZipCode" Display="none" EnableClientScript="true" ErrorMessage="Zip Code is a required field." />
<asp:RegularExpressionValidator ID="regZip" runat="Server" ControlToValidate="txtZipCode" Display="none" EnableClientScript="true" ValidationExpression="^\d{5}(-\d{4})?$" ErrorMessage="Zip Code must be the correct length and format." />

<!-- end AddressDataEntry.ascx -->