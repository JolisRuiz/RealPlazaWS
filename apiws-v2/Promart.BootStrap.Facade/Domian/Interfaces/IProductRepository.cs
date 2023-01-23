using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct(EntAppConfig config);
        Product SearchProduct(Product usuario, EntAppConfig config);
        List<Product> PaginationProduct(int pageNum, int pageSize, EntAppConfig config);
    }
}
