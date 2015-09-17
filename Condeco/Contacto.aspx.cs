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
                Funciones.GenerarImagenCaptcha(Session, CaptchaImage);
                ((System.Web.UI.HtmlControls.HtmlInputText)ContactoCodigo).Value = "";
            }
            ContactoEmail.Attributes["type"] = "email";
        }
        protected void NuevaClaveCaptchaButton_Click(object sender, EventArgs e)
        {
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage);
            ((System.Web.UI.HtmlControls.HtmlInputText)ContactoCodigo).Value = "";
        }
        protected void EnviarButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            CondecoEntidades.ContactoSite contacto = new CondecoEntidades.ContactoSite();
            contacto.Nombre = ((System.Web.UI.HtmlControls.HtmlInputText)ContactoNombre).Value;
            contacto.Telefono = ((System.Web.UI.HtmlControls.HtmlInputText)ContactoTelefono).Value;
            contacto.Email = ((System.Web.UI.HtmlControls.HtmlInputText)ContactoEmail).Value;
            contacto.Motivo = ((System.Web.UI.HtmlControls.HtmlInputText)ContactoAsunto).Value;
            contacto.Mensaje = ((System.Web.UI.HtmlControls.HtmlTextArea)ContactoMensaje).Value;
            try
            {
                string cc = ((System.Web.UI.HtmlControls.HtmlInputText)ContactoCodigo).Value;
                CondecoRN.ContactoSite.Validar(contacto, Session["captcha"].ToString(), cc);
                CondecoRN.ContactoSite.Registrar(contacto);
                EnviarButton.Enabled = false;
                BorrarDatosButton.Enabled = false;
                NuevaClaveCaptchaButton.Enabled = false;
                ((System.Web.UI.HtmlControls.HtmlInputText)ContactoNombre).Disabled = true;
                ((System.Web.UI.HtmlControls.HtmlInputText)ContactoNombre).Disabled = true;
                ((System.Web.UI.HtmlControls.HtmlInputText)ContactoTelefono).Disabled = true;
                ((System.Web.UI.HtmlControls.HtmlInputText)ContactoEmail).Disabled = true;
                ((System.Web.UI.HtmlControls.HtmlInputText)ContactoAsunto).Disabled = true;
                ((System.Web.UI.HtmlControls.HtmlTextArea)ContactoMensaje).Disabled = true;
                MensajeLabel.Text = "Formulario enviado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
            }
        }
        protected void BorrarDatosButton_Click(object sender, EventArgs e)
        {
            ((System.Web.UI.HtmlControls.HtmlInputText)ContactoNombre).Value = "";
            ((System.Web.UI.HtmlControls.HtmlInputText)ContactoTelefono).Value = "";
            ((System.Web.UI.HtmlControls.HtmlInputText)ContactoEmail).Value = "";
            ((System.Web.UI.HtmlControls.HtmlInputText)ContactoAsunto).Value = "";
            ((System.Web.UI.HtmlControls.HtmlTextArea)ContactoMensaje).Value = "";
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage);
            ((System.Web.UI.HtmlControls.HtmlInputText)ContactoCodigo).Value = "";
        }
    }
}