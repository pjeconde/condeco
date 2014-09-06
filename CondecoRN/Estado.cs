using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoRN
{
    public class Estado
    {
        public static List<CondecoEntidades.Estado> ListaParaUsuario(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Vigente", "Vigente"));
            //lista.Add(new CondecoEntidades.Estado("PteAutoriz", "Pendiente de autorización"));
            lista.Add(new CondecoEntidades.Estado("PteConf", "Pendiente de confirmación"));
            lista.Add(new CondecoEntidades.Estado("Canceledo", "Canceledo"));
            //lista.Add(new CondecoEntidades.Estado("Rech", "Rechazado"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado(String.Empty, "Todos"));
            return lista;
        }
        public static List<CondecoEntidades.Estado> ListaParaPermiso(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Vigente", "Vigente"));
            lista.Add(new CondecoEntidades.Estado("Canceledo", "Canceledo"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado(String.Empty, "Todos"));
            return lista;
        }
        public static List<CondecoEntidades.Estado> ListaParaProducto(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Vigente", "Vigente"));
            lista.Add(new CondecoEntidades.Estado("Canceledo", "Canceledo"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado(String.Empty, "Todos"));
            return lista;
        }
    }
}
