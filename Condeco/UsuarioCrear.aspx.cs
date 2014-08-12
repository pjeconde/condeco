using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaDotNet2.Security.Cryptography;

namespace Condeco
{
    public partial class UsuarioCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            ConfirmacionPasswordTextBox.Attributes.Add("value", ConfirmacionPasswordTextBox.Text);
            if (!IsPostBack)
            {
                NombreTextBox.Focus();
                try
                {
                    Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
                    CondicionesTextBox.Text = CondecoRN.Usuario.TerminosYCondiciones().Replace("<br />", Environment.NewLine);
                }
                catch (Exception ex)
                {
                    CondecoWebForm.Excepciones.Redireccionar(ex, "~/NotificacionDeExcepcion.aspx");
                }
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                MedioDropDownList.DataSource = CondecoRN.Medio.Lista(sesion);
                DataBind();
            }
        }
        protected void CrearCuentaButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            ResultadoComprobarDisponibilidadLabel.Text = String.Empty;
            CondecoEntidades.Usuario usuario = new CondecoEntidades.Usuario();
            usuario.Nombre = NombreTextBox.Text;
            usuario.Telefono = TelefonoTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Id = IdUsuarioTextBox.Text;
            usuario.Password = PasswordTextBox.Text;
            usuario.Pregunta = PreguntaTextBox.Text;
            usuario.Respuesta = RespuestaTextBox.Text;
            try
            {
                CondecoRN.Usuario.Validar(usuario, ConfirmacionPasswordTextBox.Text, Session["captcha"].ToString(), CaptchaTextBox.Text, (CondecoEntidades.Sesion)Session["Sesion"]);
                CondecoRN.Usuario.Registrar(usuario, true, (CondecoEntidades.Sesion)Session["Sesion"]);
                ComprobarDisponibilidadButton.Visible = false;
                NuevaClaveCaptchaButton.Visible = false;
                CrearCuentaButton.Visible = false;
                CancelarButton.Visible = false;
                CrearCuentaLabel.Visible = false;
                CaptchaImage.Visible = false;
                ClaveLabel.Visible = false;
                CaptchaTextBox.Visible = false;
                CaseSensitiveLabel.Visible = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                IdUsuarioTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                ConfirmacionPasswordTextBox.Enabled = false;
                PreguntaTextBox.Enabled = false;
                RespuestaTextBox.Enabled = false;
                MensajeLabel.Text = "Thanks for creating your account. <br /> Follow the instructions, which were sent by email, to confirm the creation of your account. <br /> Receiving email may take a few minutes.";
            }
            catch (Exception ex)
            {
                string a = CondecoEX.Funciones.Detalle(ex);
                MensajeLabel.Text = a;
            }
        }
        protected void NuevaClaveCaptchaButton_Click(object sender, EventArgs e)
        {
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
        }
        protected void ComprobarDisponibilidadButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            CondecoEntidades.Usuario usuario = new CondecoEntidades.Usuario();
            usuario.Id = IdUsuarioTextBox.Text;
            try
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                bool disponible = CondecoRN.Usuario.IdCuentaDisponible(usuario, sesion);
                if (disponible)
                {
                    ResultadoComprobarDisponibilidadLabel.ForeColor = System.Drawing.Color.Green;
                    ResultadoComprobarDisponibilidadLabel.Text = "OK";
                }
                else
                {
                    ResultadoComprobarDisponibilidadLabel.ForeColor = System.Drawing.Color.Red;
                    ResultadoComprobarDisponibilidadLabel.Text = "Unavailable";
                }
            }
            catch (CondecoEX.Validaciones.ValorNoInfo)
            {
                ResultadoComprobarDisponibilidadLabel.ForeColor = MensajeLabel.ForeColor;
                ResultadoComprobarDisponibilidadLabel.Text = "User.Id not reported";
            }
            catch (Exception ex)
            {
                ResultadoComprobarDisponibilidadLabel.ForeColor = MensajeLabel.ForeColor;
                ResultadoComprobarDisponibilidadLabel.Text = "See details at bottom of page";
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
            }
        }
    }
}