<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" MasterPageFile="~/MasterPages/SiteMasterSingleColumn.master" %>
<%@ MasterType VirtualPath="~/MasterPages/SiteMasterSingleColumn.master" %>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="plcMain">

<asp:Label ID="lblMessage" runat="server" EnableViewState="false" />

    <asp:panel ID="pnlCart" runat="server" style="padding-left:200px; width:600px;">
        <asp:ValidationSummary ID="valSummary" runat="server" ForeColor="Red" DisplayMode="BulletList" ValidationGroup="cart" />

        <asp:GridView ID="gridCart" runat="server" AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true" Width="600px" CellPadding="3"
            BorderColor="Beige" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="ID">
            <Columns>
                <asp:BoundField HeaderText="Product" DataField="Name" />
                <asp:BoundField HeaderText="Price" DataField="Price" DataFormatString="${0}" ItemStyle-HorizontalAlign="Right" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" MaxLength="2" Width="30px" />
                        <asp:RequiredFieldValidator ID="reqQuantity" runat="server" ControlToValidate="txtQuantity"
                            ErrorMessage="You must enter a quantity for {0}." ValidationGroup="cart" Display="None" />
                        <asp:CompareValidator ID="compQuantity" runat="server" ValueToCompare="0" Operator="GreaterThanEqual" Type="Integer" Display="None"
                            ErrorMessage="You must enter a whole number greater than or equal to zero for {0}." ValidationGroup="cart" ControlToValidate="txtQuantity" />
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                    <FooterTemplate>
                        Total:
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subtotal">
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Literal ID="litSubtotal" runat="server" />
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                    <FooterTemplate>
                        <asp:Literal ID="litTotal" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Image" CommandName="Delete" CausesValidation="false" ImageUrl="~/images/x.gif" ItemStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>

        <asp:CustomValidator ID="custQuantity" runat="server" ValidationGroup="cart" />

        <div class="rightHalf" style="margin-top: 10px;">
            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="cart" Text="Update Cart" OnClick="UpdateCart" /> 
            &nbsp;&nbsp;
            <asp:hyperlink ID="lnkCheckout" runat="server" Text="Check Out" NavigateUrl="~/Purchase.aspx" />
        </div>
    </asp:panel>
    
</asp:Content>