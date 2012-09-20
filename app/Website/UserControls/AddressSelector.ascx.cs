using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Domain;
using SharpArch.Core;
using SharpArch.Core.PersistenceSupport;

public partial class UserControls_AddressSelector : System.Web.UI.UserControl
{
    private User _dataSource = null;
    public User DataSource {
        get
        {
            if (_dataSource == null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(ViewState["customerid"]);
                }
                catch { }
                if (id != 0)
                {
                    _dataSource = SafeServiceLocator<IRepository<User>>.GetService().Get(id);
                }
            }
            return _dataSource;
        }
        set
        {
            Check.Require(value != null, "DataSource cannot be null.");
            ViewState["customerid"] = value.Id;
            _dataSource = value;
        }
    }

    public Address GetSelectedAddress()
    {
        Address address = null;

        if (DataSource != null)
        {
            address = GetCurrent();
        }
        return address;
    }

    public override void DataBind()
    {
        base.DataBind();
        Check.Require(DataSource != null, "DataSource is required.");
        Check.Require(!DataSource.IsTransient(), "DataSource cannot be new instance.");

        ddlAddress.DataSource = DataSource.Addresses;
        ddlAddress.DataTextField = "Name";
        ddlAddress.DataValueField = "Id";
        ddlAddress.DataBind();
        ddlAddress_SelectedIndexChanged(this, EventArgs.Empty);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ddlAddress.SelectedIndexChanged += new EventHandler(ddlAddress_SelectedIndexChanged);
    }

    void ddlAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        display.DataSource = GetCurrent();
        display.DataBind();
    }

    Address GetCurrent()
    {
        Address address = null;
        if (DataSource != null)
        {
            IEnumerable<Address> addresses = DataSource.Addresses.Where(x => x.Id.ToString().Equals(ddlAddress.SelectedValue));
            if (addresses.Count() > 0)
                address = addresses.First();
        }
        return address;
    }
}