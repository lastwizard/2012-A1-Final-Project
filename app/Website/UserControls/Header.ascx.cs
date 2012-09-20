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
using FinalProject.Data.Interfaces;

public partial class UserControls_Header : System.Web.UI.UserControl, IHeader
{
    private bool _isBound = false;

    public string Text
    {
        get { return lblHeader.Text; }
        set { lblHeader.Text = value; }
    }

    protected void Page_PreRender(object src, EventArgs e)
    {
        if (!_isBound)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                var rep = SafeServiceLocator<IUserRepository>.GetService();
                User user = rep.GetByUserName(Page.User.Identity.Name);
                BindCustomer(user);
            }
            else
            {
                BindCustomer(null);
            }
        }
    }

    public void BindCustomer(User user)
    {
        if (user != null)
        {
            lblHello.Text = "Hello, " + user.FirstName + "!";
            plcLinks.Visible = false;
        }
        else
        {
            lblHello.Text = "Hello, Guest!";
            plcLinks.Visible = true;
        }
        _isBound = true;
    }
}
