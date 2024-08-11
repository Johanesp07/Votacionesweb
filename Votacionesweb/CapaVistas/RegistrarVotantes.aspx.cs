using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacionesweb.Capa_Logica;

namespace Votacionesweb.CapaVistas
{
    public partial class RegistrarVotantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int resultado = ClassVotantesLogica.RegistrarVotante(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtPassword.Text);
            if (resultado > 0)
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtPassword.Text = string.Empty;
                Alertas("Se ha registrado su cuenta con éxito");
            }
            else
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtPassword.Text = string.Empty;
                Alertas("¡Error al regustrar!");
            }
        }
    }
}