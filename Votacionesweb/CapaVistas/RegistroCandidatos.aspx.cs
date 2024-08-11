using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacionesweb.Capa_Logica;
using System.Configuration;

namespace Votacionesweb.CapaVistas
{
    public partial class RegistroCandidatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarPartido();
            }

        }
        protected void LlenarPartido()
        {
            try
            {
                ClassCandidatosLogica candidatosLogica = new ClassCandidatosLogica();
                DataTable dtPartidos = candidatosLogica.ObtenerPartidos();

                ddlPartido.DataSource = dtPartidos;
                ddlPartido.DataTextField = "TipoYDescripcion";
                ddlPartido.DataValueField = "IDPartido";
                ddlPartido.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ClassCandidatosLogica candidatosLogica = new ClassCandidatosLogica();
            int resultado = candidatosLogica.AgregarCandidato(txtNombre.Text, txtApellido.Text, txtNumTelf.Text, txtPlataforma.Text, ddlPartido.SelectedValue);

            if (resultado > 0)
            {
                Alertas("Candidato agregado exitosamente.");
                LimpiarCampos();
            }
            else if (resultado == -2)
            {
                Alertas("Ya existe un candidato con el mismo ID de partido. Por favor, seleccione otro.");
            }
            else
            {
                Alertas("Ocurrió un error al agregar el candidato.");
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNumTelf.Text = string.Empty;
            txtPlataforma.Text = string.Empty;
            ddlPartido.SelectedValue = string.Empty;
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
    }
}