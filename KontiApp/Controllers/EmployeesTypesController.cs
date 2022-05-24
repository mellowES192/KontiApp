using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KontiApp.Data;
using KontiApp.Models;

namespace KontiApp.Controllers
{
    public class EmployeesTypesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesTypes
        public async Task<IActionResult> Index()
        {
              return _context.EmployeesTypes != null ? 
                          View(await _context.EmployeesTypes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.EmployeesTypes'  is null.");
        }

        // GET: EmployeesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeesTypes == null)
            {
                return NotFound();
            }

            var employeesType = await _context.EmployeesTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeesType == null)
            {
                return NotFound();
            }

            return View(employeesType);
        }

        // GET: EmployeesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeesTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] EmployeesType employeesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeesType);
        }

        // GET: EmployeesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeesTypes == null)
            {
                return NotFound();
            }

            var employeesType = await _context.EmployeesTypes.FindAsync(id);
            if (employeesType == null)
            {
                return NotFound();
            }
            return View(employeesType);
        }

        // POST: EmployeesTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] EmployeesType employeesType)
        {
            if (id != employeesType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesTypeExists(employeesType.Id))
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
            return View(employeesType);
        }

        // GET: EmployeesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeesTypes == null)
            {
                return NotFound();
            }

            var employeesType = await _context.EmployeesTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeesType == null)
            {
                return NotFound();
            }

            return View(employeesType);
        }

        // POST: EmployeesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeesTypes == null)
            {
                return Problem("Entity set 'AppDbContext.EmployeesTypes'  is null.");
            }
            var employeesType = await _context.EmployeesTypes.FindAsync(id);
            if (employeesType != null)
            {
                _context.EmployeesTypes.Remove(employeesType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesTypeExists(int id)
        {
          return (_context.EmployeesTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
