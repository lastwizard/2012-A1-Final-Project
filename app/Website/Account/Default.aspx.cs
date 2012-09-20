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

public partial class Account_Default : AccountPage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnUpdate.Click += new EventHandler(UpdateCustomer);
        custEmail.ServerValidate += new ServerValidateEventHandler(ValidateEmail);
        custPassword.ServerValidate += new ServerValidateEventHandler(ValidatePassword);
        custUserName.ServerValidate += new ServerValidateEventHandler(ValidateUserName);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        Master.Header.Text = "Register Yourself!";
        Master.Footer.DisabledSection = FooterSection.Account;
        btnUpdate.Text = "Create Your Account!";

        txtFirstName.MaxLength = FinalProject.Domain.User.NameLimit;
        txtLastName.MaxLength = FinalProject.Domain.User.NameLimit;
        txtEmail.MaxLength = FinalProject.Domain.User.EmailLimit;
        txtPassword.MaxLength = FinalProject.Domain.User.PasswordLimit;
        txtPasswordNew.MaxLength = FinalProject.Domain.User.PasswordLimit;
        txtUserName.MaxLength = FinalProject.Domain.User.NameLimit;

        plcNewPassword.Visible = User.Identity.IsAuthenticated;

        reqPassword.Visible = !User.Identity.IsAuthenticated;
        custPassword.Visible = User.Identity.IsAuthenticated;

        if (User.Identity.IsAuthenticated)
        {
            AdjustUIForExistingCustomer();
        }
    }

    protected void AdjustUIForExistingCustomer()
    {
        reqPassword.Visible = false;
        plcNewPassword.Visible = true;
        custPassword.Visible = true;

        Master.Header.Text = "Update Your Account!";
        lblPasswordText.Text = "Old Password:";
        btnUpdate.Text = "Save Your Changes!";

        if (!IsPostBack)
        {
            txtFirstName.Text = CurrentUser.FirstName;
            txtLastName.Text = CurrentUser.LastName;
            txtUserName.Text = CurrentUser.UserName;
            txtEmail.Text = CurrentUser.Email;
        }
    }

    protected void UpdateCustomer(object src, EventArgs e)
    {
        if (Page.IsValid)
        {

            if (User.Identity.IsAuthenticated)
            {
                CurrentUser.FirstName = txtFirstName.Text;
                CurrentUser.LastName = txtLastName.Text;
                CurrentUser.UserName = txtUserName.Text;
                CurrentUser.Email = txtEmail.Text;

                if (!String.IsNullOrEmpty(txtPasswordNew.Text))
                {
                    CurrentUser.Password = txtPasswordNew.Text;
                }

                userRepository.SaveOrUpdate(CurrentUser);
                this.Master.Header.BindCustomer(CurrentUser);

                lblResult.Text = "Congratulations! You have successfully updated your account.";
            }
            else
            {
                User customer = new User();
                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                customer.Email = txtEmail.Text;
                customer.UserName = txtUserName.Text;
                customer.Password = txtPassword.Text;
                userRepository.SaveOrUpdate(customer);

                if (!String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    FormsAuthentication.RedirectFromLoginPage(customer.Id.ToString(), false);
                }
                else
                {
                    lblResult.Text = "Congratulations! You have successfully created an account.";
                    FormsAuthentication.SetAuthCookie(customer.Id.ToString(), false);
                    AdjustUIForExistingCustomer();
                    Master.Footer.ResetLinks(true);
                    Master.Header.BindCustomer(customer);
                }
            }
        }
    }

    protected void ValidatePassword(object src, ServerValidateEventArgs e)
    {
        e.IsValid = true;

        if (!String.IsNullOrEmpty(txtPasswordNew.Text))
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                e.IsValid = false;
                custPassword.ErrorMessage = "You must provide your old password in order to change it.";
            }
            else
            {
                if (!CurrentUser.Password.Equals(txtPassword.Text))
                {
                    e.IsValid = false;
                    custPassword.ErrorMessage = "The old password you provided doesn't match the one on file.";
                }
            }
        }
    }

    protected void ValidateUserName(object src, ServerValidateEventArgs e)
    {
        e.IsValid = true;

        if (String.IsNullOrEmpty(txtUserName.Text))
        {
            e.IsValid = false;
        }

        bool checkUserName = true;

        if (User.Identity.IsAuthenticated)
        {
            if (CurrentUser.UserName.Equals(txtUserName.Text))
            {
                checkUserName = false;
            }
        }

        if (checkUserName)
        {
            try
            {
                if (userRepository.IsUserNameTaken(txtUserName.Text))
                {
                    e.IsValid = false;
                    custUserName.ErrorMessage = "That user name is already in use. Please enter another.";
                }
            }
            catch { }
        }
    }

    protected void ValidateEmail(object src, ServerValidateEventArgs e)
    {
        //TODO: validate email address
//        e.IsValid = FinalProject.Utils.StringValidator.IsValidEmailAddress(txtEmail.Text);
    }
}
