using System;
using System.Collections.Generic;
using RealDeal.AppLogic.Abstractions;

using RealDeal.AppLogic.Models;

namespace RealDeal.AppLogic.Services
{
    public class ItemService
    {
        private IItemRepository itemRepository;

        public ItemService( IItemRepository itemRepository )
        {
            this.itemRepository = itemRepository;
        }

        public Item GetItem( int id)
        {
            return itemRepository.GetItem(id);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return itemRepository.GetAll();
        }

        public IEnumerable<Item> GetMyItemsForSale( User user )
        {
            return itemRepository.GetItemsUserSales(user);
        }

        public IEnumerable<Item> GetUserGetUserAuctionRegistrations( User user)
        {
            return itemRepository.GetUserAuctionRegistrations(user);
        }

        public IEnumerable<Item> GetMyHistory( User user)
        {
            return itemRepository.GetUserHistory(user);
        }

        //public object GetMyItemsForSale(string v)
        //{
        //    throw new NotImplementedException();
        //}

        public void RegisterToBid( User user, Item item)
        {
            itemRepository.RegisterToBid(user, item);
        }

        public void UnregisterToBid(User user, Item item)
        {
            itemRepository.UnregisterToBid(user, item);
        }
    }
}
