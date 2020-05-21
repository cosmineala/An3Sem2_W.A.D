using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealDeal.AppLogic.Models;
using RealDeal.AppLogic.Services;
using RealDeal.DataAccess;
using RealDeal.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealDeal.Controllers
{
    public class ItemsController : Controller
    {
        private readonly DataAccessDbContext _context;
        private readonly UserManager<IdentityUser> identityServices;
        private readonly UserService userService;
        private readonly ItemService itemService;

        public ItemsController( DataAccessDbContext _context, UserManager<IdentityUser> identityServices, ItemService itemService, UserService userService)
        {
            this._context = _context;
            this.identityServices = identityServices;
            this.userService = userService; 
            this.itemService = itemService;
        }

        public IActionResult Index()
        {
            var items = itemService.GetAllItems();

            return View( new ItemViewModel { Items = items });
            //return View(  );
        }

        public IActionResult MyItemsForSale()
        {
            var user = userService.GetUserFromIdentity( identityServices.GetUserId(User) );
            var items = itemService.GetMyItemsForSale( user );

            Console.WriteLine("");
            return View(new ItemViewModel { Items = items });
        }
        
        public IActionResult ItemsIRegisteredToBid()
        {
            var user = userService.GetUserFromIdentity(identityServices.GetUserId(User));

            var items = itemService.GetUserGetUserAuctionRegistrations(user);
             
            return View( new ItemViewModel { Items = items } );
        }

        public IActionResult MyItemsHistory()
        {
            var user = userService.GetUserFromIdentity(identityServices.GetUserId(User));

            var items = itemService.GetMyHistory(user);

            Console.WriteLine("");
            return View(new ItemViewModel { Items = items });
            //return View();
        }

        public IActionResult RegisterMeToBid( int id)
        {
            var user = userService.GetUserFromIdentity(identityServices.GetUserId(User));
            var item = itemService.GetItem(id);

            itemService.RegisterToBid(user, item);

            return RedirectToAction(nameof(ItemsIRegisteredToBid ));
        }


        public IActionResult UnregisterMeToBid(int id)
        {
            var user = userService.GetUserFromIdentity(identityServices.GetUserId(User));
            var item = itemService.GetItem(id);

            itemService.UnregisterToBid(user, item);

            return RedirectToAction(nameof(ItemsIRegisteredToBid));
        }

        //[HttpPost]
        //public IActionResult SubmitBid( [Bind("StartPrice","ItemID")] int startPrice)
        //{

        //    return View();
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Buyer)
                .Include(i => i.Owner)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Details(int id, [Bind("ID,Name,StartPrice,AuctionDate,AuctionDeadline,Description,Tag,OwnerID,BuyerID")] Item item)
        {
            var user = userService.GetUserFromIdentity(identityServices.GetUserId(User));

            item.Buyer = user;
            item.BuyerID = user.ID;

            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View( item );
            }

            return View(item);
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
