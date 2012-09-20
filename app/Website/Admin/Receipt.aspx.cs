using System;
using FinalProject.Domain;
using SharpArch.Core;
using SharpArch.Core.PersistenceSupport;

public partial class Admin_Receipt : AccountPage
{
  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);

    if (IsPostBack) return;

    if (string.IsNullOrEmpty(Request.QueryString["id"]))
    {
      Response.Redirect("Orders.aspx");
    }

    try
    {
      var id = Request.QueryString["id"];
      var orderId = Convert.ToInt32(id);
      var orderDao = SafeServiceLocator<IRepository<StoreOrder>>.GetService();
      var order = orderDao.Get(orderId);

      lblMessage.Visible = false;
      receipt.Visible = true;
      Master.Header.Text = "Receipt for Order " + id;

      receipt.DataSource = order;
      receipt.DataBind();
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