using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_Share : FinalProject.Web.UserControl
{
    public string Title
    {
        get { return litPageTitle.Text; }
        set { litPageTitle.Text = value; }
    }
}