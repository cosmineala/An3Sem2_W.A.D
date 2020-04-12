using System;
namespace RealDeal.AppLogic.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string UserTypeID { get; set; }
        public UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}
