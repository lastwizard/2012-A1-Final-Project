using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Data.Interfaces;
using SharpArch.Core;

namespace FinalProject.Web.Security
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {
        public override string ApplicationName { get { return "Custom"; } set{} }

        public override string[] GetRolesForUser(string username)
        {
            var rep = SafeServiceLocator<IUserRepository>.GetService();
            var user = rep.GetByUserName(username);
            if (user == null) return new string[0];
            return new string[1] { user.RoleType.ToString() };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (String.IsNullOrEmpty(roleName)) return false;

            var rep = SafeServiceLocator<IUserRepository>.GetService();
            var user = rep.GetByUserName(username);
            if (user == null) return false;
            return roleName.Equals(user.RoleType.ToString());
        }

        public override string[] GetAllRoles()
        {
            return Enum.GetNames(typeof(FinalProject.Domain.RoleType));
        }

        public override bool RoleExists(string roleName)
        {
            bool result = false;
            foreach (string role in Enum.GetNames(typeof(FinalProject.Domain.RoleType)))
            {
                if (role.Equals(roleName))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
    }
}