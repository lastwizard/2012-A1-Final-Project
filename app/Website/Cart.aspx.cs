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
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core;

public partial class Cart : PageWithShoppingCart
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        gridCart.RowDataBound += new GridViewRowEventHandler(SetInternals);
        gridCart.RowDeleting += new GridViewDeleteEventHandler(RemoveItem);
        custQuantity.ServerValidate += new ServerValidateEventHandler(CheckStock);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Footer.DisabledSection = FooterSection.Cart;
        Master.Header.Text = "Your Shopping Cart";

        if (!IsPostBack)
        {
            BindCart();
        }
    }

    protected void BindCart()
    {
        if (ShoppingCart.IsEmpty)
        {
            pnlCart.Visible = false;
            lblMessage.Text = "Your shopping cart is empty.";
        }
        else
        {
            gridCart.DataSource = ShoppingCart.Items;
            gridCart.DataBind();
        }
    }

    protected void UpdateCart(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            IRepository<Product> productDao = SafeServiceLocator<IRepository<Product>>.GetService();
            foreach (GridViewRow row in gridCart.Rows)
            {
                if (row.RowType.Equals(DataControlRowType.DataRow))
                {
                    int productId = Convert.ToInt32(gridCart.DataKeys[row.RowIndex].Value);
                    Product product = productDao.Get(productId);
                    int quantity = Convert.ToInt32(((TextBox)row.FindControl("txtQuantity")).Text);
                    if (quantity <= 0)
                        ShoppingCart.RemoveItem(product);
                    else
                        ShoppingCart.Items.First(x => x.Product == product).Quantity = quantity;
                }
            }
            SaveShoppingCart();
            lblMessage.Text = "Your changes have been saved.";
            BindCart();
        }
    }

    protected void RemoveItem(object sender, GridViewDeleteEventArgs e)
    {
        ShoppingCart.RemoveItemById(Convert.ToInt32(gridCart.DataKeys[e.RowIndex].Value));
        SaveShoppingCart();
        BindCart();
    }

    protected void SetInternals(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType.Equals(DataControlRowType.DataRow))
        {
            ShoppingCartItem item = (ShoppingCartItem)e.Row.DataItem;
            ((TextBox)e.Row.FindControl("txtQuantity")).Text = item.Quantity.ToString();
            ((Literal)e.Row.FindControl("litSubtotal")).Text = "$" + (item.Product.Price * item.Quantity).ToString("N2");

            RequiredFieldValidator val = (RequiredFieldValidator)e.Row.FindControl("reqQuantity");
            val.ErrorMessage = String.Format(val.ErrorMessage, item.Product.Name);

            CompareValidator cval = (CompareValidator)e.Row.FindControl("compQuantity");
            cval.ErrorMessage = String.Format(cval.ErrorMessage, item.Product.Name);
        }
        else if (e.Row.RowType.Equals(DataControlRowType.Footer))
        {
            ((Literal)e.Row.FindControl("litTotal")).Text = "$" + ShoppingCart.TotalCost.ToString("N2");
        }
    }

    protected void CheckStock(object sender, ServerValidateEventArgs e)
    {
        e.IsValid = true;
        try
        {
            IRepository<Product> productDao = SafeServiceLocator<IRepository<Product>>.GetService();
            foreach (GridViewRow row in gridCart.Rows)
            {
                if (row.RowType.Equals(DataControlRowType.DataRow))
                {
                    int productId = Convert.ToInt32(gridCart.DataKeys[row.RowIndex].Value);
                    Product product = productDao.Get(productId);
                    int quantity = Convert.ToInt32(((TextBox)row.FindControl("txtQuantity")).Text);
                    if (product.CurrentQuantity < quantity)
                    {
                        e.IsValid = false;
                        custQuantity.ErrorMessage = "We only have " + product.CurrentQuantity.ToString() + " of the " + product.Name + " in stock!";
                        break;
                    }
                }
            }
        }
        catch { }
    }
}
