using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Domain;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core;
using FinalProject.Data.Repositories;
using FinalProject.Data.Interfaces;

public class AccountPage : System.Web.UI.Page
{
    protected IUserRepository userRepository = SafeServiceLocator<IUserRepository>.GetService();
    private User user = null;

    protected User CurrentUser
    {
        get
        {
            if (User.Identity.IsAuthenticated && user == null)
            {
                user = userRepository.GetByUserName(User.Identity.Name);
            }

            return user;
        }
    }
}