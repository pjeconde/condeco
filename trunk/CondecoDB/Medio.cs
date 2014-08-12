using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CondecoDB
{
    public class Medio : db
    {
        public Medio(CondecoEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public List<CondecoEntidades.Medio> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdMedio, DescrMedio from Medio order by DescrMedio ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Medio> lista = new List<CondecoEntidades.Medio>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Medio elem = new CondecoEntidades.Medio();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CondecoEntidades.Medio Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdMedio"]);
            Hasta.Descr = Convert.ToString(Desde["DescrMedio"]);
        }
    }
}