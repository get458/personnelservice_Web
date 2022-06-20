using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Personnel_Service.Data;
using Personnel_Service.Models;

namespace Personnel_Service.Controllers
{
    public class RoomConnectionsController : Controller
    {
        private readonly Personnel_ServiceContext _context;

        public RoomConnectionsController(Personnel_ServiceContext context)
        {
            _context = context;
        }

        // GET: RoomConnections
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomConnection.ToListAsync());
        }

        // GET: RoomConnections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomConnection = await _context.RoomConnection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomConnection == null)
            {
                return NotFound();
            }

            return View(roomConnection);
        }

        // GET: RoomConnections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomConnections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,RoomId")] RoomConnection roomConnection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomConnection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomConnection);
        }

        // GET: RoomConnections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomConnection = await _context.RoomConnection.FindAsync(id);
            if (roomConnection == null)
            {
                return NotFound();
            }
            return View(roomConnection);
        }

        // POST: RoomConnections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,RoomId")] RoomConnection roomConnection)
        {
            if (id != roomConnection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomConnection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomConnectionExists(roomConnection.Id))
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
            return View(roomConnection);
        }

        // GET: RoomConnections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomConnection = await _context.RoomConnection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomConnection == null)
            {
                return NotFound();
            }

            return View(roomConnection);
        }

        // POST: RoomConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomConnection = await _context.RoomConnection.FindAsync(id);
            _context.RoomConnection.Remove(roomConnection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomConnectionExists(int id)
        {
            return _context.RoomConnection.Any(e => e.Id == id);
        }
    }
}
