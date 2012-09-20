<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductList.ascx.cs" Inherits="UserControls_ProductList" %>
<%@ Register TagPrefix="final" TagName="ProductDisplay" Src="~/UserControls/ProductDisplay.ascx" %>

<!-- begin ProductList.ascx -->

<asp:DataList ID="dlProducts" runat="server" OnItemDataBound="BindDisplay" Width="100%"
    CellPadding="4" CellSpacing="4" OnItemCommand="ChangePage" 
    RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Table">
    <ItemStyle BorderColor="CadetBlue" BorderWidth="2" Width="50%" />
    <AlternatingItemStyle BorderColor="BurlyWood" BorderWidth="2" />
    <ItemTemplate>
        <final:ProductDisplay ID="finalProduct" runat="server" IsDescriptionVisible="false" onPurchaseClick="AddToCart" />
    </ItemTemplate>
    <FooterStyle HorizontalAlign="right" />
    <FooterTemplate>
        <asp:LinkButton ID="lnkPrevious" runat="server" Text="Previous" CommandName="Previous" />
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkNext" runat="server" Text="Next" CommandName="Next" />
    </FooterTemplate>
</asp:DataList>

<!-- end ProductList.ascx -->