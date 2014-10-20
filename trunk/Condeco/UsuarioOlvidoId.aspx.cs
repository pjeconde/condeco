﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class UsuarioOlvidoId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmailTextBox.Focus();
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                CondecoRN.EnvioCorreo.ReporteIdUsuarios(EmailTextBox.Text, (CondecoEntidades.Sesion)Session["Sesion"]);
                EmailTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MensajeLabel.Text = "Se ha enviado, por correo electrónico, el NombreUsuario de su(s) cuenta(s).  La recepción del email puede demorar unos minutos.";
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
            }
        }
    }
}