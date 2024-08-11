using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using Votacionesweb.CapaDatos;

namespace Votacionesweb.Capa_Logica
{
    public class ClassLogin
    {
        public Votantes ValidarLogin(string userEmail, string userPassword)
        {
            Votantes votante = null;
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_Login", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Correo", userEmail));
                        cmd.Parameters.Add(new SqlParameter("@Contrasena", userPassword));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                votante = new Votantes
                                {
                                    IDVotante = rdr.GetInt32(rdr.GetOrdinal("IDVotante")),
                                    NombreVotante = rdr.GetString(rdr.GetOrdinal("NombreVotante")),
                                    ApellidoVotante = rdr.GetString(rdr.GetOrdinal("ApellidoVotante")),
                                    Correo = rdr.GetString(rdr.GetOrdinal("Correo")),
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error", ex);
                }
            }
            return votante;
        }
    }
}