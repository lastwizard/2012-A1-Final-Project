<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addresses.aspx.cs" Inherits="Account_Addresses" MasterPageFile="~/MasterPages/Account.master" %>
<%@ MasterType VirtualPath="~/MasterPages/Account.master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="plcHead">

    <style type="text/css">
        .addresses
        {
        	width: 545px;
        }
        
        .addresses .leftHalf
        {
        	width: 380px;
        }
        
        .addresses .rightHalf
        {
        	width: 155px;
        	text-align: left;
        }
        
        .addresses .display
        {
        	padding: 5px;
        	width: 370px;
        }
        
        .separator
        {
        	border-top: solid 2px #DEB887;
    </style>

</asp:Content>

<asp:Content ID="main" runat="server" ContentPlaceHolderID="plcMain">

    <div class="addresses">
        <asp:DataList ID="list" runat="server" DataKeyField="ID">
            <SeparatorTemplate>
                <div class="clear separator"></div>
            </SeparatorTemplate>
            <ItemTemplate>
                <div class="leftHalf display">
                    <final:AddressDisplay ID="display" runat="server" IncludeName="true" />
                </div>
                <div class="rightHalf">
                    <asp:Button ID="edit" runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" />
                    &nbsp;&nbsp;
                    <asp:Button ID="delete" runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" />
                </div>
            </ItemTemplate>
            <EditItemTemplate>
                <div class="leftHalf">
                    <final:Address ID="entry" runat="server" ValidationGroup="update" UseValidationSummary="true" />
                    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="update" ForeColor="Red" DisplayMode="BulletList" />
                </div>
                <div class="rightHalf">
                    <asp:Button ID="update" runat="server" Text="Update" CommandName="Update" ValidationGroup="update" />
                    &nbsp;&nbsp;
                    <asp:Button ID="cancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
                </div>
            </EditItemTemplate>
            <FooterTemplate>
                <div class="clear separator"></div>
                <div class="leftHalf">
                    <final:Address ID="entry" runat="server" ValidationGroup="insert" UseValidationSummary="true" />
                    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="insert" ForeColor="Red" DisplayMode="BulletList" />
                </div>
                <div class="rightHalf">
                    <asp:Button ID="insert" runat="server" Text="Add" CommandName="Insert" ValidationGroup="insert" />
                </div>
            </FooterTemplate>
        </asp:DataList>
    </div>

</asp:Content>