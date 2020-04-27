using System;
using System.Collections.Generic;

namespace RealDeal.AppLogic.Models
{
    public class User
    {
        //public Guid IdentityID { get; set; }
        public int ID { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }

        public ICollection<History> Histories { get; set; }

        public ICollection<AuctionRegistration> AuctionRegistrations { get; set; }
    }
}
