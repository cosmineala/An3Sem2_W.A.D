using System;
using System.Linq;

using RealDeal.AppLogic.Abstractions;
using RealDeal.AppLogic.Models;

namespace RealDeal.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository( DataAccessDbContext dbContext) : base(dbContext)
        {
        }

        public User GetUserFromIdentity(Guid identityID)
        {
            return dbContext.Users
                .Where(p => p.IdentityID == identityID)
                .SingleOrDefault();
        }

        public void UpdateUser( User user )
        {
            var result = dbContext.Users
                                  .Where( p => p.ID == user.ID )
                                  .SingleOrDefault();

            if( result != null)
            {
                if( user.Name != null)
                {
                    result.Name = user.Name;
                }
                if( user.Phone != null)
                {
                    result.Phone = user.Phone;
                }
                if( user.Adress != null)
                {
                    result.Adress = user.Adress;
                }
            }

            dbContext.SaveChanges();
        }
    }
}
