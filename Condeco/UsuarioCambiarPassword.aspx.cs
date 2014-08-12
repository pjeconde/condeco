using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class UsuarioCambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            PasswordNuevaTextBox.Attributes.Add("value", PasswordNuevaTextBox.Text);
            ConfirmacionPasswordNuevaTextBox.Attributes.Add("value", ConfirmacionPasswordNuevaTextBox.Text);
            if (!IsPostBack)
            {
                PasswordTextBox.Focus();
            }
        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    CondecoRN.Usuario.CambiarPassword(sesion.Usuario, PasswordTextBox.Text, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (CondecoEntidades.Sesion)Session["Sesion"]);
                    CondecoRN.Sesion.Cerrar(sesion);
                    PasswordTextBox.Enabled = false;
                    PasswordNuevaTextBox.Enabled = false;
                    ConfirmacionPasswordNuevaTextBox.Enabled = false;
                    AceptarButton.Visible = false;
                    CancelarButton.Visible = false;
                    CondecoRN.Sesion.Cerrar(sesion);
                    Funciones.PersonalizarControlesMaster(Master, false, sesion);
                    MensajeLabel.Text = "The password was changed successfully. <br /> To continue, click on 'Login'.";
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (CondecoEX.Usuario.PasswordNoMatch)
            {
                MensajeLabel.Text = "Current password incorrect";
            }
            catch (CondecoEX.Usuario.PasswordYConfirmacionNoCoincidente)
            {
                MensajeLabel.Text = "The new password does not match with your confirmation";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
            }
        }

    }
}