using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Interfaces
{
    public  interface IMenuRepository
    {
        List<Menu> GetAllMenu(EntAppConfig config);
        List<Menu> PaginationMenu(int pageNum, int pageSize, EntAppConfig config);
        void InsertMenu(Menu menu, EntAppConfig config);
        void EditMenu(Menu menu, EntAppConfig config);
        void DisableMenu(int id, EntAppConfig config);
        void DeleteByIdMenu(int Id, EntAppConfig config);
    }
}
