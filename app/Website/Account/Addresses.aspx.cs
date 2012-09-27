using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Domain;

public partial class Account_Addresses : AccountPage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        list.ItemDataBound += new DataListItemEventHandler(list_ItemDataBound);
        list.EditCommand += new DataListCommandEventHandler(list_EditCommand);
        list.DeleteCommand += new DataListCommandEventHandler(list_DeleteCommand);
        list.CancelCommand += new DataListCommandEventHandler(list_CancelCommand);
        list.UpdateCommand += new DataListCommandEventHandler(list_UpdateCommand);
        list.ItemCommand += new DataListCommandEventHandler(list_ItemCommand);
    }

    void list_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (!e.CommandName.Equals("Insert")) return;
        if (!Page.IsValid) return;

        UserControls_AddressDataEntry de = (UserControls_AddressDataEntry)e.Item.FindControl("entry");
        Address address = de.GetNewAddress();
        CurrentUser.Addresses.Add(address);
        userRepository.SaveOrUpdate(CurrentUser);
        userRepository.DbContext.CommitChanges();
        BindAddresses();
    }

    void list_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        if (!Page.IsValid) return;

        Address address = CurrentUser.Addresses.Where(x => x.Id == Convert.ToInt32(list.DataKeys[e.Item.ItemIndex])).First();
        UserControls_AddressDataEntry de = (UserControls_AddressDataEntry)e.Item.FindControl("entry");
        de.ReviseAddress(address);
        userRepository.SaveOrUpdate(CurrentUser);
        userRepository.DbContext.CommitChanges();
        list_CancelCommand(source, e);
    }

    void list_CancelCommand(object source, DataListCommandEventArgs e)
    {
        list.EditItemIndex = -1;
        BindAddresses();
    }

    void list_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        Address address = CurrentUser.Addresses.Where(x => x.Id == Convert.ToInt32(list.DataKeys[e.Item.ItemIndex])).First();
        CurrentUser.Addresses.Remove(address);
        userRepository.SaveOrUpdate(CurrentUser);
        userRepository.DbContext.CommitChanges();
        list_CancelCommand(source, e);
    }

    void list_EditCommand(object source, DataListCommandEventArgs e)
    {
        list.EditItemIndex = e.Item.ItemIndex;
        BindAddresses();
    }

    void list_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Address address;

        if (e.Item.ItemType.Equals(ListItemType.EditItem) || e.Item.ItemType.Equals(ListItemType.Footer))
        {
            address = (Address)e.Item.DataItem;
            UserControls_AddressDataEntry de = (UserControls_AddressDataEntry)e.Item.FindControl("entry");
            de.DataSource = address;
            de.DataBind();
            return;
        }
        else if (e.Item.DataItem == null) return;

        address = (Address)e.Item.DataItem;
        UserControls_AddressDisplay disp = (UserControls_AddressDisplay)e.Item.FindControl("display");
        disp.DataSource = address;
        disp.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Header.Text = "Your Addresses";
        Master.Footer.DisabledSection = FooterSection.Account;
        Master.AccountSection = AccountSection.Addresses;

        if (IsPostBack) return;

        BindAddresses();
    }

    void BindAddresses()
    {
        list.DataSource = CurrentUser.Addresses;
        list.DataBind();
    }
}