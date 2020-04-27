using System;

using RealDeal.AppLogic.Abstractions;
using RealDeal.AppLogic.Models;

namespace RealDeal.AppLogic.Services
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService( IUserRepository userRepository )
        {
            this.userRepository = userRepository;
        }

        public User GetUserByIdentity(int identityID)
        {
            //Guid userID = Guid.Empty;
            //if (Guid.TryParse(identityID, out userID) == false)
            //{
            //    throw new Exception("Invalid Guid Format");
            //}

            //var user = userRepository.GetUserFromIdentity(userID);
            var user = userRepository.GetUserFromIdentity(identityID);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

    }
}
