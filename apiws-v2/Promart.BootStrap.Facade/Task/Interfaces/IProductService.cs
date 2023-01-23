using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Interfaces
{
    public interface IProductService
    {

        Product BL_SearchProduct(Product product, EntAppConfig config);
        List<Product> BL_GetAllProduct(EntAppConfig config);
        List<Product> BL_PaginationProduct(int pageNum, int pageSize, EntAppConfig config);
    }
}
