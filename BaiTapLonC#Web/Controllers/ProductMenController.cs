using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapLonC_Web.Data;
using BaiTapLonC_Web.Models;
using Microsoft.AspNetCore.Builder;

namespace BaiTapLonC_Web.Controllers
{
    public class ProductMenController : Controller
    {
        private readonly BaiTapLonC_WebContext _context;

        public ProductMenController(BaiTapLonC_WebContext context)
        {
            _context = context;
        }

        // GET: ProductMen

        public async Task<IActionResult> Index()
        {


            return _context.ProductMen != null ?
                        View(await _context.ProductMen.ToListAsync()) :
                        Problem("Entity set 'BaiTapLonC_WebContext.ProductMen'  is null.");
        }

        // GET: ProductMen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductMen == null)
            {
                return NotFound();
            }

            var productMen = await _context.ProductMen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productMen == null)
            {
                return NotFound();
            }

            return View(productMen);
        }

        // GET: ProductMen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductMen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stars,ImageUrl,Description")] ProductMen productMen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productMen);
        }

        // GET: ProductMen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductMen == null)
            {
                return NotFound();
            }

            var productMen = await _context.ProductMen.FindAsync(id);
            if (productMen == null)
            {
                return NotFound();
            }
            return View(productMen);
        }

        // POST: ProductMen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stars,ImageUrl,Description")] ProductMen productMen)
        {
            if (id != productMen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMenExists(productMen.Id))
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
            return View(productMen);
        }

        // GET: ProductMen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductMen == null)
            {
                return NotFound();
            }

            var productMen = await _context.ProductMen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productMen == null)
            {
                return NotFound();
            }

            return View(productMen);
        }

        // POST: ProductMen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductMen == null)
            {
                return Problem("Entity set 'BaiTapLonC_WebContext.ProductMen'  is null.");
            }
            var productMen = await _context.ProductMen.FindAsync(id);
            if (productMen != null)
            {
                _context.ProductMen.Remove(productMen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMenExists(int id)
        {
          return (_context.ProductMen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [HttpGet]
        [Route("productmen/index")]
        public async Task<IActionResult> GetData()
        {

            if (_context.ProductMen != null)
            {
                var products = await _context.ProductMen.ToListAsync();
                return Json(products);
            }
            else
            {
                return Problem("Entity set  is null.");
            }
        }
       
    }
}
