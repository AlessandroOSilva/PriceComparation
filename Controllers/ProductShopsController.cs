using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricesComparation.Models;
using PricesComparation.Models.Context;

namespace PricesComparation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductShopsController : ControllerBase
    {
        private readonly PricesComparationContext _context;

        public ProductShopsController(PricesComparationContext context)
        {
            _context = context;
        }

        // GET: api/ProductShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductShop>>> GetProductShops()
        {
            return await _context.ProductShops.Include(p => p.Product).Include(p => p.Product.Brand).Include(s => s.Shop.Address).ToListAsync();
        }

        // GET: api/ProductShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductShop>> GetProductShop(int id)
        {
            var productShop = await _context.ProductShops.FindAsync(id);

            if (productShop == null)
            {
                return NotFound();
            }

            return productShop;
        }

        // PUT: api/ProductShops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductShop(int id, ProductShop productShop)
        {
            if (id != productShop.ProductShopId)
            {
                return BadRequest();
            }
            var pr = new PriceRecord();
            
            pr.Price = productShop.Price;
            pr.PriceDate = productShop.PriceDate;

            productShop.AddRecord(pr);
            _context.Entry(productShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductShopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductShop>> PostProductShop(ProductShop productShop)
        {
            _context.ProductShops.Add(productShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductShop", new { id = productShop.ProductShopId }, productShop);
        }

        // DELETE: api/ProductShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductShop(int id)
        {
            var productShop = await _context.ProductShops.FindAsync(id);
            if (productShop == null)
            {
                return NotFound();
            }

            _context.ProductShops.Remove(productShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductShopExists(int id)
        {
            return _context.ProductShops.Any(e => e.ProductShopId == id);
        }
    }
}
