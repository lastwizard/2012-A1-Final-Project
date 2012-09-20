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

public partial class UserControls_Footer : System.Web.UI.UserControl, IFooter
{
    public FooterSection DisabledSection
    {
        get
        {
            FooterSection section = FooterSection.None;
            try
            {
                section = (FooterSection)Enum.Parse(typeof(FooterSection), ViewState["DisabledSection"].ToString());
            }
            catch
            {
                DisabledSection = section;
            }
            return section;
        }
        set
        {
            ViewState["DisabledSection"] = value;
        }
    }

    public void ResetLinks(bool isAuthenticated)
    {
        if (isAuthenticated)
        {
            lnkLogin.NavigateUrl = "~/logout.aspx";
            lnkLogin.Text = "Log Out";
        }
        else
        {
            lnkLogin.NavigateUrl = "~/login.aspx";
            lnkLogin.Text = "Login";
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        lnkAccount.Enabled = !DisabledSection.Equals(FooterSection.Account);
        lnkHome.Enabled = !DisabledSection.Equals(FooterSection.Home);
        lnkLogin.Enabled = !DisabledSection.Equals(FooterSection.Login);
        lnkCart.Enabled = !DisabledSection.Equals(FooterSection.Cart);
        lnkSearch.Enabled = !DisabledSection.Equals(FooterSection.Search);

        if (!IsPostBack)
            ResetLinks(Page.User.Identity.IsAuthenticated);
    }
}
