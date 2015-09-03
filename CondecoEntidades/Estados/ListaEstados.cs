using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades.Estados
{
    public class ListaEstados
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

        public static List<ListaEstados> Lista()
        {
            List<ListaEstados> lista = new List<ListaEstados>();
            lista.Add(new Vigente());
            lista.Add(new Baja());
            return lista;
        }

        public static List<ListaEstados> ListaMasSinInformar()
        {
            List<ListaEstados> lista = new List<ListaEstados>();
            lista.Add(new EstadoSinInformar());
            lista.Add(new Vigente());
            lista.Add(new Baja());
            return lista;
        }
    }
}
