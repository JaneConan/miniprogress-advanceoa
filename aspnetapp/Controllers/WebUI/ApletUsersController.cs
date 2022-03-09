#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspnetapp;

namespace aspnetapp.Controllers.WebUI
{
    public class ApletUsersController : Controller
    {
        private readonly CounterContext _context;

        public ApletUsersController(CounterContext context)
        {
            _context = context;
        }

        // GET: ApletUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApletUsers.ToListAsync());
        }

        // GET: ApletUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apletUser = await _context.ApletUsers
                .FirstOrDefaultAsync(m => m.id == id);
            if (apletUser == null)
            {
                return NotFound();
            }

            return View(apletUser);
        }

        // GET: ApletUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApletUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,UserName,Phone,Demand,createdAt")] ApletUser apletUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apletUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apletUser);
        }

        // GET: ApletUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apletUser = await _context.ApletUsers.FindAsync(id);
            if (apletUser == null)
            {
                return NotFound();
            }
            return View(apletUser);
        }

        // POST: ApletUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,UserName,Phone,Demand,createdAt")] ApletUser apletUser)
        {
            if (id != apletUser.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apletUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApletUserExists(apletUser.id))
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
            return View(apletUser);
        }

        // GET: ApletUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apletUser = await _context.ApletUsers
                .FirstOrDefaultAsync(m => m.id == id);
            if (apletUser == null)
            {
                return NotFound();
            }

            return View(apletUser);
        }

        // POST: ApletUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apletUser = await _context.ApletUsers.FindAsync(id);
            _context.ApletUsers.Remove(apletUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApletUserExists(int id)
        {
            return _context.ApletUsers.Any(e => e.id == id);
        }
    }
}
