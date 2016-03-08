using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CondecoDB
{
    public class Producto : db
    {
        public Producto(CondecoEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CondecoEntidades.Producto Producto)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Producto.IdProducto, Producto.Nombre, Producto.Descripcion, Producto.DescripcionCorta, Producto.IdMoneda, Producto.PrecioBase, Producto.ComentarioPrecioBase, Producto.IdWF, Producto.Estado, Producto.IdTipoProducto, Producto.Ranking, Producto.UltActualiz, Producto.TipoDestacado, Producto.YouTube ");
            a.Append("from Producto ");
            a.Append("where Producto.IdProducto = " + Producto.Id + " ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CondecoEX.Validaciones.ElementoInexistente("Producto " + Producto.Id);
            }
            else
            {
                Copiar(dt.Rows[0], Producto);
            }
        }
        private void Copiar(DataRow Desde, CondecoEntidades.Producto Hasta)
        {
            Hasta.Id = Convert.ToInt32(Desde["IdProducto"]);
            Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.Descripcion = Convert.ToString(Desde["Descripcion"]);
            Hasta.DescripcionCorta = Convert.ToString(Desde["DescripcionCorta"]);
            Hasta.IdMoneda = Convert.ToString(Desde["IdMoneda"]);
            Hasta.PrecioBase = Convert.ToDecimal(Desde["PrecioBase"]);
            Hasta.ComentarioPrecioBase = Convert.ToString(Desde["ComentarioPrecioBase"]);
            Hasta.TipoProducto.Id = Convert.ToInt32(Desde["IdTipoProducto"]);
            Hasta.Ranking = Convert.ToInt32(Desde["Ranking"]);
            Hasta.TipoDestacado = Convert.ToString(Desde["TipoDestacado"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
            Hasta.YouTube = Convert.ToString(Desde["YouTube"]);
            Hasta.NombreImagenPortada = "PortadaGral.jpg";
        }
        public int Crear(CondecoEntidades.Producto Producto)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("declare @idUltimoIdProducto varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.AppendLine("update Configuracion set @idUltimoIdProducto=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdProducto' ");
            a.Append("Insert Producto (IdProducto, Nombre, Descripcion, DescripcionCorta, IdMoneda, PrecioBase, ComentarioPrecioBase, ");
            a.Append("IdWF, Estado, IdTipoProducto, Ranking, TipoDestacado, YouTube) values (");
            a.Append("@idUltimoIdProducto, ");
            a.Append("'" + Producto.Nombre + "', ");
            a.Append("'" + Producto.Descripcion + "', ");
            a.Append("'" + Producto.DescripcionCorta + "', ");
            a.Append("'" + Producto.IdMoneda + "', ");
            a.Append(Convert.ToDouble(Producto.PrecioBase) + ", ");
            a.Append("'" + Producto.ComentarioPrecioBase + "', ");
            a.Append("@idWF, ");
            a.Append("'" + Producto.WF.Estado + "', ");
            a.Append(Producto.TipoProducto.Id + ", ");
            a.Append(Producto.Ranking + ", ");
            a.Append("'" + Producto.TipoDestacado + "', ");
            a.Append("'" + Producto.YouTube + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Producto', 'Alta', '" + Producto.WF.Estado + "', '') ");
            a.AppendLine("Select @idUltimoIdProducto");
            a.AppendLine();
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            int resp = 0;
            if (dt.Rows.Count != 0)
            {
                resp = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return resp;
        }
        public void Modificar(CondecoEntidades.Producto Desde, CondecoEntidades.Producto Hasta)
        {
            if (sesion.Usuario.Id != null)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.Append("update Producto set ");
                a.Append("Nombre = '" + Hasta.Nombre + "', ");
                a.Append("Descripcion = '" + Hasta.Descripcion + "', ");
                a.Append("DescripcionCorta = '" + Hasta.DescripcionCorta + "', ");
                a.Append("IdMoneda = '" + Hasta.IdMoneda + "', ");
                a.Append("PrecioBase = " + Convert.ToDouble(Hasta.PrecioBase) + ", ");
                a.Append("ComentarioPrecioBase = '" + Hasta.ComentarioPrecioBase + "', ");
                a.Append("IdTipoProducto = " + Hasta.TipoProducto.Id + ", ");
                a.Append("Ranking = '" + Hasta.Ranking + "', ");
                a.Append("TipoDestacado = '" + Hasta.TipoDestacado + "' ");
                a.Append("where IdProducto = " + Hasta.Id + " ");
                a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Producto', 'Modif', '" + Hasta.WF.Estado + "', '') ");
                a.AppendLine("declare @idLog int ");
                a.AppendLine("select @idLog=@@Identity ");
                a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
                a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
                Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
            }
        }
        public void CambiarEstado(CondecoEntidades.Producto Producto, string Evento, string Estado)
        {
            if (sesion.Usuario.Id != null)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.Append("update Producto set ");
                a.Append("Estado='" + Estado + "' ");
                a.AppendLine("where IdProducto=" + Producto.Id);
                a.AppendLine("insert Log values (" + Producto.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Producto', '" + Evento + "', '" + Estado + "', '') ");
                Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
            }
        }
        public List<CondecoEntidades.Producto> ListaPorIdProducto(int IdProducto)
        {
            List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
            if (sesion.Usuario.Id != null)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.Append("select Producto.IdProducto, Producto.Nombre, Producto.Descripcion, Producto.DescripcionCorta, Producto.IdMoneda, Producto.PrecioBase, Producto.ComentarioPrecioBase, Producto.IdWF, Producto.Estado, Producto.IdTipoProducto, Producto.Ranking, Producto.UltActualiz, Producto.TipoDestacado, Producto.YouTube ");
                a.Append("from Producto where IdProducto = " + IdProducto);
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CondecoEntidades.Producto Producto = new CondecoEntidades.Producto();
                        Copiar(dt.Rows[i], Producto);
                        lista.Add(Producto);
                    }
                }
            }
            return lista;
        }
        public List<CondecoEntidades.Producto> ListaPorNombre(string Nombre)
        {
            List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
            if (sesion.Usuario.Id != null)
            {
                if (sesion.Usuario.Id != null)
                {
                    StringBuilder a = new StringBuilder(string.Empty);
                    a.Append("select Producto.IdProducto, Producto.Nombre, Producto.Descripcion, Producto.DescripcionCorta, Producto.IdMoneda, Producto.PrecioBase, Producto.ComentarioPrecioBase, Producto.IdWF, Producto.Estado, Producto.IdTipoProducto, Producto.Ranking, Producto.UltActualiz, Producto.TipoDestacado, Producto.YouTube ");
                    a.Append("from Producto where Nombre like '%" + Nombre + "%'");
                    DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CondecoEntidades.Producto Producto = new CondecoEntidades.Producto();
                            Copiar(dt.Rows[i], Producto);
                            lista.Add(Producto);
                        }
                    }
                }
            }
            return lista;
        }
        public List<CondecoEntidades.Producto> ListaCompletaVigentes(string OrderBy, string Descripcion, string ListaTipoProducto)
        {
            List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Producto.IdProducto, Producto.Nombre, Producto.Descripcion, Producto.DescripcionCorta, Producto.IdMoneda, Producto.PrecioBase, Producto.ComentarioPrecioBase, Producto.IdWF, Producto.Estado, Producto.IdTipoProducto, Producto.Ranking, Producto.UltActualiz, Producto.TipoDestacado, Producto.YouTube ");
            a.Append("from Producto where 1=1 ");
            if (!Descripcion.Equals(string.Empty))
            {
                a.Append("and (Nombre like '%" + Descripcion + "%' or Descripcion like '%" + Descripcion + "%') ");
            }
            if (!ListaTipoProducto.Equals(string.Empty))
            {
                a.Append("and IdTipoProducto in (" +  ListaTipoProducto + ") ");
            }
            a.Append("and Estado = 'Vigente' ");
            a.Append("order by " + OrderBy);
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Producto Producto = new CondecoEntidades.Producto();
                    Copiar(dt.Rows[i], Producto);
                    lista.Add(Producto);
                }
            }
            return lista;
        }
        public List<CondecoEntidades.Producto> ListaCompletaAdmin(string OrderBy, string Nombre, string Descripcion, string ListaTipoProducto)
        {
            List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Producto.IdProducto, Producto.Nombre, Producto.Descripcion, Producto.DescripcionCorta, Producto.IdMoneda, Producto.PrecioBase, Producto.ComentarioPrecioBase, Producto.IdWF, Producto.Estado, Producto.IdTipoProducto, Producto.Ranking, Producto.UltActualiz, Producto.TipoDestacado, Producto.YouTube ");
            a.Append("from Producto where 1=1 ");
            if (!Nombre.Equals(string.Empty))
            {
                a.Append("and Nombre like '%" + Nombre + "%' ");
            }
            if (!Descripcion.Equals(string.Empty))
            {
                a.Append("and Descripcion like '%" + Descripcion + "%' ");
            }
            if (!ListaTipoProducto.Equals(string.Empty))
            {
                a.Append("and IdTipoProducto in (" + ListaTipoProducto + ") ");
            }
            a.Append("order by " + OrderBy);
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Producto Producto = new CondecoEntidades.Producto();
                    Copiar(dt.Rows[i], Producto);
                    lista.Add(Producto);
                }
            }
            return lista;
        }
        public List<CondecoEntidades.Producto> Lista(int IndicePagina, int TamañoPagina, string OrderBy, string SessionID, List<CondecoEntidades.Producto> ProductoLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Producto" + SessionID + "( ");
            a.Append("[IdProducto] [int] NOT NULL, ");
	        a.Append("[Nombre] [varchar](50) NOT NULL, ");
	        a.Append("[Descripcion] [varchar](2000) NOT NULL, ");
            a.Append("[DescripcionCorta] [varchar](500) NOT NULL, ");
            a.Append("[IdMoneda] [varchar](10) NOT NULL, ");
	        a.Append("[PrecioBase] [numeric](18, 2) NOT NULL, ");
	        a.Append("[ComentarioPrecioBase] [varchar](250) NOT NULL, ");
	        a.Append("[IdWF] [int] NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[IdTipoProducto] [int] NOT NULL, ");
            a.Append("[Ranking] [int] NOT NULL, ");
            a.Append("[TipoDestacado] [varchar](2) NOT NULL, ");
            a.Append("[YouTube] [varchar](100) NOT NULL, ");
            a.Append("CONSTRAINT [PK_Producto" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[IdProducto] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (CondecoEntidades.Producto Producto in ProductoLista)
            {
                a.Append("Insert #Producto" + SessionID + " values (" + Producto.Id + ", '");
                a.Append(Producto.Nombre + "', '");
                a.Append(Producto.Descripcion + "', '");
                a.Append(Producto.DescripcionCorta + "', '");
                a.Append(Producto.IdMoneda + "', ");
                a.Append(Convert.ToDouble(Producto.PrecioBase) + ", '");
                a.Append(Producto.ComentarioPrecioBase + "', ");
                a.Append(Producto.WF.Id + ", '");
                a.Append(Producto.Estado + "', ");
                a.Append(Producto.IdTipoProducto + ", ");
                a.Append(Producto.Ranking + ", '");
                a.Append(Producto.TipoDestacado + "',' ");
                a.Append(Producto.YouTube + "') ");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("IdProducto, Nombre, Descripcion, DescripcionCorta, IdMoneda, PrecioBase, ComentarioPrecioBase, IdWF, Estado, IdTipoProducto, Ranking, TipoDestacado, YouTube ");
            a.Append("from #Producto" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #Producto" + SessionID);
            if (OrderBy.Trim().ToUpper() == "NOMBRE" || OrderBy.Trim().ToUpper() == "NOMBRE DESC" || OrderBy.Trim().ToUpper() == "NOMBRE ASC")
            {
                OrderBy = "#Producto" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Producto Producto = new CondecoEntidades.Producto();
                    Producto.Id = Convert.ToInt32(dt.Rows[i]["IdProducto"].ToString());
                    Producto.Nombre = dt.Rows[i]["Nombre"].ToString();
                    Producto.Descripcion = dt.Rows[i]["Descripcion"].ToString();
                    Producto.DescripcionCorta = dt.Rows[i]["DescripcionCorta"].ToString();
                    Producto.IdMoneda = dt.Rows[i]["IdMoneda"].ToString();
                    Producto.PrecioBase = Convert.ToDecimal(dt.Rows[i]["PrecioBase"]);
                    Producto.ComentarioPrecioBase = dt.Rows[i]["ComentarioPrecioBase"].ToString();
                    Producto.TipoProducto.Id = Convert.ToInt32(dt.Rows[i]["IdTipoProducto"].ToString());
                    Producto.Ranking = Convert.ToInt32(dt.Rows[i]["Ranking"].ToString());
                    Producto.TipoDestacado = dt.Rows[i]["TipoDestacado"].ToString();
                    Producto.WF.Id = Convert.ToInt32(dt.Rows[i]["IdWF"].ToString());
                    Producto.WF.Estado = dt.Rows[i]["Estado"].ToString();
                    Producto.YouTube = dt.Rows[i]["YouTube"].ToString();
                    Producto.NombreImagenPortada = "PortadaGral.jpg";
                    lista.Add(Producto);
                }
            }
            return lista;
        }
        public bool ComprobarNombreProducto(string Nombre)
        {
            bool resp = false;
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Producto.IdProducto, Producto.Nombre, Producto.Descripcion, Producto.DescripcionCorta, Producto.IdMoneda, Producto.PrecioBase, Producto.ComentarioPrecioBase, Producto.IdWF, Producto.Estado, Producto.IdTipoProducto, Producto.Ranking, Producto.UltActualiz, Producto.TipoDestacado, Producto.YouTube ");
            a.Append("from Producto where ");
            a.Append("Nombre like '%" + Nombre + "%'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                resp = true;
            }
            return resp;
        }
    }
}
