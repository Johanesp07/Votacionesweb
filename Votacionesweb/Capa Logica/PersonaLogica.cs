using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Votacionesweb.CapaDatos;

namespace Votacionesweb.Capa_Logica
{
    public class PersonaLogica
    {
        public int CrearPersona(Persona persona)
        {
            int result = 0;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarPersonas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", persona.Correo);
                    cmd.Parameters.AddWithValue("@Contrasena", persona.Correo);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error", ex);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
    }
}