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
using FinalProject.Domain;

/// <summary>
/// Summary description for IHeader
/// </summary>
public interface IHeader
{
    string Text { get; set; }
    void BindCustomer(User customer);
}
