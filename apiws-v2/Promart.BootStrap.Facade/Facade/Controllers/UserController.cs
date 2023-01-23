using Domian.Models;
using Microsoft.AspNetCore.Mvc;
using Task.Interfaces;
using Util.Helpers;
namespace Facade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _configuration = configuration;
            _userService = userService;
        }

        // GET GetAll
        [HttpGet]
        public List<Usuario> Get()
        {
            return _userService.BL_GetAll(Common.getSettings(_configuration));
        }

        // GET Pagination
        [HttpGet("{pageNum}/{pageSize}")]
        public ActionResult<IEnumerable<Usuario>> Get(int pageNum, int pageSize)
        {
            return _userService.BL_Pagination(pageNum, pageSize, Common.getSettings(_configuration));
        }

        // GET Search User
        [HttpPost("search")]
        public ActionResult<Usuario> Get([FromBody] Usuario usuario)
        {
            return _userService.BL_SearchUsuario(usuario, Common.getSettings(_configuration));
        }

        // POST Add User
        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            _userService.BL_Insert(usuario, Common.getSettings(_configuration));
        }

        // PUT Edit User
        [HttpPut]
        public void Put([FromBody] Usuario usuario)
        {
            _userService.BL_EditUser(usuario, Common.getSettings(_configuration));
        }

        // PUT Disable User
        [HttpPut("{id}")]
        public void PutDisableUser(int id)
        {
            _userService.BL_DisableUser(id, Common.getSettings(_configuration));
        }

        // DELETE User for ID
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.BL_DeleteById(id, Common.getSettings(_configuration));
        }
    }
}
