using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacionesweb.Capa_Logica;
using Votacionesweb.CapaDatos;

namespace Votacionesweb.CapaVistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClassLogin login = new ClassLogin();
            Votantes votante = login.ValidarLogin(txtEmail.Text, txtPasword.Text);

            if (votante != null)
            {
                Session["IDVotante"] = votante.IDVotante;
                Session["NombreVotante"] = votante.NombreVotante;
                Response.Redirect("~/CapaVistas/Inicio.aspx");
            }
            else
            {
                alertLabel.Text = "Credenciales incorrectas. Inténtalo de nuevo.";
                alertLabel.Visible = true;
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            /*PersonaLogica personalogica = new PersonaLogica();
            int resultado = personalogica.CrearPersona()


            if (resultado > 0)
            {
                alertas("Usuario añadido con exito");
            }
            else
            {
                alertas("Usuario añadido con exito");
            }*/
        }
    }
}