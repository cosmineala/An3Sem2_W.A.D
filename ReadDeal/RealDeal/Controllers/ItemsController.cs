using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using RealDeal.AppLogic.Models;
using RealDeal.AppLogic.Services;
using RealDeal.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealDeal.Controllers
{
    public class ItemsController : Controller
    {
        private readonly UserManager<IdentityUser> identityServices;
        private readonly UserService userService;
        private readonly ItemService itemService;

        public ItemsController(UserManager<IdentityUser> identityServices, ItemService itemService, UserService userService)
        {
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
    }
}
