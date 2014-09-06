using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace CondecoRN
{
    public class Producto
    {

        public static void Leer(CondecoEntidades.Producto Producto, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            db.Leer(Producto);
        }
        public static void Crear(out int IdProducto, CondecoEntidades.Producto Producto, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            Producto.WF.Estado = "Vigente";
            IdProducto = db.Crear(Producto);
        }
        public static void Modificar(CondecoEntidades.Producto ProductoActual, CondecoEntidades.Producto Producto, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            db.Modificar(ProductoActual, Producto);
        }
        public static void CambiarEstado(CondecoEntidades.Producto Producto, string Evento, string Estado, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            db.CambiarEstado(Producto, Evento, Estado);
            Producto.WF.Estado = Estado;
        }
        public static CondecoEntidades.Producto ObtenerCopia(CondecoEntidades.Producto Desde)
        {
            CondecoEntidades.Producto hasta = new CondecoEntidades.Producto();
            hasta.Id = Desde.Id;
            hasta.Nombre = Desde.Nombre;
            hasta.Descripcion = Desde.Descripcion;
            hasta.PrecioBase = Desde.PrecioBase;
            hasta.UltActualiz = Desde.UltActualiz;
            hasta.WF.Id = Desde.WF.Id;
            hasta.WF.Estado = hasta.WF.Estado;
            hasta.TipoProducto = Desde.TipoProducto;
            hasta.Ranking = Desde.Ranking;
            hasta.TipoDestacado = Desde.TipoDestacado;
            hasta.UltActualiz = Desde.UltActualiz;
            return hasta;
        }
        public static List<CondecoEntidades.Producto> ListaPorIdProducto(int IdProducto, bool SoloPropias, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            return db.ListaPorIdProducto(IdProducto, SoloPropias);
        }
        public static List<CondecoEntidades.Producto> ListaPorNombre(string Nombre, bool SoloPropias, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            return db.ListaPorNombre(Nombre, SoloPropias);
        }
        
        public static List<CondecoEntidades.Producto> Lista(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, string Nombre, string Descripcion, string SessionID, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Producto> listaProducto = new List<CondecoEntidades.Producto>();
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "Ranking desc, IdProducto desc";
            }
            listaProducto = db.ListaCompleta(OrderBy, Nombre, Descripcion);
            int cantidadFilas = listaProducto.Count;
            CantidadFilas = cantidadFilas;
            return db.Lista(IndicePagina, TamañoPagina, OrderBy, SessionID, listaProducto);
        }
        public static List<CondecoEntidades.Producto> ListaCompleta(out int CantidadFilas, string OrderBy, string Nombre, string Descripcion, string SessionID, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Producto> listaProducto = new List<CondecoEntidades.Producto>();
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "Ranking desc, IdProducto desc";
            }
            listaProducto = db.ListaCompleta(OrderBy, Nombre, Descripcion);
            int cantidadFilas = listaProducto.Count;
            CantidadFilas = cantidadFilas;
            return listaProducto;
        }
        public static bool ComprobarNombreProducto(string Nombre, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Producto db = new CondecoDB.Producto(Sesion);
            bool resp = db.ComprobarNombreProducto(Nombre);
            return resp;
        }
        public static void EventoPosible(out CondecoEntidades.Evento Evento, CondecoEntidades.Producto Producto, CondecoEntidades.Sesion Sesion)
        {
            //Verificar si el usuario es administrador
            Evento = new CondecoEntidades.Evento();
            List<CondecoEntidades.Permiso> permisoAdminSITEActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Vigente";
            });
            if (permisoAdminSITEActive.Count == 0)
            {
                if (Producto.Estado == "CanceledAdmin")
                {
                    Evento.Id = "";
                    Evento.DescrEvento = "In this state there is no event available. Only the Site Manager can intervene.";
                    Evento.Accion = "";
                    Evento.EstadoHst = "";

                }
                else if (Producto.Estado == "Active")
                {
                    Evento.Id = "Cancel";
                    Evento.DescrEvento = "Cancel";
                    Evento.Accion = "Cancel";
                    Evento.EstadoHst = "Canceled";
                }
                else if (Producto.Estado == "Canceled")
                {
                    Evento.Id = "Undo Cancel";
                    Evento.DescrEvento = "Undo Cancel";
                    Evento.Accion = "Undo Cancel";
                    Evento.EstadoHst = "Active";
                }
            }
            else
            {
                if (Producto.Estado == "CanceledAdmin")
                {
                    Evento.Id = "Undo Cancel (Admin)";
                    Evento.DescrEvento = "Undo Cancel (Admin)";
                    Evento.Accion = "Undo Cancel (Admin)";
                    Evento.EstadoHst = "Active";
                }
                else if (Producto.Estado == "Active")
                {
                    Evento.Id = "Cancel (Admin)";
                    Evento.DescrEvento = "Cancel (Admin)";
                    Evento.Accion = "Cancel (Admin)";
                    Evento.EstadoHst = "CanceledAdmin";
                }
                else if (Producto.Estado == "Canceled")
                {
                    Evento.Id = "Cancel (Admin)";
                    Evento.DescrEvento = "Cancel (Admin)";
                    Evento.Accion = "Cancel (Admin)";
                    Evento.EstadoHst = "CanceledAdmin";
                }
            }
        }
    }
}
