using Domian.Models;
using Microsoft.AspNetCore.Mvc;
using Task.Interfaces;
using Util.Helpers;

namespace Facade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService,IConfiguration configuration)
        {
            _configuration = configuration;
            _menuService = menuService;
        }

        // GET api/usuario
        [HttpGet]
        public List<Menu> Get()
        {
            return _menuService.BL_GetAllMenu(Common.getSettings(_configuration));
        }

        // GET Pagination
        [HttpGet("{pageNum}/{pageSize}")]
        public ActionResult<IEnumerable<Menu>> GetDatos(int pageNum, int pageSize)
        {
            return _menuService.BL_PaginationMenu(pageNum, pageSize, Common.getSettings(_configuration));            
        }

        // POST Add User
        [HttpPost]
        public void Post([FromBody] Menu menu)
        {
            _menuService.BL_InsertMenu(menu, Common.getSettings(_configuration));
        }

        // PUT Edit User
        [HttpPut]
        public void Put([FromBody] Menu menu)
        {
            _menuService.BL_EditMenu(menu, Common.getSettings(_configuration));
        }

        // PUT Disable User
        [HttpPut("{id}")]
        public void PutDisableUser(int id)
        {
            _menuService.BL_DisableMenu(id, Common.getSettings(_configuration));
        }

        // DELETE User for ID
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _menuService.BL_DeleteByIdMenu(id, Common.getSettings(_configuration));
        }
    }
}
