using System;
namespace RealDeal.AppLogic.Models
{
    public class History
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
