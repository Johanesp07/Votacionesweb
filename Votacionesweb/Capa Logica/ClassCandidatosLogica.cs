using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Votacionesweb.Capa_Logica
{
    public class ClassCandidatosLogica
    {
        public int AgregarCandidato(string nombre, string apellido, string numtelf, string plataforma, string idpartido)
        {
            int retorno = 0;
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            try
            {
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Candidatos] WHERE IDPartido = @IDPartido", conexion);
                    checkCmd.Parameters.Add(new SqlParameter("@IDPartido", idpartido));
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        return -2;
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Candidatos] (NombreCandidato, ApellidoCandidato, NumeroTelefono, Plataforma, IDPartido)" +
                        " VALUES (@NombreCandidato, @ApellidoCandidato, @NumeroTelefono, @Plataforma, @IDPartido);", conexion)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombreCandidato", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoCandidato", apellido));
                    cmd.Parameters.Add(new SqlParameter("@NumeroTelefono", numtelf));
                    cmd.Parameters.Add(new SqlParameter("@Plataforma", plataforma));
                    cmd.Parameters.Add(new SqlParameter("@IDPartido", idpartido));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            return retorno;
        }
        public DataTable ObtenerPartidos()
        {
            DataTable dtModified = new DataTable();

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Select IDPartido, NombrePartido from Partidos", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            dtModified.Columns.Add("IDPartido");
                            dtModified.Columns.Add("TipoYDescripcion", typeof(string));
                            dtModified.Rows.Add("", "Seleccione un partido");

                            foreach (DataRow row in dt.Rows)
                            {
                                string idpartido = row["IDPartido"].ToString();
                                string nombre = row["NombrePartido"].ToString();
                                string tipoYDescripcion = $"ID: {idpartido} - Nombre: {nombre}";
                                dtModified.Rows.Add(idpartido, tipoYDescripcion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dtModified;
        }
    }
}