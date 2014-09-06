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
                //opcionesHabilitadas.Add("Página principal|Página principal");
                //opcionesHabilitadas.Add("Contacto|Contacto");
                List<CondecoEntidades.Permiso> permisoOperNovedadesActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "OperNovedades" && p.Estado == "Active";
                });
                if (permisoOperNovedadesActive.Count != 0)
                {
                    opcionesHabilitadas.Add("Novedades|New");
                    opcionesHabilitadas.Add("Novedades|Change Status");
                    opcionesHabilitadas.Add("Novedades|Modify");
                    opcionesHabilitadas.Add("Novedades|Images");
                    opcionesHabilitadas.Add("Novedades|List");
                }
                List<CondecoEntidades.Permiso> permisoOperPromocionesActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "OperPromociones" && p.Estado == "Active";
                });
                if (permisoOperPromocionesActive.Count != 0)
                {
                    opcionesHabilitadas.Add("Promociones|New");
                    opcionesHabilitadas.Add("Promociones|Change Status");
                    opcionesHabilitadas.Add("Promociones|Modify");
                    opcionesHabilitadas.Add("Promociones|Images");
                    opcionesHabilitadas.Add("Promociones|List");
                }
                List<CondecoEntidades.Permiso> permisoAdminSITEActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Active";
                });
                if (permisoAdminSITEActive.Count != 0)
                {
                    opcionesHabilitadas.Add("Administración Site|Explorador de Usuarios");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Permisos");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Publicidad");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Comentarios");
                    //opcionesHabilitadas.Add("Administración Site|Explorador de Configuraciones");
                    //opcionesHabilitadas.Add("Administración Site|Explorador de Logs");
                }
            }
            else
            {
                opcionesHabilitadas.Add("Portada");
                opcionesHabilitadas.Add("Empresa");
                opcionesHabilitadas.Add("Productos");
                opcionesHabilitadas.Add("Contacto");
                opcionesHabilitadas.Add("Acerca");
                opcionesHabilitadas.Add("Login");
            }
            return opcionesHabilitadas;
        }
        public static void AsignarUsuario(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            Sesion.Usuario = Usuario;
        }
        public static void RefrescarDatosUsuario(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            //Sesion.Usuario.Permisos = CondecoRN.Permiso.LeerListaPermisosPorUsuario(Sesion.Usuario, Sesion);
            //Sesion.MilongasDelUsuario = CondecoRN.Milonga.LeerListaMilongasPorUsuario(Sesion);
            Sesion.OpcionesHabilitadas = OpcionesHabilitadas(Sesion);
        }
    }
}