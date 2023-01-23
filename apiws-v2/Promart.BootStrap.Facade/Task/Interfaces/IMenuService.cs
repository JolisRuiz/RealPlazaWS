using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Interfaces
{
    public interface IMenuService
    {
        List<Menu> BL_GetAllMenu(EntAppConfig config);
        List<Menu> BL_PaginationMenu(int pageNum, int pageSize, EntAppConfig config);
        void BL_InsertMenu(Menu menu, EntAppConfig config);
        void BL_EditMenu(Menu menu, EntAppConfig config);
        void BL_DisableMenu(int id, EntAppConfig config);
        void BL_DeleteByIdMenu(int id, EntAppConfig config);
    }
}
