<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPages/SiteMasterSingleColumn.master" %>
<%@ MasterType VirtualPath="~/MasterPages/SiteMasterSingleColumn.master" %>

<asp:Content ID="conMain" ContentPlaceHolderID="plcMain" runat="Server">

    <asp:Login ID="login" runat="server" TitleText="" />

    <asp:HyperLink ID="lnkForgot" runat="server" Text="Forgot your password?" NavigateUrl="~/ForgotPassword.aspx" />

</asp:Content>