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
    public  class MenuRepository: IMenuRepository
    {
        private Menu MapToValue(SqlDataReader reader) //Mapeo de la tabla
        {
            return new Menu()
            {
                MenuID = (int)reader["MenuID"],
                Name = reader["Name"].ToString(),
                Details = reader["Details"].ToString(),
                Component = reader["Component"].ToString(),
                Url = reader["Url"].ToString(),
                Icon = reader["Icon"].ToString(),
                FatherMenu = (int)reader["FatherMenu"],
                IsVisible = (bool)reader["isVisible"],
                MenuStatus = (bool)reader["MenuStatus"],
                CreatedBy = (int)reader["CreatedBy"],
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString()),
                UpdatedBy = (int)reader["UpdatedBy"],
                UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
            };
        }



        public List<Menu> GetAllMenu(EntAppConfig config)
        {

            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllValuesMenu", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Menu>();
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



        public List<Menu> PaginationMenu(int pageNum, int pageSize, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("PaginationMenu", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pagenum", pageNum));
                    cmd.Parameters.Add(new SqlParameter("@pagesize", pageSize));
                    var response = new List<Menu>();
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

        public void InsertMenu(Menu menu, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertValueMenu", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", menu.Name));
                    cmd.Parameters.Add(new SqlParameter("@Details", menu.Details));
                    cmd.Parameters.Add(new SqlParameter("@Component", menu.Component));
                    cmd.Parameters.Add(new SqlParameter("@Url", menu.Url));
                    cmd.Parameters.Add(new SqlParameter("@Icon", menu.Icon));
                    cmd.Parameters.Add(new SqlParameter("@FatherManu", menu.FatherMenu));
                    cmd.Parameters.Add(new SqlParameter("@isVisible", menu.IsVisible));
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", menu.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@UpdatedBy", menu.UpdatedBy));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    return;
                }
            }
        }

        public void EditMenu(Menu menu, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EditMenu", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MenuId", menu.MenuID));
                    cmd.Parameters.Add(new SqlParameter("@Name", menu.Name));
                    cmd.Parameters.Add(new SqlParameter("@Details", menu.Details));
                    cmd.Parameters.Add(new SqlParameter("@Component", menu.Component));
                    cmd.Parameters.Add(new SqlParameter("@Url", menu.Url));
                    cmd.Parameters.Add(new SqlParameter("@Icon", menu.Icon));
                    cmd.Parameters.Add(new SqlParameter("@FatherMenu", menu.FatherMenu));
                    cmd.Parameters.Add(new SqlParameter("@isVisible", menu.IsVisible));
                    cmd.Parameters.Add(new SqlParameter("@MenuStatus", menu.MenuStatus));
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", menu.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@UpdatedBy", menu.UpdatedBy));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    return;
                }
            }
        }

        public void DisableMenu(int id, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DisableMenu", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MenuID", id));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    return;
                }
            }
        }

        public void DeleteByIdMenu(int Id, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteValueMenu", sql))
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
