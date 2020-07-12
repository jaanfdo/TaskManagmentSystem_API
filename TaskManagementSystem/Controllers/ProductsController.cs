using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Context;
using DataAccess.DataAccess;
using Service.Interface;
using Service.Repositry;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private IProduct _product;

        public ProductsController(ApplicationContext context)
        {
            _context = context;
            _product = new ProductRepo(_context);
        }

        // GET: api/Products
        [HttpGet]
        public async Task<List<tbl_genMasProduct>> GetProduct()
        {
            //await IProduct products = new ProductRepo(_context).GetProductsListRepo();
            return await _product.GetProductsListRepo();// _context.tbl_genMasProduct.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_genMasProduct>> GetProduct(string id)
        {
            var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);

            if (tbl_genMasProduct == null)
            {
                return NotFound();
            }

            return tbl_genMasProduct;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_genMasProduct(string id, tbl_genMasProduct tbl_genMasProduct)
        {
            if (id != tbl_genMasProduct.product_ID)
            {
                return BadRequest();
            }

            _context.Entry(tbl_genMasProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_genMasProductExists(id))
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

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<tbl_genMasProduct>> Posttbl_genMasProduct(tbl_genMasProduct tbl_genMasProduct)
        {
            _context.tbl_genMasProduct.Add(tbl_genMasProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_genMasProduct", new { id = tbl_genMasProduct.product_ID }, tbl_genMasProduct);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tbl_genMasProduct>> Deletetbl_genMasProduct(string id)
        {
            var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);
            if (tbl_genMasProduct == null)
            {
                return NotFound();
            }

            _context.tbl_genMasProduct.Remove(tbl_genMasProduct);
            await _context.SaveChangesAsync();

            return tbl_genMasProduct;
        }

        private bool tbl_genMasProductExists(string id)
        {
            return _context.tbl_genMasProduct.Any(e => e.product_ID == id);
        }
    }
}
