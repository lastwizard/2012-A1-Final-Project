<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receipt.aspx.cs" Inherits="Admin_Receipt" MasterPageFile="~/MasterPages/SiteMasterSingleColumn.master" %>
<%@ MasterType VirtualPath="~/MasterPages/SiteMasterSingleColumn.master" %>

<asp:Content ID="conMain" runat="Server" ContentPlaceHolderID="plcMain">
  <asp:Label ID="lblMessage" runat="Server" />
  <final:Receipt ID="receipt" runat="server" />
</asp:Content>
