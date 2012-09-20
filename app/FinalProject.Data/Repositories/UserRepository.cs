using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Domain;
using NHibernate;
using NHibernate.Criterion;
using FinalProject.Data.Interfaces;

namespace FinalProject.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public bool IsUserNameTaken(string username)
        {
            ICriteria criteria = Session.CreateCriteria<User>();
            criteria.SetProjection(Projections.Count("Id"));
            criteria.Add(Expression.Like("UserName", username, MatchMode.Exact));
            return (criteria.UniqueResult<int>() != 0);
        }

        public User GetByUserName(string username)
        {
            ICriteria criteria = Session.CreateCriteria<User>();
            criteria.Add(Expression.Like("UserName", username, MatchMode.Exact));
            return criteria.UniqueResult<User>();
        }
    }
}
