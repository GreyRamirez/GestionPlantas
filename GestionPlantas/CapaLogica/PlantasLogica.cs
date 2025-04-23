using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GestionPlantas.CapaDatos;

namespace GestionPlantas.CapaLogica
{
    public class PlantaLogica
    {
        // Insertar nueva planta
        public static bool InsertarPlanta(Plantas planta)
        {
            try
            {
                using (SqlConnection conn = Dbconexion.obtenerConexion())
                {
                    string query = "INSERT INTO PLANTA (NOMBRE, CATEGORIAID) VALUES (@Nombre, @CategoriaId)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", planta.Nombre);
                    cmd.Parameters.AddWithValue("@CategoriaId", planta.CategoriaId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar la planta.", ex);
            }
        }

        // Obtener todas las plantas
        public static List<Plantas> ObtenerPlantas()
        {
            List<Plantas> lista = new List<Plantas>();

            try
            {
                using (SqlConnection conn = Dbconexion.obtenerConexion())
                {
                    string query = "SELECT ID, NOMBRE, CATEGORIAID FROM PLANTA";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Plantas planta = new Plantas
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                CategoriaId = reader.GetInt32(2)
                            };
                            lista.Add(planta);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener las plantas.", ex);
            }

            return lista;
        }
    }
}
