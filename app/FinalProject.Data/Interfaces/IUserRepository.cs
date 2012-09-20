using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain;
using SharpArch.Core.PersistenceSupport;

namespace FinalProject.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsUserNameTaken(string username);
        User GetByUserName(string username);
    }
}
