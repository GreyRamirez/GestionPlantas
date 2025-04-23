using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GestionPlantas.CapaDatos;

namespace GestionPlantas.CapaLogica
{
    public class CategoriaLogica
    {
        // Insertar nueva categoría
        public static bool InsertarCategoria(Categorias categoria)
        {
            try
            {
                using (SqlConnection conn = Dbconexion.obtenerConexion())
                {
                    string query = "INSERT INTO CATEGORIA (CATEGORIA) VALUES (@Categoria)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Categoria", categoria.NombreCategoria);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar la categoría.", ex);
            }
        }

        // Modificar categoría existente
        public static bool ModificarCategoria(Categorias categoria)
        {
            try
            {
                using (SqlConnection conn = Dbconexion.obtenerConexion())
                {
                    string query = "UPDATE CATEGORIA SET CATEGORIA = @Categoria WHERE ID = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Categoria", categoria.NombreCategoria);
                    cmd.Parameters.AddWithValue("@Id", categoria.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al modificar la categoría.", ex);
            }
        }

        // Eliminar categoría
        public static bool EliminarCategoria(int id)
        {
            try
            {
                using (SqlConnection conn = Dbconexion.obtenerConexion())
                {
                    string query = "DELETE FROM CATEGORIA WHERE ID = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar la categoría.", ex);
            }
        }

        // Obtener todas las categorías
        public static List<Categorias> ObtenerCategorias()
        {
            List<Categorias> lista = new List<Categorias>();

            try
            {
                using (SqlConnection conn = Dbconexion.obtenerConexion())
                {
                    string query = "SELECT ID, CATEGORIA AS NombreCategoria FROM CATEGORIA";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categorias categoria = new Categorias
                            {
                                Id = reader.GetInt32(0),
                                NombreCategoria = reader.GetString(1)
                            };
                            lista.Add(categoria);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener las categorías.", ex);
            }

            return lista;
        }

        // Obtener cantidad de plantas por categoría
        public static List<dynamic> ObtenerCantidadPlantasPorCategoria()
        {
            List<dynamic> lista = new List<dynamic>();

            try
            {
                using (SqlConnection conn = Dbconexion.obtenerConexion())
                {
                    string query = "SELECT C.CATEGORIA, COUNT(P.ID) AS CantidadPlantas " +
                                   "FROM CATEGORIA C " +
                                   "LEFT JOIN PLANTA P ON C.ID = P.CATEGORIAID " +
                                   "GROUP BY C.CATEGORIA";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reporte = new
                            {
                                Categoria = reader.GetString(0),
                                CantidadPlantas = reader.GetInt32(1)
                            };
                            lista.Add(reporte);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el reporte de cantidad de plantas por categoría.", ex);
            }

            return lista;
        }
    }
}

