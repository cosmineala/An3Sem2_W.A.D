using System;
using System.Collections.Generic;
using RealDeal.AppLogic.Models;

namespace RealDeal.AppLogic.Abstractions
{
    public interface IItemRepository : IRepository<Item>
    {
        Item GetItem(int id);
        IEnumerable<Item> GetItemsUserSales(User user);
        IEnumerable<Item> GetUserAuctionRegistrations(User user);
        IEnumerable<Item> GetUserHistory(User user);
        void RegisterToBid(User user, Item item);
        void UnregisterToBid(User user, Item item);
    }
}
