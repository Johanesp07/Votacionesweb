using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Votacionesweb.Capa_Logica
{
    public static class ClassVotantesLogica
    {
        public static int RegistrarVotante(string nombre, string apellido, string correo, string contrasena)
        {
            int resultado = 0;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection Conn = new SqlConnection(connstring))

                try
                {
                    Conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarVotantes", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombreVotante", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoVotante", apellido));
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@contrasena", contrasena));
                    resultado = cmd.ExecuteNonQuery();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    resultado = -1;
                }
                finally
                {
                    Conn.Close();
                }
            return resultado;
        }
    }
}