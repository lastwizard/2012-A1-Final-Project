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
using System.Collections.Generic;
using FinalProject.Data.Search;
using FinalProject.Data.Repositories;
using FinalProject.Data.Interfaces;
using SharpArch.Core;

public partial class search : PageWithShoppingCart
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        list.DataSourceNeeded += new ProductDataSourceNeeded(GetDataSource);
        list.PurchaseClick += new PurchaseClick(AddToCart);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "eComShop.com - Search Results";
        this.Master.Footer.DisabledSection = FooterSection.Search;

        if (!IsPostBack)
        {
            list.DataBind();
        }
    }

    protected IList<Product> GetDataSource()
    {
        ProductSearchParameters pars = new ProductSearchParameters();
        pars.AddCriteria(Request.QueryString["keywords"]);
        try
        {
            pars.SortType = (ProductSortType)Enum.Parse(typeof(ProductSortType), Request.QueryString["order"]);
        }
        catch
        { }

        if (String.IsNullOrEmpty(Request.QueryString["dir"]) || Request.QueryString["dir"] == "asc")
            pars.SortDirection = FinalProject.Data.Search.SortDirection.Ascending;
        else
            pars.SortDirection = FinalProject.Data.Search.SortDirection.Descending;

        IList<Product> productList = SafeServiceLocator<IProductRepository>.GetService().GetSearchResults(pars);

        if (!IsPostBack)
        {
            this.Master.Header.Text = productList.Count.ToString("N0") + " results found";
            if (!String.IsNullOrEmpty(Request.QueryString["keywords"]))
                this.Master.Header.Text += " for \"" + Request.QueryString["keywords"] + "\"";
        }
        return productList;
    }
}
