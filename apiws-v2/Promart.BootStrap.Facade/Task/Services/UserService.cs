
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
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public void BL_DeleteById(int Id, EntAppConfig config)
        {
            _repository.DeleteById(Id, config);
        }

        public Usuario BL_SearchUsuario(Usuario usuario, EntAppConfig config)
        {
            return _repository.SearchUsuario(usuario, config);
        }

        public void BL_DisableUser(int id, EntAppConfig config)
        {
            _repository.DisableUser(id, config);
        }

        public void BL_EditUser(Usuario usuario, EntAppConfig config)
        {
            _repository.EditUser(usuario, config);
        }

        public List<Usuario> BL_GetAll( EntAppConfig config)
        {
            return _repository.GetAll(config);
        }

        public void BL_Insert(Usuario usuario, EntAppConfig config)
        {
            _repository.Insert(usuario, config);
        }

        public List<Usuario> BL_Pagination(int pageNum, int pageSize, EntAppConfig config)
        {
            return _repository.Pagination(pageNum, pageSize, config);
        }
    }
}
