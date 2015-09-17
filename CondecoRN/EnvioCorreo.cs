using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;

namespace CondecoRN
{
    public class EnvioCorreo
    {
        public static void ConfirmacionAltaUsuario(CondecoEntidades.Usuario Usuario)
        {
            SmtpClient smtpClient = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"]);
            mail.To.Add(new MailAddress(Usuario.Email));
            mail.Subject = "Creación de una nueva cuenta";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a <b>" + Usuario.Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Gracias por crear su cuenta.<br />");
            a.Append("<br />");
            a.Append("Para confirmar el alta, haga clic en el enlace que aparece a continuación:<br />");
            a.Append("<br />");
            string link = System.Configuration.ConfigurationManager.AppSettings["Servidor"] + "/UsuarioConfirmacion.aspx?Id=" + Encryptor.Encrypt(Usuario.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            char c = (char)34;
            a.Append("<a class=" + c + "link" + c + " href=" + c + link + c + ">" + link + "</a><br />");
            a.Append("<br />");
            a.Append("Si no puede acceder a la página, copie la URL y péguela en una ventana nueva del navegador.<br />");
            a.Append("<br />");
            a.Append("Si ha recibido este correo electrónico y no ha solicitado la creación de una cuenta, es probable que otro usuario haya introducido su dirección por error al intentar llevar a cabo este proceso. Si no ha solicitado la creación de una cuenta, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad.<br />");
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("<b>ConDeco</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
            smtpClient.Send(mail);
        }
        public static void ReporteIdUsuarios(string Email, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Usuario db = new CondecoDB.Usuario(Sesion);
            List<CondecoEntidades.Usuario> cuentas = db.Lista(Email);
			SmtpClient smtpClient = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"]);
            mail.To.Add(new MailAddress(Email));
            mail.Subject = "Información";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a <b>" + cuentas[0].Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Cumplimos en informarle cuáles son las cuentas vinculadas a este correo electrónico:<br />");
            a.Append("<br />");
            for (int i = 0; i < cuentas.Count; i++)
            {
                a.Append("Cuenta '" + cuentas[i].Nombre + "' (Id.Usuario='" + cuentas[i].Id + "')<br />");
            }
            a.Append("<br />");
            a.Append("Si ha recibido este correo electrónico y no ha solicitado información sobre su(s) cuenta(s), es probable que otro usuario haya introducido su dirección por error. Si no ha solicitado esta información, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad.<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("<b>Condeco</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
            smtpClient.Send(mail);
        }
        public static void ContactoSite(CondecoEntidades.ContactoSite ContactoSite, string CuentaMailCedeira)
        {
            StringBuilder a;
            //Mail para Cedeira
            SmtpClient smtpClient2Cedeira = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
            MailMessage mail2Cedeira = new MailMessage();
            mail2Cedeira.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"]);
            mail2Cedeira.To.Add(new MailAddress(CuentaMailCedeira));
            mail2Cedeira.Subject = "Formulario electrónico (Contacto de www.condeco.com.ar)";
            mail2Cedeira.IsBodyHtml = true;
            a = new StringBuilder();
            a.Append("Nombre: " + ContactoSite.Nombre + "<br />");
            a.Append("Telefono: " + ContactoSite.Telefono + "<br />");
            a.Append("Email: " + ContactoSite.Email + "<br />");
            a.Append("Mensaje:<br />");
            a.Append("-------------------------------------------<br />");
            a.Append(ContactoSite.Mensaje + "<br />");
            a.Append("-------------------------------------------<br />");
            mail2Cedeira.Body = a.ToString();
            smtpClient2Cedeira.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
            smtpClient2Cedeira.Send(mail2Cedeira);

            //Mail para el Contacto
            SmtpClient smtpClient2Contacto = new SmtpClient("mail.condeco.com.ar");
            MailMessage mail2Contacto = new MailMessage();
            mail2Contacto.From = new MailAddress(CuentaMailCedeira);
            mail2Contacto.To.Add(new MailAddress(ContactoSite.Email));
            mail2Contacto.Subject = "Acuse de recibo de Formulario electrónico";
            mail2Contacto.IsBodyHtml = true;
            a = new StringBuilder();
            a.Append("Estimado/a <b>" + ContactoSite.Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Gracias por comunicarse con nosotros.<br />");
            if (ContactoSite.Motivo == "Consulta")
            {
                a.Append("Su consulta será respondida a la brevedad.<br />");
            }
            else
            {
                a.Append("Su consulta será respondida a la brevedad.<br />");
            }
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("<b>ConDeco</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail2Contacto.Body = a.ToString();
            smtpClient2Contacto.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
            smtpClient2Contacto.Send(mail2Contacto);
        }
    }
}