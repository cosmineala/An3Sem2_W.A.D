using System;
using System.Collections.Generic;
namespace RealDeal.AppLogic.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal? StartPrice { get; set; }
        public DateTime? AuctionDate { get; set; }   //     YYYY-MM-DD hh:mm:ss[.nnn]
        public DateTime? AuctionDeadline { get; set; }

        public string? Description { get; set; }
        public string? Tag { get; set; }

        public int OwnerID { get; set; }
        public User Owner { get; set; }

        public int? BuyerID { get; set; }
        public User? Buyer { get; set; }

        public ICollection<AuctionRegistration> AuctionRegistrations { get; set; }
    }
}
