using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapLonC_Web.Data;
using BaiTapLonC_Web.Models;

namespace BaiTapLonC_Web.Controllers
{
    public class ProductKidsController : Controller
    {
        private readonly BaiTapLonC_WebContext _context;

        public ProductKidsController(BaiTapLonC_WebContext context)
        {
            _context = context;
        }

        // GET: ProductKids
        public async Task<IActionResult> Index()
        {
              return _context.ProductKid != null ? 
                          View(await _context.ProductKid.ToListAsync()) :
                          Problem("Entity set 'BaiTapLonC_WebContext.ProductKid'  is null.");
        }

        // GET: ProductKids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductKid == null)
            {
                return NotFound();
            }

            var productKid = await _context.ProductKid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productKid == null)
            {
                return NotFound();
            }

            return View(productKid);
        }

        // GET: ProductKids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductKids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stars,ImageUrl,Description")] ProductKid productKid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productKid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productKid);
        }

        // GET: ProductKids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductKid == null)
            {
                return NotFound();
            }

            var productKid = await _context.ProductKid.FindAsync(id);
            if (productKid == null)
            {
                return NotFound();
            }
            return View(productKid);
        }

        // POST: ProductKids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stars,ImageUrl,Description")] ProductKid productKid)
        {
            if (id != productKid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productKid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductKidExists(productKid.Id))
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
            return View(productKid);
        }

        // GET: ProductKids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductKid == null)
            {
                return NotFound();
            }

            var productKid = await _context.ProductKid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productKid == null)
            {
                return NotFound();
            }

            return View(productKid);
        }

        // POST: ProductKids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductKid == null)
            {
                return Problem("Entity set 'BaiTapLonC_WebContext.ProductKid'  is null.");
            }
            var productKid = await _context.ProductKid.FindAsync(id);
            if (productKid != null)
            {
                _context.ProductKid.Remove(productKid);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductKidExists(int id)
        {
          return (_context.ProductKid?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [HttpGet]
        [Route("productkids/index")]
        public async Task<IActionResult> GetData()
        {

            if (_context.ProductKid != null)
            {
                var products = await _context.ProductKid.ToListAsync();
                return Json(products);
            }
            else
            {
                return Problem("Entity set  is null.");
            }
        }
    }
}
