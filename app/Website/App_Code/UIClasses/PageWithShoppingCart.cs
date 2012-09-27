using System;
using System.Data;
using System.Configuration;
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
/// <summary>
/// Summary description for PageWithCart
/// </summary>
public class PageWithShoppingCart : System.Web.UI.Page
{
    private string cartCookieName = "ShoppingCartID";
    private ShoppingCart cart = null;
    private IRepository<ShoppingCart> cartRep = SafeServiceLocator<IRepository<ShoppingCart>>.GetService();
    private IRepository<Product> productRep = SafeServiceLocator<IRepository<Product>>.GetService();

    public ShoppingCart ShoppingCart
    {
        get
        {
            if (cart == null)
            {
                if (Request.Cookies[cartCookieName] != null)
                {
                    cart = cartRep.Get(Convert.ToInt32(Request.Cookies[cartCookieName].Value));
                }

                if (cart == null)
                {
                    cart = new ShoppingCart();
                    cartRep.SaveOrUpdate(cart);
                    cartRep.DbContext.CommitChanges();
                    HttpCookie cookie = new HttpCookie(cartCookieName, cart.Id.ToString());
                    cookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cookie);
                }
            }
            return cart;
        }
    }

    protected void EmptyShoppingCart()
    {
        ShoppingCart.Items.Clear();
        SaveShoppingCart();
    }

    protected void SaveShoppingCart()
    {
        ShoppingCart.LastUpdated = DateTime.Now;
        cartRep.SaveOrUpdate(ShoppingCart);
        cartRep.DbContext.CommitChanges();
    }

    protected void AddToCart(int productId)
    {
        Product product = productRep.Get(productId);
        ShoppingCart.AddItem(product, 1);
        SaveShoppingCart();
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (Master is MasterWithCartControl)
        {
            MasterWithCartControl mcc = (MasterWithCartControl)Master;
            if (mcc.Cart == null) return;
            mcc.Cart.DataSource = ShoppingCart;
            mcc.Cart.DataBind();
        }
    }
}
