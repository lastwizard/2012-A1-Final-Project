<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Default.aspx.cs" Inherits="Admin_Default" MasterPageFile="../MasterPages/SiteMasterSingleColumn.master" %>

<asp:Content runat="server" ContentPlaceHolderID="plcMain">
  <h3>Administration Tasks</h3>
  <asp:HyperLink runat="server" NavigateUrl="Products.aspx">Manage Products</asp:HyperLink>
  <br/>
  <asp:HyperLink runat="server" NavigateUrl="Orders.aspx">View Order History</asp:HyperLink>
</asp:Content>