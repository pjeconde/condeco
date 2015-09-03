using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    
    [Serializable]
    public class Evento
    {
        private string id;
        private string descrEvento;
        private string estadoHst;
        private string accion = "";

        public Evento()
        {
            id = "";
            descrEvento = "";
            estadoHst = "";
            accion = "";
        }

        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string DescrEvento
        {
            set
            {
                descrEvento = value;
            }
            get
            {
                return descrEvento;
            }
        }
        public string EstadoHst
        {
            set
            {
                estadoHst = value;
            }
            get
            {
                return estadoHst;
            }
        }
        public string Accion
        {
            set
            {
                accion = value;
            }
            get
            {
                return accion;
            }
        }
    }
}
