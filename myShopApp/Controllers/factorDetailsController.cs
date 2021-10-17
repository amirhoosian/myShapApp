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
    public class factorDetailsController : Controller
    {
        private readonly context _context;

        public factorDetailsController(context context)
        {
            _context = context;
        }

        //create
        public IActionResult Create()
        {
            ViewData["factorid"] = new SelectList(_context.factors, "id", "id");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,factorid,productid,numbers,itemPrice,fianlPrice,sellerName")] factorDetail factorDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factorDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["factorid"] = new SelectList(_context.factors, "id", "id", factorDetail.factorid);
            return View(factorDetail);
        }

        // update
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factorDetail = await _context.factorDetails.FindAsync(id);
            if (factorDetail == null)
            {
                return NotFound();
            }
            ViewData["factorid"] = new SelectList(_context.factors, "id", "id", factorDetail.factorid);
            return View(factorDetail);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,factorid,productid,numbers,itemPrice,fianlPrice,sellerName")] factorDetail factorDetail)
        {
            if (id != factorDetail.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factorDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!factorDetailExists(factorDetail.id))
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
            ViewData["factorid"] = new SelectList(_context.factors, "id", "id", factorDetail.factorid);
            return View(factorDetail);
        }

        // deleate
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factorDetail = await _context.factorDetails
                .Include(f => f.factor)
                .FirstOrDefaultAsync(m => m.id == id);
            if (factorDetail == null)
            {
                return NotFound();
            }

            return View(factorDetail);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factorDetail = await _context.factorDetails.FindAsync(id);
            _context.factorDetails.Remove(factorDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool factorDetailExists(int id)
        {
            return _context.factorDetails.Any(e => e.id == id);
        }
    }
}
