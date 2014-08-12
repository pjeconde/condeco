using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioTextBox.Focus();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Menu menu = ((Menu)Master.FindControl("MenuCPH").FindControl("Menu"));
            Funciones.RemoverMenuItem(menu, "Login");
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
                CondecoEntidades.Usuario usuario = new CondecoEntidades.Usuario();
                usuario.Id = UsuarioTextBox.Text;
                usuario.Password = PasswordTextBox.Text;
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                CondecoRN.Usuario.Login(usuario, sesion);
                CondecoRN.Sesion.AsignarUsuario(usuario, sesion);
                Response.Redirect("~/Home.aspx");
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (CondecoEX.Validaciones.ElementoInexistente ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
            catch (CondecoEX.Usuario.LoginRechazadoXPasswordInvalida ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                PasswordTextBox.Focus();
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
        }
        protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
        protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
    }
}