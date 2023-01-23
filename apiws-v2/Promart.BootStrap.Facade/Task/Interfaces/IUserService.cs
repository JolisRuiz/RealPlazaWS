using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Interfaces
{
    public interface IUserService
    {
        void BL_DeleteById(int Id, EntAppConfig config);
        Usuario BL_SearchUsuario(Usuario usuario, EntAppConfig config);
        void BL_DisableUser(int id, EntAppConfig config);
        void BL_EditUser(Usuario usuario, EntAppConfig config);
        List<Usuario> BL_GetAll(EntAppConfig config);
        void BL_Insert(Usuario usuario, EntAppConfig config);
        List<Usuario> BL_Pagination(int pageNum, int pageSize, EntAppConfig config);
    }
}
