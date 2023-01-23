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
    public class MenuService: IMenuService
    {
        private readonly IMenuRepository _repository;
        public MenuService(IMenuRepository repository)
        {
            _repository = repository;
        }

        public List<Menu> BL_GetAllMenu(EntAppConfig config)
        {
            return _repository.GetAllMenu(config);
        }
        public List<Menu> BL_PaginationMenu(int pageNum, int pageSize,EntAppConfig config)
        {
            return _repository.PaginationMenu(pageNum, pageSize, config);
        }
        public void BL_InsertMenu(Menu menu, EntAppConfig config)
        {
            _repository.InsertMenu(menu, config);
        }
        public void BL_EditMenu(Menu menu, EntAppConfig config)
        {
            _repository.EditMenu(menu, config);
        }
        public void BL_DisableMenu(int id, EntAppConfig config)
        {
            _repository.DisableMenu(id, config);
        }
        public void BL_DeleteByIdMenu(int id, EntAppConfig config)
        {
            _repository.DeleteByIdMenu(id, config);
        }
    }
}
