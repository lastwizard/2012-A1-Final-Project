using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using FinalProject.Domain;
using FinalProject.Data.Repositories;
using FinalProject.Data.Interfaces;
using SharpArch.Core;

public partial class _Default : PageWithShoppingCart 
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        list.DataSourceNeeded += new ProductDataSourceNeeded(SupplyDataSource);
        list.PurchaseClick += new PurchaseClick(AddToCart);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Header.Text = "Here's What's in Stock @ the eComShop!";
        Master.Footer.DisabledSection = FooterSection.Home;

        if (!IsPostBack)
        {
            list.DataBind();
        }
    }

    protected IList<Product> SupplyDataSource()
    {
        return SafeServiceLocator<IProductRepository>.GetService().GetAvailableProducts();
    }
}
