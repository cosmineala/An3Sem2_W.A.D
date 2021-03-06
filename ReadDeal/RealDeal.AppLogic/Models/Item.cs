﻿using System;
namespace RealDeal.AppLogic.Models
{
    public class Item
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public decimal StartPrice { get; set; }
        public DateTime AuctionDate { get; set; }
        public string Description { get; set; }
    }
}
