using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Votacionesweb.Capa_Logica;
using Votacionesweb.CapaDatos;

namespace Votacionesweb.CapaVistas
{
    public partial class Votar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCandidatos();
            }
        }
        private void CargarCandidatos()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT c.IDCandidato, 
                                        c.NombreCandidato + ' ' + c.ApellidoCandidato + ' - ' + p.NombrePartido AS NombreCompleto
                                 FROM Candidatos c
                                 INNER JOIN Partidos p ON c.IDPartido = p.IDPartido";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                ddlCandidatos.DataSource = reader;
                ddlCandidatos.DataTextField = "NombreCompleto";
                ddlCandidatos.DataValueField = "IDCandidato";
                ddlCandidatos.DataBind();
            }
        }
        protected void btnVotar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCandidato = int.Parse(ddlCandidatos.SelectedValue);
                int idVotante = ObtenerIDVotante();

                ClassVotosLogica votoslogica = new ClassVotosLogica();
                votoslogica.RegistrarVoto(idCandidato, idVotante);
                Response.Redirect("resultados.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private int ObtenerIDVotante()
        {      
            if (Session["IDVotante"] != null)
            {
                return (int)Session["IDVotante"];
            }
            else
            {
                throw new InvalidOperationException("No hay un votante en la sesión.");
            }
        }
    }
}
