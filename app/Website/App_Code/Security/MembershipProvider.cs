using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Data.Interfaces;
using SharpArch.Core;

namespace FinalProject.Web.Security
{
    public class MembershipProvider : System.Web.Security.MembershipProvider
    {
        public override string ApplicationName { get { return "FinalProject"; } set { } }

        public override bool ValidateUser(string username, string password)
        {
            var rep = SafeServiceLocator<IUserRepository>.GetService();
            var user = rep.GetByUserName(username);
            return (user != null && user.Password.Equals(password));
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { return true; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return true; }
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            var rep = SafeServiceLocator<IUserRepository>.GetService();
            var user = rep.GetByUserName(username);
            if (user == null) return null;
            return user.Password;
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            var rep = SafeServiceLocator<IUserRepository>.GetService();
            var user = rep.GetByUserName(username);
            if (user == null) return null;
            return new System.Web.Security.MembershipUser("FinalProjectMembershipProvider", username, user.Id, user.Email, String.Empty, String.Empty, true, false, 
                DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.MinValue);
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 5; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 1; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 7; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 5; }
        }

        public override System.Web.Security.MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}