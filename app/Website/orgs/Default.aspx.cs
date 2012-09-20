using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orgs_Default : FinalProject.Web.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblOrgName.Text = "Test Organization";
        litContactName.Text = "Test Person";
    }
}