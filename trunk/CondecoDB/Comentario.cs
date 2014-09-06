using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CondecoDB
{
    public class Comentario : db
    {
        public Comentario(CondecoEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public int Crear(CondecoEntidades.Comentario Comentario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idUltimoIdComentario int ");
            a.AppendLine("select @idUltimoIdComentario = (select isnull(Max(IdComentario) + 1, 1) from Comentario where NombreEntidad = '" + Comentario.NombreEntidad + "' and IdEntidad = " + Comentario.IdEntidad + ")");
            a.Append("Insert Comentario (IdComentario, IdReplica, NombreEntidad, IdEntidad, NombreUsuario, IdUsuario, Contenido, ");
            a.Append("Fecha, Url, Estado, ManoOk, ManoNoOk, AbusoContenido) values (");
            a.Append("@idUltimoIdComentario, ");
            a.Append("0, '");
            a.Append(Comentario.NombreEntidad + "', ");
            a.Append(Comentario.IdEntidad + ", '");
            a.Append(Comentario.NombreUsuario + "', '");
            a.Append(Comentario.IdUsuario + "', '");
            a.Append(Comentario.Contenido + "', '");
            a.Append(Comentario.Fecha.ToString("yyyyMMdd hh:mm:ss") + "', '");
            a.Append(Comentario.Url + "', '");
            a.Append(Comentario.Estado + "', ");
            a.Append(Comentario.ManoOk + ", ");
            a.Append(Comentario.ManoNoOk + ", ");
            a.Append(Comentario.AbusoContenido);
            a.AppendLine(") ");
            a.AppendLine("Select @idUltimoIdComentario");
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

        public int Replicar(CondecoEntidades.Comentario Comentario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idReplica int ");
            a.AppendLine("select @idReplica = (select Max(IdReplica) + 1 from Comentario where NombreEntidad = '" + Comentario.NombreEntidad + "' and IdEntidad = " + Comentario.IdEntidad + "and IdComentario = " + Comentario.Id + ")");
            a.Append("Insert Comentario (IdComentario, IdReplica, NombreEntidad, IdEntidad, NombreUsuario, IdUsuario, Contenido, ");
            a.Append("Fecha, Url, Estado, ManoOk, ManoNoOk, AbusoContenido) values (");
            a.Append(Comentario.Id + ", ");
            a.Append("@idReplica, '");
            a.Append(Comentario.NombreEntidad + "', ");
            a.Append(Comentario.IdEntidad + ", '");
            a.Append(Comentario.NombreUsuario + "', '");
            a.Append(Comentario.IdUsuario + "', '");
            a.Append(Comentario.Contenido + "', '");
            a.Append(Comentario.Fecha.ToString("yyyyMMdd hh:mm:ss") + "', '");
            a.Append(Comentario.Url + "', '");
            a.Append(Comentario.Estado + "', ");
            a.Append(Comentario.ManoOk + ", ");
            a.Append(Comentario.ManoNoOk + ", ");
            a.Append(Comentario.AbusoContenido);
            a.Append(") ");
            a.AppendLine("Select @idReplica");
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

        public CondecoEntidades.Comentario Leer(int IdComentario, int IdReplica)
        {
            CondecoEntidades.Comentario Comentario = new CondecoEntidades.Comentario();
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select * ");
            a.Append("from Comentario ");
            a.Append("where Comentario.IdComentario = " + IdComentario + " ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CondecoEX.Validaciones.ElementoInexistente("Comment " + IdComentario);
            }
            else
            {
                Copiar(dt.Rows[0], Comentario);
            }
            return Comentario;
        }

        public List<CondecoEntidades.Comentario> Lista(string NombreEntidad, string IdEntidad, string IdUsuario)
        {
            List<CondecoEntidades.Comentario> lista = new List<CondecoEntidades.Comentario>();
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select * ");
            a.Append("from Comentario ");
            a.Append("where NombreEntidad = '" + NombreEntidad + "' ");
            if (IdEntidad != "")
            {
                a.Append("and IdEntidad = " + Convert.ToInt32(IdEntidad) + " ");
            }
            if (IdUsuario != "")
            {
                a.Append("and IdUsuario = '" + IdUsuario + "' ");
            }
            a.Append("order by IdComentario Desc, IdReplica Asc");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Comentario comentario = new CondecoEntidades.Comentario();
                    Copiar(dt.Rows[i], comentario);
                    lista.Add(comentario);
                }
            }
            return lista;
        }

        public List<CondecoEntidades.Comentario> Lista(int IndicePagina, int TamañoPagina, string OrderBy, string SessionID, List<CondecoEntidades.Comentario> ComentarioLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Comentario" + SessionID + "( ");
            a.Append("[IdComentario] [int] NOT NULL, ");
            a.Append("[IdReplica] [int] NOT NULL, ");
            a.Append("[NombreEntidad] [varchar](50) NOT NULL, ");
            a.Append("[IdEntidad] int NOT NULL, ");
            a.Append("[NombreUsuario] [varchar](50) NOT NULL, ");
            a.Append("[IdUsuario] [varchar](50) NOT NULL, ");
            a.Append("[Contenido] ntext NOT NULL, ");
            a.Append("[Fecha] [datetime] NOT NULL, ");
            a.Append("[Url] [varchar](200) NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[ManoOk] [int] NOT NULL, ");
            a.Append("[ManoNoOk] [int] NOT NULL, ");
            a.Append("[AbusoContenido] [int] NOT NULL, ");
            a.Append("CONSTRAINT [PK_Comentario" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[IdComentario] ASC, ");
            a.Append("[IdReplica] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (CondecoEntidades.Comentario Comentario in ComentarioLista)
            {
                a.Append("Insert #Comentario" + SessionID + " values (" + Comentario.Id + ", ");
                a.Append(Comentario.IdReplica + ", '");
                a.Append(Comentario.NombreEntidad + "', ");
                a.Append(Comentario.IdEntidad + ", '");
                a.Append(Comentario.NombreUsuario + "', '");
                a.Append(Comentario.IdUsuario + "', '");
                a.Append(Comentario.Contenido + "', '");
                a.Append(Comentario.Fecha.ToString("yyyyMMdd hh:mm:ss") + "', '");
                a.Append(Comentario.Url + "', '");
                a.Append(Comentario.Estado + "', ");
                a.Append(Comentario.ManoOk + ", ");
                a.Append(Comentario.ManoNoOk + ", ");
                a.Append(Comentario.AbusoContenido + ") ");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("IdComentario, IdReplica, NombreEntidad, IdEntidad, NombreUsuario, IdUsuario, Contenido, Fecha, Url, Estado, ManoOk, ManoNoOk, AbusoContenido ");
            a.Append("from #Comentario" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #Comentario" + SessionID);
            OrderBy = "#Comentario" + SessionID + ".IdComentario Desc, #Comentario" + SessionID + ".IdReplica Asc ";
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Comentario> lista = new List<CondecoEntidades.Comentario>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Comentario comentario = new CondecoEntidades.Comentario();
                    Copiar(dt.Rows[i], comentario);
                    lista.Add(comentario);
                }
            }
            return lista;
        }

        public void CambiarEstado(CondecoEntidades.Comentario Comentario, string Evento, string Estado)
        {
            if (sesion.Usuario.Id != null)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.Append("update Comentario set ");
                a.Append("Estado='" + Estado + "' ");
                a.AppendLine("where IdComentario=" + Comentario.Id + " and IdReplica = " + Comentario.IdReplica);
                //a.AppendLine("insert Log values (" + Producto.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Producto', '" + Evento + "', '" + Estado + "', '') ");
                Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
            }
        }

        private void Copiar(DataRow Desde, CondecoEntidades.Comentario Hasta)
        {
            Hasta.Id = Convert.ToInt32(Desde["IdComentario"]);
            Hasta.IdReplica = Convert.ToInt32(Desde["IdReplica"]);
            Hasta.NombreUsuario = Convert.ToString(Desde["NombreUsuario"]);
            Hasta.IdUsuario = Convert.ToString(Desde["IdUsuario"]);
            Hasta.NombreEntidad = Convert.ToString(Desde["NombreEntidad"]);
            Hasta.IdEntidad = Convert.ToInt32(Desde["IdEntidad"]);
            Hasta.Contenido = Convert.ToString(Desde["Contenido"]);
            Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
            Hasta.Url = Convert.ToString(Desde["Url"]);
            Hasta.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.ManoOk = Convert.ToInt32(Desde["ManoOk"]);
            Hasta.ManoNoOk = Convert.ToInt32(Desde["ManoNoOk"]);
            Hasta.AbusoContenido = Convert.ToInt32(Desde["AbusoContenido"]);
        }

        public bool ComprobarComentario(string NombreEntidad, int IdEntidad, string Contenido)
        {
            bool resp = false;
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select * ");
            a.Append("from Comentario where NombreEntidad = '" + NombreEntidad + "' and IdEntidad = " + IdEntidad + " and ");
            a.Append("Contenido like '%" + Contenido + "%'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                resp = true;
            }
            return resp;
        }
        public void GuardarComentarioEstadistica(string NombreEntidad, int IdEntidad, int IdComentario, int IdReplica, string Objeto)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("Insert ComentarioEstadistica (NombreEntidad, IdEntidad, IdComentario, IdReplica, IdUsuario, Objeto) values ('");
            a.Append(NombreEntidad + "', " + IdEntidad + ", " + IdComentario + ", " + IdReplica + ", '" + sesion.Usuario.Id + "', '" + Objeto + "') ");
            a.AppendLine("declare @ValorObjeto int");
            a.AppendLine("select @ValorObjeto = " + Objeto + " + 1 from Comentario where IdComentario = " + IdComentario + " and IdReplica = " + IdReplica);
            a.AppendLine("Update Comentario set " + Objeto + " = @ValorObjeto where IdComentario = " + IdComentario + " and IdReplica = " + IdReplica); 
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}
