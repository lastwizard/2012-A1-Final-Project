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

public partial class UserControls_AddressDataEntry : System.Web.UI.UserControl
{
    IRepository<USState> stateDao = SafeServiceLocator<IRepository<USState>>.GetService();

    public bool UseValidationSummary { get; set; }
    public string ValidationGroup { get; set; }
    public Address DataSource { protected get; set; }

    public override void DataBind()
    {
        ddlState.Items.Clear();
        ddlState.DataSource = stateDao.GetAll();
        ddlState.DataValueField = "ID";
        ddlState.DataTextField = "Abbreviation";
        ddlState.DataBind();

        reqLine1.ValidationGroup = ValidationGroup;
        reqCity.ValidationGroup = ValidationGroup;
        reqZip.ValidationGroup = ValidationGroup;
        regZip.ValidationGroup = ValidationGroup;

        reqLine1.Display = UseValidationSummary ? ValidatorDisplay.None : ValidatorDisplay.Dynamic;
        reqCity.Display = reqLine1.Display;
        reqZip.Display = reqLine1.Display;
        regZip.Display = reqLine1.Display;

        if (DataSource != null)
        {
            txtName.Text = DataSource.Name;
            txtLine1.Text = DataSource.Line1;
            txtLine2.Text = DataSource.Line2;
            txtCity.Text = DataSource.City;
            txtZipCode.Text = DataSource.ZipCode;
            ddlState.SelectedValue = DataSource.State.Id.ToString();
        }
    }

    public void ReviseAddress(Address originalAddress)
    {
        Check.Require(originalAddress != null, "Original Address is a required argument.");
        USState state = stateDao.Get(Convert.ToInt32(ddlState.SelectedValue));

        originalAddress.Name = txtName.Text;
        originalAddress.Line1 = txtLine1.Text;
        originalAddress.Line2 = txtLine2.Text;
        originalAddress.City = txtCity.Text;
        originalAddress.ZipCode = txtZipCode.Text;
        originalAddress.State = state;
    }

    public Address GetNewAddress()
    {
        USState state = stateDao.Get(Convert.ToInt32(ddlState.SelectedValue));
        Address address = new Address();
        address.Name = txtName.Text;
        address.Line1 = txtLine1.Text;
        address.Line2 = txtLine2.Text;
        address.City = txtCity.Text;
        address.ZipCode = txtZipCode.Text;
        address.State = state;
        return address;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        txtLine1.MaxLength = Address.LineLimit;
        txtLine2.MaxLength = Address.LineLimit;
        txtCity.MaxLength = Address.CityLimit;
        txtZipCode.MaxLength = Address.ZipCodeLimit;
    }
}
