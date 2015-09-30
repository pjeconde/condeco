using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaDotNet2.Security.Cryptography;

namespace Condeco
{
    public partial class UsuarioModificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            if (!IsPostBack)
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                CondecoEntidades.Usuario usuario = new CondecoEntidades.Usuario();
                usuario = (CondecoEntidades.Usuario)Session["Usuario"];

                NombreTextBox.Focus();
                //No se pueden modificar estos datos.
                EmailTextBox.Enabled = false;
                IdUsuarioTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                PreguntaTextBox.Enabled = false;
                RespuestaTextBox.Enabled = false;

                IdUsuarioTextBox.Text = usuario.Id;
                NombreTextBox.Text = usuario.Nombre;
                PaisTextBox.Text = usuario.Pais;
                ProvinciaTextBox.Text = usuario.Provincia;
                LocalidadTextBox.Text = usuario.Localidad;
                TelefonoTextBox.Text = usuario.Telefono;
                EmailTextBox.Text = usuario.Email;
                FacebookTextBox.Text = usuario.Facebook;
                PreguntaTextBox.Text = usuario.Pregunta;
                RespuestaTextBox.Text = usuario.Respuesta;
                PasswordTextBox.Text = usuario.Password;

                PasswordTextBox.Visible = false;
                RespuestaTextBox.Visible = false;
                if (sesion.Usuario.Permisos != null)
                {
                    List<CondecoEntidades.Permiso> permisoAdminSITEActive = sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Vigente";
                    });
                    if (permisoAdminSITEActive.Count != 0)
                    {
                        PasswordTextBox.Visible = true;
                        RespuestaTextBox.Visible = true;
                    }
                }
                
                MedioDropDownList.DataSource = CondecoRN.Medio.Lista(sesion);
                DataBind();
                MedioDropDownList.SelectedValue = usuario.IdMedio;
                MedioDropDownList.DataBind();
            }
        }
        protected void ModificarCuentaButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            CondecoEntidades.Usuario usuario = new CondecoEntidades.Usuario();
            usuario.Nombre = NombreTextBox.Text;
            usuario.Telefono = TelefonoTextBox.Text;
            usuario.Pais = PaisTextBox.Text;
            usuario.Provincia = ProvinciaTextBox.Text;
            usuario.Localidad = LocalidadTextBox.Text;
            usuario.Facebook = 
            usuario.Telefono = TelefonoTextBox.Text;
            //usuario.Email = EmailTextBox.Text;
            //usuario.Id = IdUsuarioTextBox.Text;
            //usuario.Password = PasswordTextBox.Text;
            //usuario.Pregunta = PreguntaTextBox.Text;
            //usuario.Respuesta = RespuestaTextBox.Text;
            try
            {
                CondecoRN.Usuario.ValidarModificacion(usuario);
                //CondecoRN.Usuario.Registrar(usuario, true, (CondecoEntidades.Sesion)Session["Sesion"]);
                ModificarButton.Visible = false;
                CancelarButton.Visible = false;

                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                PaisTextBox.Enabled = false;
                ProvinciaTextBox.Enabled = false;
                LocalidadTextBox.Enabled = false;
                FacebookTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                MensajeLabel.Text = "Cuenta modificada satisfactoriamente. (Por el momento no registra la modificación.)";
            }
            catch (Exception ex)
            {
                string a = CondecoEX.Funciones.Detalle(ex);
                MensajeLabel.Text = a;
            }
        }
    }
}