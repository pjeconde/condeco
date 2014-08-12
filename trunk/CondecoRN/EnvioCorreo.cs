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
            mail.Subject = "You now have a new account";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Dear <b>" + Usuario.Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Thanks for creating your account.<br />");
            a.Append("<br />");
            a.Append("To confirm your registration, click the link below:<br />");
            a.Append("<br />");
            string link = System.Configuration.ConfigurationManager.AppSettings["Servidor"] + "/UsuarioConfirmacion.aspx?Id=" + Encryptor.Encrypt(Usuario.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            char c = (char)34;
            a.Append("<a class=" + c + "link" + c + " href=" + c + link + c + ">" + link + "</a><br />");
            a.Append("<br />");
            a.Append("If you can not access the page, copy the URL and paste it into a new browser window.<br />");
            a.Append("<br />");
            a.Append("If you have received this email and has not requested the creation of an account, it's likely that another user entered your email address by mistake while trying to perform this process. If you have not requested the creation of an account is not required to take any action and can ignore this message safely.<br />");
            a.Append("<br />");
            a.Append("Regards.<br />");
            a.Append("<br />");
            a.Append("<b>Tango Family and Guide</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("This is just a messaging service. Replies are not monitored or answered.<br />");
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
            mail.Subject = "Account information";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Dear <b>" + cuentas[0].Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("We comply to inform what accounts linked to this email:<br />");
            a.Append("<br />");
            for (int i = 0; i < cuentas.Count; i++)
            {
                a.Append("Name Account '" + cuentas[i].Nombre + "' (User.Id='" + cuentas[i].Id + "')<br />");
            }
            a.Append("<br />");
            a.Append("If you have received this email and did not request your account information, it is likely that another user entered your email address by mistake. If you have not requested this information is not required to take any action and can ignore this message safely.<br />");
            a.Append("Regards.<br />");
            a.Append("<br />");
            a.Append("<b>Tango Family and Guide</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("This is just a messaging service. Replies are not monitored or answered.<br />");
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
            mail2Cedeira.Subject = "Tango Family and Guide: Question asked (Contact Form)";
            mail2Cedeira.IsBodyHtml = true;
            a = new StringBuilder();
            a.Append("Los siguientes, son los datos del nuevo contacto<br />");
            a.Append("Motivo: " + ContactoSite.Motivo + "<br />");
            a.Append(":<br />");
            a.Append("<br />");
            a.Append("Nombre: " + ContactoSite.Nombre + "<br />");
            a.Append("Telefono: " + ContactoSite.Telefono + "<br />");
            a.Append("Email: " + ContactoSite.Email + "<br />");
            a.Append("Mensaje:<br />");
            a.Append("------------------------------------------------<br />");
            a.Append(ContactoSite.Mensaje + "<br />");
            a.Append("------------------------------------------------<br />");
            mail2Cedeira.Body = a.ToString();
            smtpClient2Cedeira.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
            smtpClient2Cedeira.Send(mail2Cedeira);

            //Mail para el Contacto
            SmtpClient smtpClient2Contacto = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
            MailMessage mail2Contacto = new MailMessage();
            mail2Contacto.From = new MailAddress(CuentaMailCedeira);
            mail2Contacto.To.Add(new MailAddress(ContactoSite.Email));
            mail2Contacto.Subject = "Tango Family and Guide: Question asked (Contact Form)";
            mail2Contacto.IsBodyHtml = true;
            a = new StringBuilder();
            a.Append("Dear <b>" + ContactoSite.Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Thank you for contacting us.<br />");
            a.Append("Your questions will be answered promptly.<br />");
            a.Append("Regards.<br />");
            a.Append("<br />");
            a.Append("<b>Tango Family and Guide</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("This is just a messaging service. Replies are not monitored or answered.<br />");
            mail2Contacto.Body = a.ToString();
            smtpClient2Contacto.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
            smtpClient2Contacto.Send(mail2Contacto);
        }
        //public static void AirTicket(CondecoEntidades.AirTicket AirTicket, string CuentaMailCedeira)
        //{
        //    StringBuilder a;
        //    //Mail para Cedeira
        //    SmtpClient smtpClient2Cedeira = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
        //    MailMessage mail2Cedeira = new MailMessage();
        //    mail2Cedeira.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"]);
        //    mail2Cedeira.To.Add(new MailAddress(CuentaMailCedeira));
        //    mail2Cedeira.Subject = "Tango Family and Guide: Question asked (Air Tickets Group Buying)";
        //    mail2Cedeira.IsBodyHtml = true;
        //    a = new StringBuilder();
        //    a.Append("Los siguientes, son los datos de la nueva solicitud<br />");
        //    a.Append("Source: " + AirTicket.PaisOrigen + " " + AirTicket.LocalidadOrigen + "<br />");
        //    a.Append("Destination: " + AirTicket.PaisDestino + " " + AirTicket.LocalidadDestino + "<br />");
        //    a.Append("Date: " + AirTicket.FechaAlta + "  to " + AirTicket.FechaHasta + "<br /><br />");
        //    if (AirTicket.IdaYVuelta == true)
        //    {
        //        a.Append("Ticket Round Trip (Ida y Vuelta).<br />");
        //    }
        //    else
        //    {
        //        a.Append("Ticket Only Way (solamente Ida).<br />");
        //    }
        //    a.Append("Adults: " + AirTicket.CantidadPersonasAdult + ".<br />");
        //    if (AirTicket.CantidadPersonasChild != 0)
        //    {
        //        a.Append("Childs: " + AirTicket.CantidadPersonasChild + ".<br />");
        //    }
        //    a.Append("Class: " + AirTicket.Clase + "<br /><br />");
        //    a.Append("Nombre: " + AirTicket.Nombre + "<br />");
        //    a.Append("Telefono: " + AirTicket.Telefono + "<br />");
        //    a.Append("Email: " + AirTicket.Email + "<br />");
        //    if (AirTicket.Descripcion != "")
        //    {
        //        a.Append("<br />");
        //        a.Append("Comments:<br />");
        //        a.Append("------------------------------------------------<br />");
        //        a.Append(AirTicket.Descripcion + "<br />");
        //        a.Append("------------------------------------------------<br />");
        //    }
        //    mail2Cedeira.Body = a.ToString();
        //    smtpClient2Cedeira.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
        //    smtpClient2Cedeira.Send(mail2Cedeira);

        //    //Mail para el Contacto
        //    SmtpClient smtpClient2Contacto = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
        //    MailMessage mail2Contacto = new MailMessage();
        //    mail2Contacto.From = new MailAddress(CuentaMailCedeira);
        //    mail2Contacto.To.Add(new MailAddress(AirTicket.Email));
        //    mail2Contacto.Subject = "Tango Family and Guide: Question asked (Air Tickets Group Buying)";
        //    mail2Contacto.IsBodyHtml = true;
        //    a = new StringBuilder();
        //    a.Append("Dear <b>" + AirTicket.Nombre.Trim() + "</b>:<br />");
        //    a.Append("<br />");
        //    a.Append("Thank you for contacting us.<br />");
        //    a.Append("Your questions will be answered promptly.<br />");
        //    a.Append("Regards.<br />");
        //    a.Append("<br />");
        //    a.Append("<b>Tango Family and Guide</b><br />");
        //    a.Append("<br />");
        //    a.Append("<br />");
        //    a.Append("This is just a messaging service. Replies are not monitored or answered.<br />");
        //    mail2Contacto.Body = a.ToString();
        //    smtpClient2Contacto.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
        //    smtpClient2Contacto.Send(mail2Contacto);
        //}
    }
}