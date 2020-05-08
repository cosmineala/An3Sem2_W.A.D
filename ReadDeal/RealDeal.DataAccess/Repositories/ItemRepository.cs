using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RealDeal.AppLogic.Abstractions;
using RealDeal.AppLogic.Models;

namespace RealDeal.DataAccess.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository( DataAccessDbContext dbContext ) : base( dbContext )
        {
        }

        public IEnumerable<Item> GetUserAuctionRegistrations(User user)
        {
            var registrations = dbContext.AuctionRegistrations
                                         .Where(p => p.UserID == user.ID)
                                         .AsEnumerable();

            List<Item> items = new List<Item>();

            foreach (AuctionRegistration registration in registrations)
            {
                Item item = dbContext.Items
                                    .Where(p => p.ID == registration.ItemID)
                                    .SingleOrDefault();

                items.Add(item);
            }
            return items.AsEnumerable();
        }
            

            public IEnumerable<Item> GetItemsUserSales(User user)
        {
            //return dbContext.Items.Include( a => a.History ).Include( a => a.History.User )
            return dbContext.Items.Include(a => a.History).Include(a => a.History.User)
                .Where(p => p.UserID == user.ID)
                .AsEnumerable();
        }

        public IEnumerable<Item> GetUserHistory(User user)
        {
            throw new NotImplementedException();
        }
    }
}
