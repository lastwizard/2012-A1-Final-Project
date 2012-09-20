using System;
using FinalProject.Domain;
using SharpArch.Core;
using SharpArch.Core.PersistenceSupport;

public partial class Account_Receipt : AccountPage
{
  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);

    if (IsPostBack) return;

    if (string.IsNullOrEmpty(Request.QueryString["id"]))
    {
      Response.Redirect("default.aspx");
    }

    try
    {
      var id = Request.QueryString["id"];
      var orderId = Convert.ToInt32(id);
      var orderDao = SafeServiceLocator<IRepository<StoreOrder>>.GetService();
      var order = orderDao.Get(orderId);

      if (order.Customer.Id.Equals(CurrentUser.Id))
      {
        lblMessage.Visible = false;
        receipt.Visible = true;
        Master.Header.Text = "Thank you for your purchase!";

        receipt.DataSource = order;
        receipt.DataBind();
      }
      else
      {
        receipt.Visible = false;
        lblMessage.Visible = true;
        lblMessage.Text = "You are not authorized to view this receipt.";
        Master.Header.Text = "Access Forbidden";
      }
    }
    catch
    {
      receipt.Visible = false;
      lblMessage.Visible = true;
      lblMessage.Text = "An error occurred while attempting to retrieve this receipt.";
      Master.Header.Text = "Error!";
    }
  }
}