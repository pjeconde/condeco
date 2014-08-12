using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CondecoRN
{
    public class EnvioSMS
    {
        public static void Enviar(string Asunto, string Mensaje, List<CondecoEntidades.Usuario> Destinatarios)
        {
            if (Destinatarios.Count > 0)
            {
                SmtpClient smtpClient = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"]);
                for (int i = 0; i < Destinatarios.Count; i++)
                {
                    mail.To.Add(new MailAddress(Destinatarios[i].EmailSMS));
                }
                mail.Subject = Asunto;
                mail.Body = Mensaje;
                smtpClient.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"], System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"]);
                smtpClient.Send(mail);
            }
        }
    }
}