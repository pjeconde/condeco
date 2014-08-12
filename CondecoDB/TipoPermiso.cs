using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CondecoDB
{
    public class TipoPermiso : db
    {
        public TipoPermiso(CondecoEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CondecoEntidades.TipoPermiso TipoPermiso)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select TipoPermiso.IdTipoPermiso, TipoPermiso.DescrTipoPermiso from TipoPermiso where TipoPermiso.IdTipoPermiso='" + TipoPermiso.Id + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CondecoEX.Validaciones.ElementoInexistente("Tipo de Permiso " + TipoPermiso.Id);
            }
            else
            {
                Copiar(dt.Rows[0], TipoPermiso);
            }
        }
        private void Copiar(DataRow Desde, CondecoEntidades.TipoPermiso Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdTipoPermiso"]);
            Hasta.Descr = Convert.ToString(Desde["DescrTipoPermiso"]);
        }
        public List<CondecoEntidades.TipoPermiso> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select TipoPermiso.IdTipoPermiso, TipoPermiso.DescrTipoPermiso from TipoPermiso ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.TipoPermiso> lista = new List<CondecoEntidades.TipoPermiso>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.TipoPermiso elem = new CondecoEntidades.TipoPermiso();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
    }
}