using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CondecoDB
{
    public class Permiso : db
    {
        public Permiso(CondecoEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CondecoEntidades.Permiso> LeerListaPermisosPteAutoriz(CondecoEntidades.Usuario Usuario)
        {
            //StringBuilder a = new StringBuilder(string.Empty);
            //a.AppendLine("/* AUTORIZACIONES PARA ADMINCUITS */ ");
            //a.AppendLine("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso into #p from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso in ('UsoCUITxUN', 'AdminCUIT') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and Cuit in ");
            //a.AppendLine("(select Cuit from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminCUIT' and Estado='Active') ");
            //a.AppendLine("/* AUTORIZACIONES PARA ADMINUNS */ ");
            //a.AppendLine("insert #p select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso not in ('UsoCUITxUN', 'AdminCUIT', 'AdminSITE') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and Cuit + '-' + convert(varchar(10), IdUN) in ");
            //a.AppendLine("(select Cuit + '-' + convert(varchar(10), IdUN) from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminUN' and Estado='Active') and ");
            //a.AppendLine("IdUsuario <> '' ");
            //a.AppendLine("/* AUTORIZACIONES PARA ADMINSITES */ ");
            //a.AppendLine("insert #p select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso in ('AdminSITE') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and ");
            //a.AppendLine("IdUsuario <> '' and (select count(*) from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminSITE' and Estado='Active')=1 ");
            //a.AppendLine("/* RESULTADOS */ ");
            //a.AppendLine("select distinct #p.IdUsuario, #p.Cuit, #p.IdUN, #p.IdTipoPermiso, #p.FechaFinVigencia, #p.IdUsuarioSolicitante, #p.AccionTipo, #p.AccionNro, #p.IdWF, #p.Estado, #p.DescrTipoPermiso, isnull(u.Nombre, '') as NombreUsuario, isnull(u.Email, '') as EmailUsuario, isnull(us.Nombre, '') as NombreUsuarioSolicitante , isnull(us.Email, '') as EmailUsuarioSolicitante, isnull(UN.DescrUN, '') as DescrUN ");
            //a.AppendLine("from #p ");
            //a.AppendLine("left outer join Usuario u on #p.IdUsuario=u.IdUsuario ");
            //a.AppendLine("left outer join Usuario us on #p.IdUsuarioSolicitante=us.IdUsuario ");
            //a.AppendLine("left outer join UN on #p.IdUN=UN.IdUN and #p.Cuit=UN.Cuit ");
            //a.AppendLine("order by #p.DescrTipoPermiso, #p.Cuit, #p.IdUN, NombreUsuario ");
            //a.AppendLine("drop table #p ");
            //DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Permiso> lista = new List<CondecoEntidades.Permiso>();
            //if (dt.Rows.Count != 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        CondecoCondecoEntidades.Permiso permiso = new CondecoCondecoEntidades.Permiso();
            //        Copiar(dt.Rows[i], permiso);
            //        lista.Add(permiso);
            //    }
            //}
            return lista;
        }
        public List<CondecoEntidades.Permiso> LeerListaPermisosPorUsuario(CondecoEntidades.Usuario Usuario)
        {
            List<CondecoEntidades.Permiso> lista = new List<CondecoEntidades.Permiso>();
            if (Usuario.Id != null)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.AppendLine("select Permiso.IdUsuario, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso ");
                a.AppendLine("from Permiso ");
                a.AppendLine("join TipoPermiso on Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso ");
                a.AppendLine("where IdUsuario='" + Usuario.Id + "' ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CondecoEntidades.Permiso permiso = new CondecoEntidades.Permiso();
                        Copiar(dt.Rows[i], permiso);
                        lista.Add(permiso);
                    }
                }
            }
            return lista;
        }
        public List<CondecoEntidades.Permiso> LeerListaPermisosActivesPorUsuario(CondecoEntidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Permiso.IdUsuario, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso ");
            a.AppendLine("from Permiso, TipoPermiso ");
            a.AppendLine("where IdUsuario='" + Usuario.Id + "' and Estado='Active' and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Permiso> lista = new List<CondecoEntidades.Permiso>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Permiso permiso = new CondecoEntidades.Permiso();
                    Copiar(dt.Rows[i], permiso);
                    lista.Add(permiso);
                }
            }
            return lista;
        }
        public List<CondecoEntidades.Permiso> LeerListaPermisosFiltrados(string IdUsuario, string IdTipoPermiso, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Permiso.IdUsuario, Usuario.Nombre, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdWF, Permiso.Estado ");
            a.AppendLine("from Permiso, Usuario where 1=1 and Permiso.IdUsuario=Usuario.IdUsuario ");
            if (IdUsuario != String.Empty) a.AppendLine("and Permiso.IdUsuario='" + IdUsuario + "' ");
            if (IdTipoPermiso != String.Empty) a.AppendLine("and Permiso.IdTipoPermiso='" + IdTipoPermiso + "' ");
            if (Estado != String.Empty) a.AppendLine("and Permiso.Estado='" + Estado + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Permiso> lista = new List<CondecoEntidades.Permiso>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Permiso permiso = new CondecoEntidades.Permiso();
                    Copiar(dt.Rows[i], permiso);
                    lista.Add(permiso);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CondecoEntidades.Permiso Hasta)
        {
            Hasta.Usuario.Id = Convert.ToString(Desde["IdUsuario"]);
            try
            {
            Hasta.Usuario.Nombre = Convert.ToString(Desde["Nombre"]);
            }
            catch { }
            Hasta.TipoPermiso.Id = Convert.ToString(Desde["IdTipoPermiso"]);
            try
            {
            Hasta.TipoPermiso.Descr = Convert.ToString(Desde["DescrTipoPermiso"]);
            }
            catch { }
            Hasta.FechaFinVigencia = Convert.ToDateTime(Desde["FechaFinVigencia"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            try
            {
                Hasta.Usuario.Nombre = Convert.ToString(Desde["NombreUsuario"]);
                Hasta.Usuario.Email = Convert.ToString(Desde["EmailUsuario"]);
            }
            catch { }
        }
        public void Alta(CondecoEntidades.Permiso Permiso)
        {
            Ejecutar(AltaHandler(Permiso, true), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public string AltaHandler(CondecoEntidades.Permiso Permiso, bool DeclaroIdWF)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            if (DeclaroIdWF)
            {
                a.AppendLine("declare @idWF varchar(256) ");
            }
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            if (Permiso.Usuario.Id != null)
            {
                a.AppendLine("insert Permiso values ('" + Permiso.Usuario.Id + "', '" + Permiso.TipoPermiso.Id + "', '" + Permiso.FechaFinVigencia.ToString("yyyyMMdd") + "', @idWF, '" + Permiso.WF.Estado + "') ");
            }
            else
            {
                a.AppendLine("insert Permiso values ('', '" + Permiso.TipoPermiso.Id + "', '" + Permiso.FechaFinVigencia.ToString("yyyyMMdd") + "', @idWF, '" + Permiso.WF.Estado + "') ");
            }
            a.AppendLine("insert Log values (@IdWF, getdate(), '" + Permiso.Usuario.Id + "', 'Permiso', 'Alta', '" + Permiso.WF.Estado + "', '') ");
            return a.ToString();
        }
        public List<CondecoEntidades.Usuario> LeerListaUsuariosAutorizadores()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select IdUsuario from Permiso IdTipoPermiso='AdminSITE' and Estado='Active' ");
            return LeerListaUsuarios(a.ToString());
        }
        public List<CondecoEntidades.Usuario> LeerListaUsuarios(string SqlScript)
        {
            DataTable dt = (DataTable)Ejecutar(SqlScript, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Usuario> lista = new List<CondecoEntidades.Usuario>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Usuario elem = new CondecoEntidades.Usuario();
                    elem.Id = Convert.ToString(dt.Rows[i]["IdUsuario"]);
                    Usuario db = new Usuario(sesion);
                    db.Leer(elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        public void CambioEstado(CondecoEntidades.Permiso Permiso, string EstadoHst)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @IdWF int ");
            a.AppendLine("select @IdWF=IdWF from Permiso where Estado='" + Permiso.WF.Estado + "' and IdUsuario='" + Permiso.Usuario.Id + "' and IdTipoPermiso='" + Permiso.TipoPermiso.Id + "' and Estado='" + Permiso.WF.Estado + "' ");
            a.AppendLine("if not @IdWF is null ");
            a.AppendLine("begin ");
            a.AppendLine("   update Permiso set Estado='" + EstadoHst + "' where IdWF=@IdWF ");
            a.AppendLine("   insert Log values (@IdWF, getdate(), '" + sesion.Usuario.Id + "', 'Permiso', 'Alta', '" + EstadoHst + "', '') ");
            a.AppendLine("end ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
            Permiso.WF.Estado = EstadoHst;
        }
        public void AgregarPermiso(CondecoEntidades.Permiso Permiso)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @IdWF  varchar(256) ");
            a.Append("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("insert Permiso values ('" + Permiso.IdUsuario + "', '" + Permiso.IdTipoPermiso + "', '" + Permiso.FechaFinVigencia.ToString("yyyyMMdd") + "', @idWF, '" + Permiso.Estado + "')");
            a.Append("insert Log values (@IdWF, getdate(), '" + Permiso.IdUsuario + "', 'Permiso', 'New', 'Active', '')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}