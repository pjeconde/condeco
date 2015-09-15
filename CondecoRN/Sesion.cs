using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoRN
{
    public class Sesion
    {
        public static void Cerrar(CondecoEntidades.Sesion Sesion)
        {
            Sesion.Usuario = new CondecoEntidades.Usuario();
            Sesion.OpcionesHabilitadas = OpcionesHabilitadas(Sesion);
        }
        public static List<string> OpcionesHabilitadas(CondecoEntidades.Sesion Sesion)
        {
            List<string> opcionesHabilitadas = new List<string>();
            if (Sesion.Usuario.Id != null)
            {
                opcionesHabilitadas.Add("UsuarioCambiarClave");
                opcionesHabilitadas.Add("UsuarioConsulta");
                opcionesHabilitadas.Add("UsuarioCerrar");
                List<CondecoEntidades.Permiso> permisoOperNovedadesActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "OperNovedades" && p.Estado == "Vigente";
                });
                if (permisoOperNovedadesActive.Count != 0)
                {
                    opcionesHabilitadas.Add("NovedadesCrear");
                    opcionesHabilitadas.Add("NovedadesModificar");
                    opcionesHabilitadas.Add("NovedadesImagenes");
                    opcionesHabilitadas.Add("NovedadesConsultar");
                }
                List<CondecoEntidades.Permiso> permisoOperPromocionesActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "OperPromociones" && p.Estado == "Vigente";
                });
                if (permisoOperPromocionesActive.Count != 0)
                {
                    opcionesHabilitadas.Add("PromocionesCrear");
                    opcionesHabilitadas.Add("PromocionesModificar");
                    opcionesHabilitadas.Add("PromocionesImagenes");
                    opcionesHabilitadas.Add("PromocionesConsultar");
                }
                List<CondecoEntidades.Permiso> permisoAdminSITEActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Vigente";
                });
                if (permisoAdminSITEActive.Count != 0)
                {
                    opcionesHabilitadas.Add("Administración Site|Productos");
                    List<CondecoEntidades.Permiso> permisoOperProductosActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "OperProductos" && p.Estado == "Vigente";
                    });
                    if (permisoOperProductosActive.Count != 0)
                    {
                        opcionesHabilitadas.Add("ProductosCrear");
                        opcionesHabilitadas.Add("ProductosModificar");
                        opcionesHabilitadas.Add("ProductosImagenes");
                        opcionesHabilitadas.Add("ProductosConsultar");
                    }
                    opcionesHabilitadas.Add("Administración Site|Explorador de Usuarios");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Permisos");
                    //opcionesHabilitadas.Add("Administración Site|Explorador de Publicidad");
                    //opcionesHabilitadas.Add("Administración Site|Explorador de Comentarios");
                    //opcionesHabilitadas.Add("Administración Site|Explorador de Configuraciones");
                    //opcionesHabilitadas.Add("Administración Site|Explorador de Logs");
                }
            }
            else
            {
                opcionesHabilitadas.Add("UsuarioLogin");
            }
            opcionesHabilitadas.Add("Portada");
            opcionesHabilitadas.Add("Empresa");
            opcionesHabilitadas.Add("Productos");
            opcionesHabilitadas.Add("Contacto");
            opcionesHabilitadas.Add("Acerca");
            return opcionesHabilitadas;
        }
        public static void AsignarUsuario(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            Sesion.Usuario = Usuario;
        }
        public static void RefrescarDatosUsuario(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            Sesion.Usuario.Permisos = CondecoRN.Permiso.LeerListaPermisosPorUsuario(Sesion.Usuario, Sesion);
            Sesion.OpcionesHabilitadas = OpcionesHabilitadas(Sesion);
        }
    }
}