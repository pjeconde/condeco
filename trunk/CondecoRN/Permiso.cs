using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoRN
{
    public class Permiso
    {
        public static List<CondecoEntidades.Permiso> LeerListaPermisosPorUsuario(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
            return db.LeerListaPermisosPorUsuario(Usuario);
        }
        public static List<CondecoEntidades.Permiso> LeerListaPermisosVigentesPorUsuario(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
            return db.LeerListaPermisosVigentesPorUsuario(Usuario);
        }
        public static List<CondecoEntidades.Permiso> LeerListaPermisosPteAutoriz(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
            return db.LeerListaPermisosPteAutoriz(Usuario);
        }
        public static List<CondecoEntidades.Permiso> LeerListaPermisosFiltrados(string IdUsuario, string IdTipoPermiso, string Estado, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
            return db.LeerListaPermisosFiltrados(IdUsuario, IdTipoPermiso, Estado);
        }
        
        public static void PermisoAdminSITE(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            CondecoEntidades.Permiso permiso = new CondecoEntidades.Permiso();
            permiso.Usuario = Sesion.Usuario;
            permiso.TipoPermiso.Id = "AdminSITE";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.WF.Estado = "Vigente";
            CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
            db.Alta(permiso);
        }
        //public static string PermisoOperadorSITE(CondecoEntidades.Sesion Sesion)
        //{
        //    CondecoEntidades.Permiso permiso = new CondecoEntidades.Permiso();
        //    permiso.Usuario = Sesion.Usuario;
        //    permiso.TipoPermiso.Id = "OperadorSITE";
        //    permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
        //    permiso.WF.Estado = "Vigente";
        //    CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
        //    return db.AltaHandler(permiso, false);
        //}
        public static void CambiarEstado(CondecoEntidades.Permiso Permiso, string IdEstado, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
            db.CambioEstado(Permiso, IdEstado);
        }
        public static void AgregarPermiso(CondecoEntidades.Permiso Permiso, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Permiso db = new CondecoDB.Permiso(Sesion);
            db.AgregarPermiso(Permiso);
        }
    }
}