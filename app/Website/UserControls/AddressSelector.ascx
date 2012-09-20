<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddressSelector.ascx.cs" Inherits="UserControls_AddressSelector" %>
<%@ Register TagPrefix="add" TagName="display" Src="~/UserControls/AddressDisplay.ascx" %>

<!-- begin AddressSelector.ascx -->

<div style="float: left; margin-right: 5px;">
    <asp:DropDownList ID="ddlAddress" runat="server" AutoPostBack="true" CausesValidation="false" /><br />
    <add:display ID="display" runat="server" IncludeName="false" />
</div>
<div style="float: left;">
    <asp:HyperLink ID="lnkNew" runat="server" Text="New" NavigateUrl="~/Account/Addresses.aspx" />
</div>
<div class="clear"></div>

<!-- end AddressSelector.ascx -->