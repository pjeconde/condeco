using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CondecoDB
{
    public class TipoProducto : db
    {
        public TipoProducto(CondecoEntidades.Sesion Sesion): base(Sesion)
        {
        }
        public void Leer(CondecoEntidades.TipoProducto TipoProducto)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select * from TipoProducto where TipoProducto.IdTipoProducto=" + TipoProducto.Id);
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CondecoEX.Validaciones.ElementoInexistente("Tipo de Producto " + TipoProducto.Id);
            }
            else
            {
                Copiar(dt.Rows[0], TipoProducto);
            }
        }
        private void Copiar(DataRow Desde, CondecoEntidades.TipoProducto Hasta)
        {
            Hasta.Id = Convert.ToInt32(Desde["IdTipoProducto"]);
            Hasta.Descr = Convert.ToString(Desde["DescrTipoProducto"]);
            Hasta.IdPariente = Convert.ToInt32(Desde["IdPariente"]);
        }
        public List<CondecoEntidades.TipoProducto> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select * from TipoProducto");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.TipoProducto> lista = new List<CondecoEntidades.TipoProducto>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.TipoProducto elem = new CondecoEntidades.TipoProducto();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
    }
}