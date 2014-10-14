﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Condeco
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciarse la aplicación
            Application["Visitantes"] = 0;
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Código que se ejecuta cuando se cierra la aplicación

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Código que se ejecuta al producirse un error no controlado

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando se inicia una nueva sesión
            CondecoEntidades.Sesion s = new CondecoEntidades.Sesion();
            s.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"];
            s.OpcionesHabilitadas = CondecoRN.Sesion.OpcionesHabilitadas(s);
            s.TiposProducto = CondecoRN.TipoProducto.Lista(s);
            Session["Sesion"] = s;
            Application.Lock();
            Application["Visitantes"] = (int)Application["Visitantes"] + 1;
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando finaliza una sesión.
            // Nota: el evento Session_End se desencadena sólo cuando el modo sessionstate
            // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
            // o SQLServer, el evento no se genera.
            Application.Lock();
            Application["Visitantes"] = (int)Application["Visitantes"] - 1;
            Application.UnLock();
        }
    }
}
