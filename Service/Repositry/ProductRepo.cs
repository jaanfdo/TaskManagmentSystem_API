using DataAccess;
using DataAccess.Context;
using DataAccess.DataAccess;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositry
{
    public class ProductRepo : IProduct
    {
        private readonly ApplicationContext _context;

        public ProductRepo(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<tbl_genMasProduct>> GetProductsListRepo()
        {
            return await new ProductsDAO(_context).GetProductsList();
        }
    }
}
