using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class ProductsDAO
    {
        private readonly ApplicationContext _context;

        public ProductsDAO(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<List<tbl_genMasProduct>> GetProductsList()
        {
            return await _context.tbl_genMasProduct.ToListAsync();
        }

        public async Task<tbl_genMasProduct> GetProduct(string id)
        {
            var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);

            if (tbl_genMasProduct == null)
            {
                return null;
            }

            return tbl_genMasProduct;
        }
        
        public async Task<tbl_genMasProduct> PutProduct(string id, tbl_genMasProduct tbl_genMasProduct)
        {
            if (id != tbl_genMasProduct.product_ID)
            {
                return null;
            }

            _context.Entry(tbl_genMasProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return tbl_genMasProduct;
        }

        public async Task<tbl_genMasProduct> PostProduct(tbl_genMasProduct tbl_genMasProduct)
        {
            _context.tbl_genMasProduct.Add(tbl_genMasProduct);
            await _context.SaveChangesAsync();

            return tbl_genMasProduct;
        }

        public async Task<tbl_genMasProduct> DeleteProduct(string id)
        {
            var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);
            if (tbl_genMasProduct == null)
            {
                return null;
            }

            _context.tbl_genMasProduct.Remove(tbl_genMasProduct);
            await _context.SaveChangesAsync();

            return tbl_genMasProduct;
        }

        private bool ProductExists(string id)
        {
            return _context.tbl_genMasProduct.Any(e => e.product_ID == id);
        }
    }
}
