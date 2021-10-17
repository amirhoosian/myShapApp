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
    public class catgoriesController : Controller
    {
        private readonly context _context;

        public catgoriesController(context context)
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
        public async Task<IActionResult> Create([Bind("id,title")] catgory catgory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catgory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catgory);
        }

        // update
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catgory = await _context.catgory.FindAsync(id);
            if (catgory == null)
            {
                return NotFound();
            }
            return View(catgory);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title")] catgory catgory)
        {
            if (id != catgory.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catgory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!catgoryExists(catgory.id))
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
            return View(catgory);
        }

        //delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catgory = await _context.catgory
                .FirstOrDefaultAsync(m => m.id == id);
            if (catgory == null)
            {
                return NotFound();
            }

            return View(catgory);
        }
         [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catgory = await _context.catgory.FindAsync(id);
            _context.catgory.Remove(catgory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool catgoryExists(int id)
        {
            return _context.catgory.Any(e => e.id == id);
        }
    }
}
