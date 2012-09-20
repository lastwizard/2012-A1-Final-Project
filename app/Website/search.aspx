<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" MasterPageFile="~/MasterPages/SiteMasterDoubleColumn.master" %>
<%@ MasterType VirtualPath="~/MasterPages/SiteMasterDoubleColumn.master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="plcMain">

    <final:ProductList ID="list" runat="server" ColumnCount="1" />

</asp:Content>