using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Interfaces
{
    public  interface IUserRepository
    {
        List<Usuario> GetAll(EntAppConfig config);
        Usuario SearchUsuario(Usuario usuario, EntAppConfig config);
        List<Usuario> Pagination(int pageNum, int pageSize, EntAppConfig config);
        void Insert(Usuario usuario, EntAppConfig config);
        void EditUser(Usuario usuario, EntAppConfig config);
        void DisableUser(int id, EntAppConfig config);
        void DeleteById(int Id, EntAppConfig config);
    }
}
