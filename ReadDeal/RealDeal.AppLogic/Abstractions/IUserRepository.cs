using System;
using RealDeal.AppLogic.Abstractions;
using RealDeal.AppLogic.Models;

namespace RealDeal.AppLogic.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromIdentity(Guid identityID);
        void UpdateUser(User user);
    }
}
