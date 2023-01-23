using Domian.Interfaces;
using Domian.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private Product MapToValue(SqlDataReader reader) //Mapeo de la tabla
        {
            return new Product()
            {
                product_id = (int)reader["product_id"],
                description = reader["description"].ToString(),
                price = (decimal)reader["price"],
                created_by = (int)reader["created_by"],
                created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                updated_by = (int)reader["updated_by"],
                updated_date = Convert.ToDateTime(reader["updated_date"].ToString())
            };
        }


        public List<Product> GetAllProduct(EntAppConfig config)
        {

            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllValuesProduct", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Product>();
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

        public List<Product> PaginationProduct(int pageNum, int pageSize, EntAppConfig config)
        {
            using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
            {
                using (SqlCommand cmd = new SqlCommand("PaginationProduct", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pagenum", pageNum));
                    cmd.Parameters.Add(new SqlParameter("@pagesize", pageSize));
                    var response = new List<Product>();
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

        public Product SearchProduct(Product product, EntAppConfig config)
        {
            Product response = new Product();
            try
            {
                using (SqlConnection sql = new SqlConnection(config.SqlServerConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SearchProduct", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@description", product.description));
                        cmd.Parameters.Add(new SqlParameter("@price", product.price));
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
                        if (response.description == product.description && response.price == product.price)
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
                response.description = ex.Message;
                return response;

            }
        }



    }
}
