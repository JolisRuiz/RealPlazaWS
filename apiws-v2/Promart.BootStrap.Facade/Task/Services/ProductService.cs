using Domian.Interfaces;
using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Interfaces;

namespace Task.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public Product BL_SearchProduct(Product product, EntAppConfig config)
        {
            return _repository.SearchProduct(product, config);
        }

        public List<Product> BL_GetAllProduct(EntAppConfig config)
        {
            return _repository.GetAllProduct(config);
        }

        public List<Product> BL_PaginationProduct(int pageNum, int pageSize, EntAppConfig config)
        {
            return _repository.PaginationProduct(pageNum, pageSize, config);
        }
    }
}
