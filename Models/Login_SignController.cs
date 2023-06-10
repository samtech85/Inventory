using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;

namespace Inventory.Models
{
    public class Login_SignController : Controller
    {
        private readonly InformationDbContext _context;

        public Login_SignController(InformationDbContext context)
        {
            _context = context;
        }

        // GET: Login_Sign
        public async Task<IActionResult> Index()
        {
              return _context.Login_Signs != null ? 
                          View(await _context.Login_Signs.ToListAsync()) :
                          Problem("Entity set 'InformationDbContext.Login_Signs'  is null.");
        }

        // GET: Login_Sign/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Login_Signs == null)
            {
                return NotFound();
            }

            var login_Sign = await _context.Login_Signs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login_Sign == null)
            {
                return NotFound();
            }

            return View(login_Sign);
        }

        // GET: Login_Sign/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login_Sign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Email,Phone")] Login_Sign login_Sign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login_Sign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login_Sign);
        }

        // GET: Login_Sign/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Login_Signs == null)
            {
                return NotFound();
            }

            var login_Sign = await _context.Login_Signs.FindAsync(id);
            if (login_Sign == null)
            {
                return NotFound();
            }
            return View(login_Sign);
        }

        // POST: Login_Sign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Email,Phone")] Login_Sign login_Sign)
        {
            if (id != login_Sign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login_Sign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Login_SignExists(login_Sign.Id))
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
            return View(login_Sign);
        }

        // GET: Login_Sign/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Login_Signs == null)
            {
                return NotFound();
            }

            var login_Sign = await _context.Login_Signs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login_Sign == null)
            {
                return NotFound();
            }

            return View(login_Sign);
        }

        // POST: Login_Sign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Login_Signs == null)
            {
                return Problem("Entity set 'InformationDbContext.Login_Signs'  is null.");
            }
            var login_Sign = await _context.Login_Signs.FindAsync(id);
            if (login_Sign != null)
            {
                _context.Login_Signs.Remove(login_Sign);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Login_SignExists(int id)
        {
          return (_context.Login_Signs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
