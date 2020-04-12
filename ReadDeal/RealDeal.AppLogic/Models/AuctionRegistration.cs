using System;
namespace RealDeal.AppLogic.Models
{
    public class AuctionRegistration
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}
