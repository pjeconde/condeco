using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class UsuarioConfirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string a = HttpContext.Current.Request.Url.Query.ToString();
                if (a == String.Empty)
                {
                    throw new CondecoEX.Usuario.UsuarioConfFormatoMsgErroneo();
                }
                else
                {
                    if (a.Substring(0, 4) == "?Id=")
                    {
                        a = a.Substring(4);
                    }
                    string idUsuario = a;
                    CondecoEntidades.Usuario usuario = new CondecoEntidades.Usuario();
                    usuario.Id = idUsuario;
                    CondecoRN.Usuario.Confirmar(usuario, true, true, (CondecoEntidades.Sesion)Session["Sesion"]);
                    MensajeLabel.Text = "Felicitaciones !!!.<br /><br />Su nueva cuenta '" + usuario.Id + "' ahora está disponible.<br />Para acceder hacer clic en 'Login'";
                }
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(new CondecoEX.Usuario.UsuarioConfFormatoMsgErroneo());
            }
            catch (System.FormatException)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(new CondecoEX.Usuario.UsuarioConfFormatoMsgErroneo());
            }
            catch (CondecoEX.Validaciones.ElementoInexistente)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(new CondecoEX.Usuario.UsuarioConfFormatoMsgErroneo());
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
            }
        }
    }
}