using Domian.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Interfaces;
using Task.Services;
using Util.Helpers;

namespace Facade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IConfiguration configuration)
        {
            _configuration = configuration;
            _productService = productService;
        }

        // GET GetAll
        [HttpGet]
        public List<Product> Get()
        {
            return _productService.BL_GetAllProduct(Common.getSettings(_configuration));
        }

        // GET Pagination
        [HttpGet("{pageNum}/{pageSize}")]
        public ActionResult<IEnumerable<Product>> Get(int pageNum, int pageSize)
        {
            return _productService.BL_PaginationProduct(pageNum, pageSize, Common.getSettings(_configuration));
        }

        // GET Search User
        [HttpPost("search")]
        public ActionResult<Product> Get([FromBody] Product product)
        {
            return _productService.BL_SearchProduct(product, Common.getSettings(_configuration));
        }

    }
}
