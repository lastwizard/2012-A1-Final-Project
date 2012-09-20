<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Account_Orders" MasterPageFile="~/MasterPages/Account.master" %>
<%@ MasterType VirtualPath="~/MasterPages/Account.master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="plcMain">

    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" GridLines="None" CellPadding="5" Width="700px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="OrderDate" HeaderText="Date" DataFormatString="{0:d}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Products">
                <ItemTemplate>
                    <asp:Literal ID="litProducts" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField Text="View Receipt" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Account/Receipt.aspx?id={0}" ItemStyle-Wrap="false" />
        </Columns>
    </asp:GridView>

</asp:Content>