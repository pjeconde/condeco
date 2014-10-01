using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades.TiposDestacado
{
    public class TipoDestacado
    {
        private string id;
        private string descr;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descr
        {
            get { return descr; }
            set { descr = value; }
        }

        public static List<TipoDestacado> Lista()
        {
            List<TipoDestacado> lista = new List<TipoDestacado>();
            lista.Add(new Destacado1());
            lista.Add(new Destacado2());
            return lista;
        }

        public static List<TipoDestacado> ListaMasSinInformar()
        {
            List<TipoDestacado> lista = new List<TipoDestacado>();
            lista.Add(new DestacadoSinInformar());
            lista.Add(new Destacado1());
            lista.Add(new Destacado2());
            return lista;
        }
    }
}
