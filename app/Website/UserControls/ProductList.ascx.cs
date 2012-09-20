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
using SharpArch.Core;

public partial class UserControls_ProductList : System.Web.UI.UserControl
{
    public event ProductDataSourceNeeded DataSourceNeeded;
    public event PurchaseClick PurchaseClick;

    private const int pageSize = 10;
    private bool isPrevVisible = true;
    private bool isNextVisible = true;

    public int ColumnCount { get; set; }
    public IList<Product> DataSource { get; set; }

    int CurrentPage
    {
        get
        {
            int _current = 0;
            try
            {
                _current = Convert.ToInt32(ViewState["CurrentPage"]);
            }
            catch
            { }
            return _current;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }

    public UserControls_ProductList()
    {
        ColumnCount = 2;
    }

    public override void DataBind()
    {
        base.DataBind();
        CurrentPage = 0;
        BindList();
    }

    protected void BindList()
    {
        if (DataSource == null)
        {
            Check.Require(DataSourceNeeded != null, "DataSource must be set in order to bind datalist.");
            DataSource = DataSourceNeeded();
        }

        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = DataSource;
        pds.AllowPaging = true;
        pds.PageSize = pageSize;
        pds.CurrentPageIndex = CurrentPage;

        isNextVisible = !pds.IsLastPage;
        isPrevVisible = !pds.IsFirstPage;
        dlProducts.RepeatColumns = ColumnCount;
        dlProducts.DataSource = pds;
        dlProducts.DataBind();
    }

    protected void BindDisplay(object src, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            UserControls_ProductDisplay display = (UserControls_ProductDisplay)e.Item.FindControl("finalProduct");
            display.DataSource = (Product)e.Item.DataItem;
            display.DataBind();
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            LinkButton link = (LinkButton)e.Item.FindControl("lnkPrevious");
            link.Visible = (DataSource.Count > pageSize); 
            link.Enabled = isPrevVisible;

            link = (LinkButton)e.Item.FindControl("lnkNext");
            link.Visible = (DataSource.Count > pageSize);
            link.Enabled = isNextVisible;
        }
    }

    protected void ChangePage(object src, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("Previous"))
        {
            CurrentPage -= 1;
        }
        else if (e.CommandName.Equals("Next"))
        {
            CurrentPage += 1;
        }
        BindList();
    }

    protected void AddToCart(int productId)
    {
        if (PurchaseClick != null)
            PurchaseClick(productId);
    }
}
