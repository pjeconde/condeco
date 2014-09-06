using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoRN
{
    public class Comentario
    {
        public Comentario()
        {

        }

        public static int Crear(CondecoEntidades.Comentario Comentario, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            return db.Crear(Comentario);
        }

        public static int Replicar(CondecoEntidades.Comentario Comentario, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            return db.Replicar(Comentario);
        }

        public static CondecoEntidades.Comentario Leer(int IdComentario, int IdReplica, CondecoEntidades.Sesion Sesion)
        {
            CondecoEntidades.Comentario comentario = new CondecoEntidades.Comentario();
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            comentario = db.Leer(IdComentario, IdReplica);
            return comentario;
        }

        public static void CambiarEstado(CondecoEntidades.Comentario Comentario, string Evento, string Estado, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            db.CambiarEstado(Comentario, Evento, Estado);
            Comentario.Estado = Estado;
        }

        public static List<CondecoEntidades.Comentario> Lista(string NombreEntidad, string IdEntidad, string IdUsuario, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Comentario> comentarios = new List<CondecoEntidades.Comentario>();
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            comentarios = db.Lista(NombreEntidad, IdEntidad, IdUsuario);
            return comentarios;
        }

        public static List<CondecoEntidades.Comentario> Lista(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, string NombreEntidad, string IdEntidad, string IdUsuario, string SessionID, CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Comentario> comentarios = new List<CondecoEntidades.Comentario>();
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            comentarios = db.Lista(NombreEntidad, IdEntidad, IdUsuario);
            int cantidadFilas = comentarios.Count;
            CantidadFilas = cantidadFilas;
            return db.Lista(IndicePagina, TamañoPagina, OrderBy, SessionID, comentarios);
        }

        public static bool ComprobarComentario(string NombreEntidad, int IdEntidad, string Contenido, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            bool resp = db.ComprobarComentario(NombreEntidad, IdEntidad, Contenido);
            return resp;
        }

        public static void GuardarComentarioEstadistica(string NombreEntidad, int IdEntidad, int IdComentario, int IdReplica, string Objeto, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Comentario db = new CondecoDB.Comentario(Sesion);
            db.GuardarComentarioEstadistica(NombreEntidad, IdEntidad, IdComentario, IdReplica, Objeto);
        }

        public static CondecoEntidades.Comentario ObtenerCopia(CondecoEntidades.Comentario Desde)
        {
            CondecoEntidades.Comentario hasta = new CondecoEntidades.Comentario();
            hasta.Id = Desde.Id;
            hasta.IdReplica = Desde.IdReplica;
            hasta.IdEntidad = Desde.IdEntidad;
            hasta.NombreEntidad = Desde.NombreEntidad;
            hasta.IdUsuario = Desde.NombreUsuario;
            hasta.NombreUsuario = Desde.IdUsuario;
            hasta.Contenido = Desde.Contenido;
            hasta.Fecha = Desde.Fecha;
            hasta.Url = Desde.Url;
            hasta.ManoOk = Desde.ManoOk;
            hasta.ManoNoOk = Desde.ManoNoOk;
            hasta.AbusoContenido = Desde.AbusoContenido;
            return hasta;
        }

        public static void EventoPosible(out CondecoEntidades.Evento Evento, CondecoEntidades.Comentario Comentario, CondecoEntidades.Sesion Sesion)
        {
            //Verificar si el usuario es administrador
            Evento = new CondecoEntidades.Evento();
            List<CondecoEntidades.Permiso> permisoAdminSITEActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Active";
            });
            if (permisoAdminSITEActive.Count != 0)
            {
                if (Comentario.Estado == "CanceledAdmin")
                {
                    Evento.Id = "Undo Cancel (Admin)";
                    Evento.DescrEvento = "Undo Cancel (Admin)";
                    Evento.Accion = "Undo Cancel (Admin)";
                    Evento.EstadoHst = "Active";
                }
                else if (Comentario.Estado == "Active")
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
