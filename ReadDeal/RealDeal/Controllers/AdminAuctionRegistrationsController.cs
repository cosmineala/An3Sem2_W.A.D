using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealDeal.AppLogic.Models;
using RealDeal.DataAccess;

namespace RealDeal.Controllers
{
    public class AdminAuctionRegistrationsController : Controller
    {
        private readonly DataAccessDbContext _context;

        public AdminAuctionRegistrationsController(DataAccessDbContext context)
        {
            _context = context;
        }

        // GET: AdminAuctionRegistrations
        public async Task<IActionResult> Index()
        {
            var dataAccessDbContext = _context.AuctionRegistrations.Include(a => a.Item).Include(a => a.User);
            return View(await dataAccessDbContext.ToListAsync());
        }

        // GET: AdminAuctionRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctionRegistration = await _context.AuctionRegistrations
                .Include(a => a.Item)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (auctionRegistration == null)
            {
                return NotFound();
            }

            return View(auctionRegistration);
        }

        // GET: AdminAuctionRegistrations/Create
        public IActionResult Create()
        {
            ViewData["ItemID"] = new SelectList(_context.Items, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: AdminAuctionRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,ItemID")] AuctionRegistration auctionRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auctionRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemID"] = new SelectList(_context.Items, "ID", "ID", auctionRegistration.ItemID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", auctionRegistration.UserID);
            return View(auctionRegistration);
        }

        // GET: AdminAuctionRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctionRegistration = await _context.AuctionRegistrations.FindAsync(id);
            if (auctionRegistration == null)
            {
                return NotFound();
            }
            ViewData["ItemID"] = new SelectList(_context.Items, "ID", "ID", auctionRegistration.ItemID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", auctionRegistration.UserID);
            return View(auctionRegistration);
        }

        // POST: AdminAuctionRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,ItemID")] AuctionRegistration auctionRegistration)
        {
            if (id != auctionRegistration.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auctionRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionRegistrationExists(auctionRegistration.UserID))
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
            ViewData["ItemID"] = new SelectList(_context.Items, "ID", "ID", auctionRegistration.ItemID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", auctionRegistration.UserID);
            return View(auctionRegistration);
        }

        // GET: AdminAuctionRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctionRegistration = await _context.AuctionRegistrations
                .Include(a => a.Item)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (auctionRegistration == null)
            {
                return NotFound();
            }

            return View(auctionRegistration);
        }

        // POST: AdminAuctionRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auctionRegistration = await _context.AuctionRegistrations.FindAsync(id);
            _context.AuctionRegistrations.Remove(auctionRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionRegistrationExists(int id)
        {
            return _context.AuctionRegistrations.Any(e => e.UserID == id);
        }
    }
}
