using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Votacionesweb.Capa_Logica
{
    public class ClassVotosLogica
    {
        public void RegistrarVoto(int idCandidato, int idVotante)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Votos (IDCandidato, IDVotante, FechaVoto) VALUES (@IDCandidato, @IDVotante, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDCandidato", idCandidato);
                    command.Parameters.AddWithValue("@IDVotante", idVotante);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}