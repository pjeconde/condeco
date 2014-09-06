using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
            }
        }
        protected void NuevaClaveCaptchaButton_Click(object sender, EventArgs e)
        {
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
        }
        protected void EnviarButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            CondecoEntidades.ContactoSite contacto = new CondecoEntidades.ContactoSite();
            contacto.Motivo = MotivoTextBox.Text;
            contacto.Nombre = NombreTextBox.Text;
            contacto.Telefono = TelefonoTextBox.Text;
            contacto.Email = EmailTextBox.Text;
            contacto.Mensaje = MensajeTextBox.Text;
            try
            {
                CondecoRN.ContactoSite.Validar(contacto, Session["captcha"].ToString(), CaptchaTextBox.Text);
                CondecoRN.ContactoSite.Registrar(contacto);
                EnviarButton.Visible = false;
                BorrarDatosButton.Visible = false;
                NuevaClaveCaptchaButton.Visible = false;
                CaptchaImage.Visible = false;
                ClaveLabel.Visible = false;
                CaptchaTextBox.Visible = false;
                CaseSensitiveLabel.Visible = false;
                MotivoTextBox.Enabled = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                MensajeTextBox.Enabled = false;
                MensajeLabel.Text = "Formulario enviado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
            }
        }
        protected void BorrarDatosButton_Click(object sender, EventArgs e)
        {
            NombreTextBox.Text = String.Empty;
            TelefonoTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            MensajeTextBox.Text = String.Empty;
            MensajeLabel.Text = String.Empty;
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
        }
    }
}