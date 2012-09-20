using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Domain;
using System.Text;
using FinalProject.Data.Repositories;
using SharpArch.Core;
using FinalProject.Data.Interfaces;

public partial class Account_Orders : AccountPage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        grid.RowDataBound += new GridViewRowEventHandler(grid_RowDataBound);
    }

    void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal literal = (Literal)e.Row.FindControl("litProducts");
            StringBuilder builder = new StringBuilder();
            StoreOrder order = (StoreOrder)e.Row.DataItem;
            if (literal != null && order != null)
            {
                foreach (StoreOrderItem item in order.Items)
                {
                    builder.Append(item.Product.Name);
                    builder.Append(", ");
                }
                if (builder.Length > 0)
                    builder.Remove(builder.Length - 2, 2);
                literal.Text = builder.ToString();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Header.Text = "Your Orders";
        Master.AccountSection = AccountSection.Orders;
        Master.Footer.DisabledSection = FooterSection.Account;

        IList<StoreOrder> orderList = SafeServiceLocator<IStoreOrderRepository>.GetService().GetByCustomer(CurrentUser);

        grid.DataSource = orderList.OrderByDescending(x => x.OrderDate);
        grid.DataBind();
    }
}