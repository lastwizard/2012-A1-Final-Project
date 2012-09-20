using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FinalProject.Domain;

public partial class UserControls_CartWidget : System.Web.UI.UserControl, ICart
{
    public bool ShowCheckoutLink { get; set; }
    public ShoppingCart DataSource { get; set; }

    public UserControls_CartWidget()
    {
        ShowCheckoutLink = true;
    }

    public override void DataBind()
    {
        base.DataBind();
        rpCartItems.Visible = false;
        if (DataSource != null)
        {
            if (DataSource.Items.Count > 0)
            {
                rpCartItems.Visible = true;
                rpCartItems.DataSource = DataSource.Items;
                rpCartItems.DataBind();
            }
        }
        lblEmpty.Visible = !rpCartItems.Visible;
    }

    protected void SetInternals(object src, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType.Equals(ListItemType.Footer))
        {
            ((HyperLink)e.Item.FindControl("lnkCheckout")).Visible = ShowCheckoutLink;
            ((Literal)e.Item.FindControl("litTotal")).Text = "$" + DataSource.TotalCost.ToString("N2");
        }
        else if (e.Item.ItemType.Equals(ListItemType.Item) || e.Item.ItemType.Equals(ListItemType.AlternatingItem))
        {
            ShoppingCartItem item = (ShoppingCartItem)e.Item.DataItem;
            ((Literal)e.Item.FindControl("litName")).Text = item.Product.Name;
            ((Literal)e.Item.FindControl("litCount")).Text = item.Quantity.ToString("N0");
        }
    }
}
