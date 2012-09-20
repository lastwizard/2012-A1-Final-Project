<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPages/SiteMasterDoubleColumn.master" %>
<%@ MasterType VirtualPath="~/MasterPages/SiteMasterDoubleColumn.master" %>

<asp:Content ID="conMain" runat="server" ContentPlaceHolderID="plcMain">

    <final:ProductList id="list" runat="server" />

</asp:Content>
