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

public partial class UserControls_AddressDisplay : System.Web.UI.UserControl
{
    public Address DataSource { get; set; }
    public bool IncludeName { get; set; }

    public override void DataBind()
    {
        if (DataSource == null)
        {
            litAddress.Text = String.Empty;
        }
        else
        {
            litAddress.Text = DataSource.ToString(IncludeName, "<br />");
        }
    }
}
