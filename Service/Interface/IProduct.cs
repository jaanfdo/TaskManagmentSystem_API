using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProduct
    {
        Task<List<tbl_genMasProduct>> GetProductsListRepo();
    }
}
