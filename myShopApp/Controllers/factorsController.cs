using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myShopApp.models;

namespace myShopApp.Controllers
{
    public class factorsController : Controller
    {
        private readonly context _context;

        public factorsController(context context)
        {
            _context = context;
        }

      

       

        //create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,buyerName,status,funalPrice")] factors factors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factors);
        }

        // update
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factors = await _context.factors.FindAsync(id);
            if (factors == null)
            {
                return NotFound();
            }
            return View(factors);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,buyerName,status,funalPrice")] factors factors)
        {
            if (id != factors.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!factorsExists(factors.id))
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
            return View(factors);
        }

        //delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factors = await _context.factors
                .FirstOrDefaultAsync(m => m.id == id);
            if (factors == null)
            {
                return NotFound();
            }

            return View(factors);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factors = await _context.factors.FindAsync(id);
            _context.factors.Remove(factors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool factorsExists(int id)
        {
            return _context.factors.Any(e => e.id == id);
        }
    }
}
