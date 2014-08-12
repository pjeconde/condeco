using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CondecoDB
{
    public class Usuario : db
    {
        public Usuario(CondecoEntidades.Sesion Sesion) : base(Sesion)
        {
        }

        public void Leer(CondecoEntidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Usuario.IdUsuario, Usuario.Nombre, Usuario.Telefono, Usuario.Email, Usuario.Password, Usuario.Pregunta, Usuario.Respuesta, Usuario.CantidadEnviosMail, Usuario.FechaUltimoReenvioMail, Usuario.EmailSMS, Usuario.IdMedio, Usuario.IdWF, Usuario.Estado, Usuario.UltActualiz, Usuario.Pais, Usuario.Provincia, Usuario.Localidad, Usuario.Direccion, Usuario.CodPost, Usuario.Facebook, Usuario.DatoAdicional1, Usuario.DatoAdicional2 ");
            a.Append("from Usuario ");
            a.Append("where Usuario.IdUsuario='" + Usuario.Id + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CondecoEX.Validaciones.ElementoInexistente("User " + Usuario.Id);
            }
            else
            {
                Copiar(dt.Rows[0], Usuario);
            }
        }
        private void Copiar(DataRow Desde, CondecoEntidades.Usuario Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdUsuario"]);
            Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.Telefono = Convert.ToString(Desde["Telefono"]);
            Hasta.Email = Convert.ToString(Desde["Email"]);
            Hasta.Password = Convert.ToString(Desde["Password"]);
            Hasta.Pregunta = Convert.ToString(Desde["Pregunta"]);
            Hasta.Respuesta = Convert.ToString(Desde["Respuesta"]);
            Hasta.CantidadEnviosMail = Convert.ToInt32(Desde["CantidadEnviosMail"]);
            Hasta.FechaUltimoReenvioMail = Convert.ToDateTime(Desde["FechaUltimoReenvioMail"]);
            Hasta.EmailSMS = Convert.ToString(Desde["EmailSMS"]);
            Hasta.IdMedio = Convert.ToString(Desde["IdMedio"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
            Hasta.Pais = Convert.ToString(Desde["Pais"]);
            Hasta.Provincia = Convert.ToString(Desde["Provincia"]);
            Hasta.Localidad = Convert.ToString(Desde["Localidad"]);
            Hasta.Direccion = Convert.ToString(Desde["Direccion"]);
            Hasta.CodPost = Convert.ToString(Desde["CodPost"]);
            Hasta.Facebook = Convert.ToString(Desde["Facebook"]);
            Hasta.DatoAdicional1 = Convert.ToString(Desde["DatoAdicional1"]);
            Hasta.DatoAdicional2 = Convert.ToString(Desde["DatoAdicional2"]);
        }
        public void Crear(CondecoEntidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdMedio, IdWF, Estado, Pais, Provincia, Localidad, Direccion, CodPost, Facebook, DatoAdicional1, DatoAdicional2) values (");
            a.Append("'" + Usuario.Id + "', ");
            a.Append("'" + Usuario.Nombre + "', ");
            a.Append("'" + Usuario.Telefono + "', ");
            a.Append("'" + Usuario.Email + "', ");
            a.Append("'" + Usuario.Password + "', ");
            a.Append("'" + Usuario.Pregunta + "', ");
            a.Append("'" + Usuario.Respuesta + "', ");
            a.Append("1, ");            //CantidadEnviosMail
            a.Append("getdate(), ");    //FechaUltimoReenvioMail
            a.Append("'', ");           //EmailSMS
            a.Append("'" + Usuario.IdMedio + "', ");
            a.Append("@idWF, ");        //IdWF
            a.Append("'" + Usuario.WF.Estado + "', ");
            a.Append("'" + Usuario.Pais + "', ");
            a.Append("'" + Usuario.Provincia + "', ");
            a.Append("'" + Usuario.Localidad + "', ");
            a.Append("'" + Usuario.Direccion + "', ");
            a.Append("'" + Usuario.CodPost + "', ");
            a.Append("'" + Usuario.Facebook + "', ");
            a.Append("'" + Usuario.DatoAdicional1 + "', ");
            a.Append("'" + Usuario.DatoAdicional2 + "' ");
            a.AppendLine(") ");
            a.Append("insert Log values (@idWF, getdate(), '" + Usuario.Id + "', 'Usuario', 'New', 'PteConf', '') ");
            a.Append("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'");
            a.Append("insert Permiso values ('" + Usuario.Id + "', 'OperMilonga', '20621231', @idWF, 'Active')");
            a.Append("insert Log values (@IdWF, getdate(), '" + Usuario.Id + "', 'Permiso', 'New', 'Active', '')");
            a.Append("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'");
            a.Append("insert Permiso values ('" + Usuario.Id + "', 'OperFestival', '20621231', @idWF, 'Active')");
            a.Append("insert Log values (@IdWF, getdate(), '" + Usuario.Id + "', 'Permiso', 'New', 'Active', '')");
            a.Append("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'");
            a.Append("insert Permiso values ('" + Usuario.Id + "', 'OperTeacher', '20621231', @idWF, 'Active')");
            a.Append("insert Log values (@IdWF, getdate(), '" + Usuario.Id + "', 'Permiso', 'New', 'Active', '')");
            a.Append("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'");
            a.Append("insert Permiso values ('" + Usuario.Id + "', 'OperCastingArtistsOffer', '20621231', @idWF, 'Active')");
            a.Append("insert Log values (@IdWF, getdate(), '" + Usuario.Id + "', 'Permiso', 'New', 'Active', '')");
            a.Append("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'");
            a.Append("insert Permiso values ('" + Usuario.Id + "', 'OperCastingCall', '20621231', @idWF, 'Active')");
            a.Append("insert Log values (@IdWF, getdate(), '" + Usuario.Id + "', 'Permiso', 'New', 'Active', '')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Confirmar(CondecoEntidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("declare @idWF varchar(256) ");
            a.Append("declare @cantFilas int ");
            a.Append("select @idWF = IdWF from Usuario where IdUsuario='" + Usuario.Id + "' ");
            a.Append("update Usuario set Estado='Active' where IdUsuario='" + Usuario.Id + "' and Estado='PteConf' ");
            a.Append("set @cantFilas = @@ROWCOUNT ");
            a.Append("if @cantFilas = 1 ");
            a.Append("    insert Log values (@idWF, getdate(), '" + Usuario.Id + "', 'Usuario', 'Confirm', 'Active', '') ");
            a.Append("select @cantFilas as CantFilas ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (Convert.ToInt32(dt.Rows[0]["CantFilas"]) != 1)
            {
                throw new CondecoEX.Usuario.ErrorDeConfirmacion();
            }
        }
        public bool IdUsuarioDisponible(CondecoEntidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("IF EXISTS(select * from Usuario where IdUsuario='" + Usuario.Id + "') ");
            a.Append("  BEGIN ");
            a.Append("	select convert(bit, 0) as Disponible ");
            a.Append("  END ");
            a.Append("ELSE ");
            a.Append("  BEGIN ");
            a.Append("	select convert(bit, 1) as Disponible ");
            a.Append("  END ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToBoolean(dt.Rows[0]["Disponible"]);
        }
        public List<CondecoEntidades.Usuario> DestinatariosAvisoAltaUsuario()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Usuario.IdUsuario, Usuario.Nombre, Usuario.Telefono, Usuario.Email, Usuario.Password, Usuario.Pregunta, Usuario.Respuesta, Usuario.CantidadEnviosMail, Usuario.FechaUltimoReenvioMail, Usuario.EmailSMS, Usuario.IdMedio, Usuario.IdWF, Usuario.Estado, Usuario.UltActualiz, Usuario.Pais, Usuario.Provincia, Usuario.Localidad, Usuario.Direccion, Usuario.CodPost, Usuario.Facebook, Usuario.DatoAdicional1, Usuario.DatoAdicional2 ");
            a.Append("from Usuario, Permiso ");
            a.Append("where Usuario.IdUsuario=Permiso.IdUsuario and Permiso.IdTipoPermiso='AdminSITE' and Usuario.EmailSMS<>'' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Usuario> lista = new List<CondecoEntidades.Usuario>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CondecoEntidades.Usuario usuario = new CondecoEntidades.Usuario();
                Copiar(dt.Rows[i], usuario);
                lista.Add(usuario);
            }
            return lista;
        }
        public int CantidadDeFilas()
        {
            string commandText = "select count(*) from Usuario ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public void CambiarPassword(CondecoEntidades.Usuario Usuario, string PasswordNueva)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Usuario set Password='" + PasswordNueva + "' where IdUsuario='" + Usuario.Id + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CondecoEntidades.Usuario> Lista(string Email)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Usuario.IdUsuario, Usuario.Nombre, Usuario.Telefono, Usuario.Email, Usuario.Password, Usuario.Pregunta, Usuario.Respuesta, Usuario.CantidadEnviosMail, Usuario.FechaUltimoReenvioMail, Usuario.EmailSMS, Usuario.IdMedio, Usuario.IdWF, Usuario.Estado, Usuario.UltActualiz, Usuario.Pais, Usuario.Provincia, Usuario.Localidad, Usuario.Direccion, Usuario.CodPost, Usuario.Facebook, Usuario.DatoAdicional1, Usuario.DatoAdicional2 ");
            a.Append("from Usuario ");
            a.Append("where Usuario.Email='" + Email + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CondecoEX.Usuario.NoHayUsuariosAsociadasAEmail();
            }
            else
            {
                List<CondecoEntidades.Usuario> lista = new List<CondecoEntidades.Usuario>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Usuario elem = new CondecoEntidades.Usuario();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
                return lista;
            }
        }
        public List<CondecoEntidades.Usuario> Lista(string IdUsuario, string Nombre, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Usuario.IdUsuario, Usuario.Nombre, Usuario.Telefono, Usuario.Email, Usuario.Password, Usuario.Pregunta, Usuario.Respuesta, Usuario.CantidadEnviosMail, Usuario.FechaUltimoReenvioMail, Usuario.EmailSMS, Usuario.IdMedio, Usuario.IdWF, Usuario.Estado, Usuario.UltActualiz, Usuario.Pais, Usuario.Provincia, Usuario.Localidad, Usuario.Direccion, Usuario.CodPost, Usuario.Facebook, Usuario.DatoAdicional1, Usuario.DatoAdicional2 ");
            a.Append("from Usuario ");
            if (!IdUsuario.Equals(string.Empty) || !Nombre.Equals(string.Empty) || !Estado.Equals(string.Empty))
            {
                a.Append("where ");
            }
            if (!IdUsuario.Equals(string.Empty))
            {
                a.Append("Usuario.IdUsuario like '%" + IdUsuario + "%' ");
            }
            if (!Nombre.Equals(string.Empty))
            {
                if (!IdUsuario.Equals(string.Empty))
                {
                    a.Append("and ");
                }
                a.Append("Usuario.Nombre like '%" + Nombre + "%' ");
            }
            if (!Estado.Equals(string.Empty))
            {
                if (!IdUsuario.Equals(string.Empty) ||!Nombre.Equals(string.Empty))
                {
                    a.Append("and ");
                }
                a.Append("Usuario.Estado like '%" + Estado + "%' ");
            }
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CondecoEntidades.Usuario> lista = new List<CondecoEntidades.Usuario>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CondecoEntidades.Usuario elem = new CondecoEntidades.Usuario();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        public string ListaIdUsuariosParaSQLscript()
        {
            string a = String.Empty;
            DataTable dt = (DataTable)Ejecutar("select Usuario.IdUsuario from Usuario ", TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            for (int i=0; i<dt.Rows.Count; i++)
            {
                a += "'" + dt.Rows[i]["IdUsuario"] + "'";
                if (i != dt.Rows.Count - 1) a += ", ";
            }
            return a;
        }
        public void CambioEstado(CondecoEntidades.Usuario Usuario, string Evento, string EstadoHst)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("declare @idWF varchar(256) ");
            a.Append("declare @cantFilas int ");
            a.Append("select @idWF = IdWF from Usuario where IdUsuario='" + Usuario.Id + "' ");
            a.Append("update Usuario set Estado='" + EstadoHst +"' where IdUsuario='" + Usuario.Id + "' and Estado='" + Usuario.Estado + "' ");
            a.Append("set @cantFilas = @@ROWCOUNT ");
            a.Append("if @cantFilas = 1 ");
            a.Append("    insert Log values (@idWF, getdate(), '" + Usuario.Id + "', 'Usuario', '" + Evento + "', '" + EstadoHst + "', '') ");
            a.Append("select @cantFilas as CantFilas ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (Convert.ToInt32(dt.Rows[0]["CantFilas"]) != 1)
            {
                throw new CondecoEX.Usuario.ErrorDeConfirmacion();
            }
        }
    }
}