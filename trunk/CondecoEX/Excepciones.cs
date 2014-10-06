using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CondecoEX
{
    namespace Validaciones
    {
        [Serializable]
        public class BaseApplicationException : CondecoEX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ValorNoInfo : CondecoEX.Validaciones.BaseApplicationException
        {
            static string TextoError = "Valor sin informar";
            public ValorNoInfo(string descrProp)
                : base(descrProp + " " + TextoError)
            {
            }
            public ValorNoInfo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ValorNoInfo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ValorInvalido : CondecoEX.Validaciones.BaseApplicationException
        {
            static string TextoError = "Valor inválido";
            public ValorInvalido(string descrProp)
                : base(descrProp + ": " + TextoError)
            {
            }
            public ValorInvalido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ValorInvalido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ElementoInexistente : CondecoEX.Validaciones.BaseApplicationException
        {
            static string TextoError = "Inexistente";
            public ElementoInexistente(IDescrClase Elemento)
                : base(Elemento._Descripcion + " " + TextoError)
            {
            }
            public ElementoInexistente(IDescrClase Elemento, string Valor)
                : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
            {
            }
            public ElementoInexistente(string Descripcion)
                : base(Descripcion + " " + TextoError)
            {
            }
            public ElementoInexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ElementoInexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ElementoYaInexistente : CondecoEX.Validaciones.BaseApplicationException
        {
            static string TextoError = "Existente";
            public ElementoYaInexistente(IDescrClase Elemento)
                : base(Elemento._Descripcion + " " + TextoError)
            {
            }
            public ElementoYaInexistente(IDescrClase Elemento, string Valor)
                : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
            {
            }
            public ElementoYaInexistente(string Descripcion)
                : base(Descripcion + " " + TextoError)
            {
            }
            public ElementoYaInexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ElementoYaInexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace Imagenes
    {
        [Serializable]
        public class BaseApplicationException : CondecoEX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LimiteMaximoExcedido : CondecoEX.Imagenes.BaseApplicationException
        {
            static string TextoError = "Con esta imagen excedería el máximo permitido.";
            public LimiteMaximoExcedido(string Descr)
                : base(TextoError + " " + Descr)
            {
            }
            public LimiteMaximoExcedido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LimiteMaximoExcedido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace Usuario
    {
        [Serializable]
        public class BaseApplicationException : CondecoEX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordYConfirmacionNoCoincidente : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "Esta clave no coincide con la confirmación";
            public PasswordYConfirmacionNoCoincidente()
                : base(TextoError)
            {
            }
            public PasswordYConfirmacionNoCoincidente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordYConfirmacionNoCoincidente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordNuevaIgualAActual : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "La nueva clave debería ser diferente a la actual";
            public PasswordNuevaIgualAActual()
                : base(TextoError)
            {
            }
            public PasswordNuevaIgualAActual(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordNuevaIgualAActual(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class IdUsuarioNoDisponible : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "El usuario de ingreso que usted a elegido ya ha sido utilizado por otra persona. Ingrese otro y verifique nuevamente que no exista.";
            public IdUsuarioNoDisponible()
                : base(TextoError)
            {
            }
            public IdUsuarioNoDisponible(Exception inner)
                : base(TextoError, inner)
            {
            }
            public IdUsuarioNoDisponible(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ErrorDeConfirmacion : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "Mensaje de confirmación (Creación de nueva cuenta). No se puede ejecutar.  Es probable que la confirmación ya haya sido registrada.  Verifique si puede identificarse.  En paso contrario, póngase en contacto con Nosotros, para solucionar el inconveniente.  Muchas gracias.";
            public ErrorDeConfirmacion()
                : base(TextoError)
            {
            }
            public ErrorDeConfirmacion(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ErrorDeConfirmacion(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXEstadoCuenta : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "Login Mensaje (La cuenta está pendiente de confirmación o cancelada)";
            public LoginRechazadoXEstadoCuenta()
                : base(TextoError)
            {
            }
            public LoginRechazadoXEstadoCuenta(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXEstadoCuenta(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXPasswordInvalida : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "Password inválido";
            public LoginRechazadoXPasswordInvalida()
                : base(TextoError)
            {
            }
            public LoginRechazadoXPasswordInvalida(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXPasswordInvalida(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class NoHayUsuariosAsociadasAEmail : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "No hay cuentas asociadas con la dirección de email especificada";
            public NoHayUsuariosAsociadasAEmail()
                : base(TextoError)
            {
            }
            public NoHayUsuariosAsociadasAEmail(Exception inner)
                : base(TextoError, inner)
            {
            }
            public NoHayUsuariosAsociadasAEmail(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class UsuarioConfFormatoMsgErroneo : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "Mensaje de confirmación (Creación de nueva cuenta) error en el formato.  Por favor contáctese con Nosotros, para solucionar el problema.  Muchas Gracias.";
            public UsuarioConfFormatoMsgErroneo()
                : base(TextoError)
            {
            }
            public UsuarioConfFormatoMsgErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public UsuarioConfFormatoMsgErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordNoMatch : CondecoEX.Usuario.BaseApplicationException
        {
            static string TextoError = "Clave incorrecta";
            public PasswordNoMatch()
                : base(TextoError)
            {
            }
            public PasswordNoMatch(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordNoMatch(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
	namespace db
	{
        [Serializable]
        public class BaseApplicationException : CondecoEX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
		[Serializable]
		public class Conexion : CondecoEX.db.BaseApplicationException
		{
            static string TextoError = "Problemas conectandose con la base de datos";
			public Conexion() : base(TextoError)
			{
			}
			public Conexion(Exception inner) : base(TextoError, inner)
			{
			}
			public Conexion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Ejecucion : CondecoEX.db.BaseApplicationException
		{
            static string TextoError = "Problemas ejecutando SQL script";
			public Ejecucion() : base(TextoError)
			{
			}
			public Ejecucion(Exception inner) : base(TextoError, inner)
			{
			}
			public Ejecucion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class EjecucionConRollback : CondecoEX.db.BaseApplicationException
		{
            static string TextoError = "Problemas ejecutando SQL script (la operación ha sido cancelada)";
			public EjecucionConRollback() : base(TextoError)
			{
			}
			public EjecucionConRollback(Exception inner) : base(TextoError, inner)
			{
			}
			public EjecucionConRollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Rollback : CondecoEX.db.BaseApplicationException
		{
            static string TextoError = "Problemas mientras se intentaba deshacer la ejecución del SQL script";
			public Rollback() : base(TextoError)
			{
			}
			public Rollback(Exception inner) : base(TextoError, inner)
			{
			}
			public Rollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}

	}
    namespace Permiso
    {
        [Serializable]
        public class BaseApplicationException : CondecoEX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class Existente : CondecoEX.db.BaseApplicationException
        {
            static string TextoError = "EL permiso ha sido revocado y está en este estado actual ";
            public Existente(string estado)
                : base(TextoError + " '" + estado + "'")
            {
            }
            public Existente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public Existente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class EstadoNoModificable : CondecoEX.db.BaseApplicationException
        {
            static string TextoError = "No está autorizado a cambiar el estado";
            public EstadoNoModificable(string estado)
                : base(TextoError + " '" + estado + "'")
            {
            }
            public EstadoNoModificable(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EstadoNoModificable(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace Lote
    {
        [Serializable]
        public class BaseApplicationException : CondecoEX.Validaciones.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    public static class Funciones
    {
        public static string Detalle(Exception ex)
        {
            System.Text.StringBuilder a = new System.Text.StringBuilder();
            a.Append(ex.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
            if (ex.InnerException != null)
            {
                a.Append(" (");
                a.Append(ex.InnerException.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
                a.Append(")");
            }
            return a.ToString();
        }
    }
}