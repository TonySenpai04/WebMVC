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
    public class ProductWomenController : Controller
    {
        private readonly BaiTapLonC_WebContext _context;

        public ProductWomenController(BaiTapLonC_WebContext context)
        {
            _context = context;
        }

        // GET: ProductWomen
        public async Task<IActionResult> Index()
        {
              return _context.ProductWomen != null ? 
                          View(await _context.ProductWomen.ToListAsync()) :
                          Problem("Entity set 'BaiTapLonC_WebContext.ProductWomen'  is null.");
        }

        // GET: ProductWomen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductWomen == null)
            {
                return NotFound();
            }

            var productWomen = await _context.ProductWomen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productWomen == null)
            {
                return NotFound();
            }

            return View(productWomen);
        }

        // GET: ProductWomen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductWomen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stars,ImageUrl,Description")] ProductWomen productWomen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productWomen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productWomen);
        }

        // GET: ProductWomen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductWomen == null)
            {
                return NotFound();
            }

            var productWomen = await _context.ProductWomen.FindAsync(id);
            if (productWomen == null)
            {
                return NotFound();
            }
            return View(productWomen);
        }

        // POST: ProductWomen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stars,ImageUrl,Description")] ProductWomen productWomen)
        {
            if (id != productWomen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productWomen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductWomenExists(productWomen.Id))
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
            return View(productWomen);
        }

        // GET: ProductWomen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductWomen == null)
            {
                return NotFound();
            }

            var productWomen = await _context.ProductWomen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productWomen == null)
            {
                return NotFound();
            }

            return View(productWomen);
        }

        // POST: ProductWomen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductWomen == null)
            {
                return Problem("Entity set 'BaiTapLonC_WebContext.ProductWomen'  is null.");
            }
            var productWomen = await _context.ProductWomen.FindAsync(id);
            if (productWomen != null)
            {
                _context.ProductWomen.Remove(productWomen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductWomenExists(int id)
        {
          return (_context.ProductWomen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [HttpGet]
        [Route("productwomen/index")]
        public async Task<IActionResult> GetData()
        {

            if (_context.ProductWomen != null)
            {
                var products = await _context.ProductWomen.ToListAsync();
                return Json(products);
            }
            else
            {
                return Problem("Entity set  is null.");
            }
        }
    }
}
