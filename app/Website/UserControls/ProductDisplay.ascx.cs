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
using System.Drawing;

public partial class UserControls_ProductDisplay : System.Web.UI.UserControl
{
    private string vsIdName = "ProductID";

    public event PurchaseClick PurchaseClick;

    public Product DataSource { get; set; }
    public bool IsDescriptionVisible { get; set; }
    public bool IsPurchaseVisible { get; set; }
    public bool IsMoreVisible { get; set; }

    public UserControls_ProductDisplay()
    {
        IsDescriptionVisible = true;
        IsPurchaseVisible = true;
        IsMoreVisible = true;
    }

    public override void DataBind()
    {
        if (DataSource != null)
        {
            ViewState[vsIdName] = DataSource.Id;
            lblName.Text = DataSource.Name;
            lblPrice.Text = "$" + DataSource.Price.ToString("N2");
            imgProduct.ImageUrl = "~/images/" + DataSource.ImageUrl;
            if (DataSource.IsSoldOut)
            {
                lblAvailability.Text = "SOLD OUT";
                lblAvailability.ForeColor = Color.Red;
                lnkPurchase.Visible = false;
            }
            else
            {
                lblAvailability.Text = DataSource.CurrentQuantity.ToString("N0") + " IN STOCK!";
                lblAvailability.ForeColor = Color.Green;
                lnkPurchase.Visible = IsPurchaseVisible;
            }

            plcDescription.Visible = IsDescriptionVisible;
            lnkMore.Visible = IsMoreVisible;

            if (IsDescriptionVisible)
            {
                lblDescription.Text = DataSource.Description;
            }

            if (IsMoreVisible)
            {
                lnkMore.NavigateUrl = "~/Product.aspx?productid=" + DataSource.Id.ToString();
            }
        }
    }

    protected void PurchaseClicked(object src, EventArgs e)
    {
        if (PurchaseClick != null)
            PurchaseClick(Convert.ToInt32(ViewState[vsIdName]));
    }
}
