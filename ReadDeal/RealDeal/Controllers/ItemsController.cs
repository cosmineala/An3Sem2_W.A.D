using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using RealDeal.AppLogic.Models;
using RealDeal.AppLogic.Services;
using RealDeal.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealDeal.Controllers
{
    public class ItemsController : Controller
    {
        private ItemService itemService;

        public ItemsController(ItemService itemService)
        {
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
           
            User user2 = new User();
            user2.ID = 2;

            var items = itemService.GetMyItemsForSale( user2 );

            Console.WriteLine("");
            return View(new ItemViewModel { Items = items });
        }
        
        public IActionResult ItemsIRegisteredToBid()
        {
            User user2 = new User();
            user2.ID = 2;

            var items = itemService.GetUserGetUserAuctionRegistrations(user2);
             
            return View( new ItemViewModel { Items = items } );
        }

        public IActionResult MyItemsHistory()
        {
            User user2 = new User();
            user2.ID = 2;

            var items = itemService.GetMyHistory(user2);

            Console.WriteLine("");
            return View(new ItemViewModel { Items = items });
            //return View();
        }
    }
}
