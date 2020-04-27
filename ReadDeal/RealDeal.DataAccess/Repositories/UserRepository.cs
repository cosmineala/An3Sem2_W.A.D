using System;

using RealDeal.AppLogic.Models;
using RealDeal.AppLogic.Abstractions;
using System.Linq;

namespace RealDeal.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository( DataAccesDbContext dbContext ) : base( dbContext )
        {
        }

        public User GetUserFromIdentity(int identityID)
        {
            return dbContext.Users
                .Where(p => p.ID == identityID)
                .SingleOrDefault();
        }
    }
}
