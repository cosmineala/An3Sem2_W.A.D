using System;

using RealDeal.AppLogic.Models;

namespace RealDeal.AppLogic.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromIdentity( int identityID );
    }
}
