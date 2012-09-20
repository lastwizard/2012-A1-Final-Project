using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for BaseMaster
/// </summary>
public class BaseMaster : MasterPage
{
    public virtual IHeader Header { get; protected set; }
    public virtual IFooter Footer { get; protected set; }
}
