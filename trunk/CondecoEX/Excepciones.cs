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
            static string TextoError = "Without informing";
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
            static string TextoError = "Invalid value";
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
            static string TextoError = "Non-existent";
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
            static string TextoError = "Exists";
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
            static string TextoError = "With this image would exceed the maximum allowed.";
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
            static string TextoError = "The password does not match with your confirmation";
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
            static string TextoError = "The new password must not be equal to the current";
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
            static string TextoError = "The User.Id, you entered has already been used by another person. Modify it to find a unique value.";
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
            static string TextoError = "The confirmation event (account creation) can not be executed. It is likely that the confirmation has already been registered. Verify that you can enter. In contrast step, contact Tango Family and Guide, to fix the problem. Thank you very much.";
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
            static string TextoError = "Login wrong (the account is pending confirmation o canceled)";
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
            static string TextoError = "Password invalid";
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
            static string TextoError = "There are no accounts associated with the email address specified";
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
            static string TextoError = "The confirmation message (from account creation) wrong format. Please contact Tango Family and Guide, to fix the problem. Thank you very much.";
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
            static string TextoError = "Incorrect password";
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
            static string TextoError = "Problem connecting to database";
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
            static string TextoError = "Problem running SQL script";
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
            static string TextoError = "Problem running SQL script (the operation is disposed)";
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
            static string TextoError = "Problem while trying to undo the execution of a SQL script";
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
            static string TextoError = "This permission has been requested and is in status ";
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
            static string TextoError = "Not authorized to change the status";
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