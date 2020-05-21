using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealDeal.AppLogic.Models;
using RealDeal.AppLogic.Services;
using RealDeal.DataAccess;

namespace RealDeal.Controllers
{
    public class AdminItemsController : Controller
    {
        private readonly DataAccessDbContext _context;
        private readonly UserManager<IdentityUser> identityServices;
        private readonly UserService userService;
        private readonly ItemService itemService;

        public AdminItemsController(DataAccessDbContext context, UserManager<IdentityUser> identityServices, ItemService itemService, UserService userService)
        {
            _context = context;
            this.identityServices = identityServices;
            this.userService = userService;
            this.itemService = itemService;
        }

        // GET: AdminItems
        public async Task<IActionResult> Index()
        {
            var dataAccessDbContext = _context.Items.Include(i => i.Buyer).Include(i => i.Owner);
            return View(await dataAccessDbContext.ToListAsync());
        }

        // GET: AdminItems/Details/5
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

        // GET: AdminItems/Create
        public IActionResult Create()
        {
            ViewData["BuyerID"] = new SelectList(_context.Users, "ID", "ID");
            ViewData["OwnerID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: AdminItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StartPrice,AuctionDate,AuctionDeadline,Description,Tag")] Item item)
        {
            var user = userService.GetUserFromIdentity(identityServices.GetUserId(User));

            item.BuyerID = user.ID;
            item.OwnerID = user.ID;

            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyItemsForSale", "Items");
            }
            ViewData["BuyerID"] = new SelectList(_context.Users, "ID", "ID", item.BuyerID);
            ViewData["OwnerID"] = new SelectList(_context.Users, "ID", "ID", item.OwnerID);
            return View(item);
        }

        // GET: AdminItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["BuyerID"] = new SelectList(_context.Users, "ID", "ID", item.BuyerID);
            ViewData["OwnerID"] = new SelectList(_context.Users, "ID", "ID", item.OwnerID);
            return View(item);
        }

        // POST: AdminItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StartPrice,AuctionDate,AuctionDeadline,Description,Tag,OwnerID,BuyerID")] Item item)
        {
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerID"] = new SelectList(_context.Users, "ID", "ID", item.BuyerID);
            ViewData["OwnerID"] = new SelectList(_context.Users, "ID", "ID", item.OwnerID);
            return View(item);
        }

        // GET: AdminItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: AdminItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
