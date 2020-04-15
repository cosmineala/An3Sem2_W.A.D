using System;
using System.Collections.Generic;
namespace RealDeal.AppLogic.Models
{
    public class UserType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
