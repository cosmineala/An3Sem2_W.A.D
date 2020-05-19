using System;
using System.Collections.Generic;
using RealDeal.AppLogic.Models;

namespace RealDeal.AppLogic.Abstractions
{
    public interface IItemRepository : IRepository<Item>
    {
        IEnumerable<Item> GetItemsUserSales(User user);
        IEnumerable<Item> GetUserAuctionRegistrations(User user);
        IEnumerable<Item> GetUserHistory(User user);
        Item GetItem(int id);
    }
}
