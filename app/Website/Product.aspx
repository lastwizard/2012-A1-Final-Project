<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="ProductPage" MasterPageFile="~/MasterPages/SiteMasterDoubleColumn.master" %>
<%@ MasterType VirtualPath="~/MasterPages/SiteMasterDoubleColumn.master" %>
<%@ Register TagPrefix="final" TagName="ProductDisplay" Src="~/UserControls/ProductDisplay.ascx" %>

<asp:Content ID="conMain" runat="server" ContentPlaceHolderID="plcMain">

    <final:ProductDisplay ID="finalProduct" runat="server" IsDescriptionVisible="true" IsMoreVisible="false" />

</asp:Content>
