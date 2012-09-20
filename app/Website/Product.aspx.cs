using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FinalProject.Domain;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core;

public partial class ProductPage : PageWithShoppingCart
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        finalProduct.PurchaseClick += new PurchaseClick(AddToCart);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        Master.Header.Text = "Product Details";

        if (String.IsNullOrEmpty(Request.QueryString["ProductID"]))
            Response.Redirect("default.aspx");

        try
        {
            int productId = Convert.ToInt32(Request.QueryString["ProductID"]);
            IRepository<Product> productDao = SafeServiceLocator<IRepository<Product>>.GetService();
            Product product = productDao.Get(productId);
            finalProduct.DataSource = product;
            finalProduct.DataBind();
        }
        catch
        {
            Response.Redirect("default.aspx");
        }
    }
}
