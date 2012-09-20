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
using FinalProject.Data.Repositories;
using FinalProject.Data.Interfaces;
using SharpArch.Core;

public partial class Login : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Master.Footer.DisabledSection = FooterSection.Login;
        Master.Header.Text = "Please log in.";
    }
}
