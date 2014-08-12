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
            lista.Add(new CondecoEntidades.Estado("Active", "Active"));
            //lista.Add(new CondecoEntidades.Estado("PteAutoriz", "Pendiente de autorización"));
            lista.Add(new CondecoEntidades.Estado("PteConf", "Pendiente de confirmación"));
            lista.Add(new CondecoEntidades.Estado("Canceled", "Canceled"));
            //lista.Add(new CondecoEntidades.Estado("Rech", "Rechazado"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado(String.Empty, "Todos"));
            return lista;
        }
        public static List<CondecoEntidades.Estado> ListaParaPermiso(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Active", "Active"));
            lista.Add(new CondecoEntidades.Estado("Canceled", "Canceled"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado(String.Empty, "Todos"));
            return lista;
        }
        public static List<CondecoEntidades.Estado> ListaParaMilonga(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Active", "Active"));
            lista.Add(new CondecoEntidades.Estado("Canceled", "Canceled"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado(String.Empty, "All"));
            return lista;
        }
        public static List<CondecoEntidades.Estado> ListaParaRental(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Active", "Active"));
            lista.Add(new CondecoEntidades.Estado("PendingConf", "Pending Confirmation"));
            lista.Add(new CondecoEntidades.Estado("Reserved", "Reserved"));
            lista.Add(new CondecoEntidades.Estado("Canceled", "Canceled"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado("All", "All"));
            return lista;
        }
        public static List<CondecoEntidades.Estado> ListaParaHousing(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Active", "Active"));
            lista.Add(new CondecoEntidades.Estado("PendingConf", "Pending Confirmation"));
            lista.Add(new CondecoEntidades.Estado("Reserved", "Reserved"));
            lista.Add(new CondecoEntidades.Estado("Canceled", "Canceled"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado("All", "All"));
            return lista;
        }
        public static List<CondecoEntidades.Estado> ListaParaAirTicket(bool IncluirOpcionTodos, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Estado> lista = new List<CondecoEntidades.Estado>();
            lista.Add(new CondecoEntidades.Estado("Active", "Active"));
            if (IncluirOpcionTodos) lista.Add(new CondecoEntidades.Estado("All", "All"));
            return lista;
        }
    }
}
