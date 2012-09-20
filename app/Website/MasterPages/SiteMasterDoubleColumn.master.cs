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

public partial class UserControls_SiteMasterDoubleColumn : MasterWithCartControl
{
    protected void Page_Init(object src, EventArgs e)
    {
        this.Header = Master.Header;
        this.Cart = cart;
    }

    public override IHeader Header
    {
        get
        {
            return Master.Header;
        }
    }

    public override IFooter Footer
    {
        get
        {
            return Master.Footer;
        }
    }

    public bool IsSearchVisible
    {
        get { return search.Visible; }
        set { search.Visible = value; }
    }
}
