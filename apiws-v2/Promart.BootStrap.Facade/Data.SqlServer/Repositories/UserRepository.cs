using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domian.Models;
using Domian.Interfaces;

namespace Data.SqlServer.Repositories
{
    public  class UserRepository: IUserRepository
    {
        private Usuario MapToValue(SqlDataReader reader) //Mapeo de la tabla
        {
            return new Usuario()
            {
                user_id = (int)reader["user_id"],
                company_id = (int)reader["company_id"],
                person_id = (int)reader["person_id"],
                usuario = reader["usuario"].ToString(),
                password = reader["password"].ToString(),
                search = reader["search"].ToString(),
                created_by = (int)reader["created_by"],
                created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                updated_by = (int)reader["updated_by"],
                updated_date = Convert.ToDateTime(reader["updated_date"].ToString()),
                user_status = (int)reader["user_status"]
            };
        }



        public List<Usuario> GetAll(EntAppConfig config)
        {

            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllValues", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Usuario>();
                    sql.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        response.Add(MapToValue(reader));
                    }

                    return response;
                }
            }
        }

        public List<Usuario> Pagination(int pageNum, int pageSize, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("PaginationUsuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pagenum", pageNum));
                    cmd.Parameters.Add(new SqlParameter("@pagesize", pageSize));
                    var response = new List<Usuario>();
                    sql.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public Usuario SearchUsuario(Usuario usuario, EntAppConfig config)
        {
            Usuario response = new Usuario();
            try
            {
                using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SearchUser", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@usuario", usuario.usuario));
                        cmd.Parameters.Add(new SqlParameter("@password", usuario.password));
                        sql.Open();
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response = MapToValue(reader);
                            }
                        }
                        sql.Close();
                        if (response.usuario == usuario.usuario && response.password == usuario.password)
                        {
                            return response;
                        }
                        else
                        {
                            return null;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.password = ex.Message;
                return response;

            }
        }

        public void Insert(Usuario usuario, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertValue", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@company_id", usuario.company_id));
                    cmd.Parameters.Add(new SqlParameter("@person_id", usuario.person_id));
                    cmd.Parameters.Add(new SqlParameter("@usuario", usuario.usuario));
                    cmd.Parameters.Add(new SqlParameter("@password", usuario.password));
                    cmd.Parameters.Add(new SqlParameter("@search", usuario.search));
                    cmd.Parameters.Add(new SqlParameter("@created_by", usuario.created_by));
                    cmd.Parameters.Add(new SqlParameter("@updated_by", usuario.updated_by));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    return;
                }
            }
        }
        public void EditUser(Usuario usuario, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EditUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@user_id", usuario.user_id));
                    cmd.Parameters.Add(new SqlParameter("@company_id", usuario.company_id));
                    cmd.Parameters.Add(new SqlParameter("@person_id", usuario.person_id));
                    cmd.Parameters.Add(new SqlParameter("@usuario", usuario.usuario));
                    cmd.Parameters.Add(new SqlParameter("@password", usuario.password));
                    cmd.Parameters.Add(new SqlParameter("@search", usuario.search));
                    cmd.Parameters.Add(new SqlParameter("@created_by", usuario.created_by));
                    cmd.Parameters.Add(new SqlParameter("@updated_by", usuario.updated_by));
                    cmd.Parameters.Add(new SqlParameter("@user_status", usuario.user_status));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    return;
                }
            }
        }
        public void DisableUser(int id, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DisableUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@user_id", id));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    return;
                }
            }
        }
        public void DeleteById(int Id, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteValue", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    return;
                }
            }
        }
    }
}
