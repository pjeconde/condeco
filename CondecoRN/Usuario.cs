using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaptchaDotNet2.Security.Cryptography;

namespace CondecoRN
{
    public class Usuario
    {
        public static void Leer(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Usuario db = new CondecoDB.Usuario(Sesion);
            db.Leer(Usuario);
        }
        public static void Login(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            if (Usuario.Id == String.Empty)
            {
                throw new CondecoEX.Validaciones.ValorNoInfo("Usuario de ingreso");
            }
            else
            {
                if (Usuario.Password == String.Empty)
                {
                    throw new CondecoEX.Validaciones.ValorNoInfo("Password");
                }
                else
                {
                    string passwordIngresada = Usuario.Password;
                    Leer(Usuario, Sesion);
                    if (passwordIngresada != Usuario.Password)
                    {
                        throw new CondecoEX.Usuario.LoginRechazadoXPasswordInvalida();
                    }
                    //Se impide el login a cuenta pendientes de confirmacion o dadas de baja
                    //(las cuentas "Prem" suspendidas se comportan como cuentas "Free")
                    if (Usuario.WF.Estado != "Vigente")
                    {
                        throw new CondecoEX.Usuario.LoginRechazadoXEstadoCuenta();
                    }
                }
            }
        }
        public static string TerminosYCondiciones()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            //a.AppendLine("Términos y condiciones.");
            a.AppendLine("");
            return a.ToString();
        }
        public static string TerminosYCondicionesHTML()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            //a.AppendLine("<b>Términos y condiciones.</b>");
            a.AppendLine("");
            return a.ToString();
        }
        public static void Validar(CondecoEntidades.Usuario Usuario, string ConfirmacionPassword, string ClaveCatpcha, string Clave, CondecoEntidades.Sesion Sesion)
        {
            if (Usuario.Nombre == String.Empty)
            {
                throw new CondecoEX.Validaciones.ValorNoInfo("Nombre y Apellido");
            }
            else
            {
                if (Usuario.Email == String.Empty)
                {
                    throw new CondecoEX.Validaciones.ValorNoInfo("Email");
                }
                else
                {
                    if (!CondecoRN.Funciones.EsEmail(Usuario.Email))
                    {
                        throw new CondecoEX.Validaciones.ValorInvalido("Email");
                    }
                    else
                    {
                        if (Usuario.Id == String.Empty)
                        {
                            throw new CondecoEX.Validaciones.ValorNoInfo("Usuario de Ingreso");
                        }
                        else
                        {
                            if (!IdCuentaDisponible(Usuario, Sesion))
                            {
                                throw new CondecoEX.Usuario.IdUsuarioNoDisponible();
                            }
                            else
                            {
                                if (Usuario.Password == String.Empty)
                                {
                                    throw new CondecoEX.Validaciones.ValorNoInfo("Password");
                                }
                                else
                                {
                                    if (ConfirmacionPassword == String.Empty)
                                    {
                                        throw new CondecoEX.Validaciones.ValorNoInfo("Reingresar Password");
                                    }
                                    else
                                    {
                                        if (Usuario.Password != ConfirmacionPassword)
                                        {
                                            throw new CondecoEX.Usuario.PasswordYConfirmacionNoCoincidente();
                                        }
                                        else
                                        {
                                            if (Usuario.Pregunta == String.Empty)
                                            {
                                                throw new CondecoEX.Validaciones.ValorNoInfo("Pregunta de seguridad");
                                            }
                                            else
                                            {
                                                if (Usuario.Respuesta == String.Empty)
                                                {
                                                    throw new CondecoEX.Validaciones.ValorNoInfo("Respuesta de seguridad");
                                                }
                                                else
                                                {
                                                    if (!ClaveCatpcha.Equals(Clave.ToLower()))
                                                    {
                                                        throw new CondecoEX.Validaciones.ValorInvalido("Codigo");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Registrar(CondecoEntidades.Usuario Usuario, bool EnviarCorreo, CondecoEntidades.Sesion Sesion)
        {
            Usuario.WF.Estado = "PteConf";
            CondecoDB.Usuario usuario = new CondecoDB.Usuario(Sesion);
            usuario.Crear(Usuario);
            if (EnviarCorreo) CondecoRN.EnvioCorreo.ConfirmacionAltaUsuario(Usuario);
        }
        public static void EnviarSoloEmailConfirmacionAltaUsuario(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            CondecoRN.EnvioCorreo.ConfirmacionAltaUsuario(Usuario);
        }
        public static void Confirmar(CondecoEntidades.Usuario Usuario, bool DesencriptarUsuario, bool EnviarCorreo, CondecoEntidades.Sesion Sesion)
        {
            if (DesencriptarUsuario) Usuario.Id = Encryptor.Decrypt(Usuario.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Leer(Usuario, (CondecoEntidades.Sesion)Sesion);
            CondecoDB.Usuario usuario = new CondecoDB.Usuario((CondecoEntidades.Sesion)Sesion);
            usuario.Confirmar(Usuario);
            Leer(Usuario, (CondecoEntidades.Sesion)Sesion);
            if (EnviarCorreo) CondecoRN.EnvioSMS.Enviar("Nueva cuenta " + CantidadDeFilas((CondecoEntidades.Sesion)Sesion).ToString(), Usuario.Nombre, usuario.DestinatariosAvisoAltaUsuario());
        }
        public static bool IdCuentaDisponible(CondecoEntidades.Usuario Usuario, CondecoEntidades.Sesion Sesion)
        {
            if (Usuario.Id == String.Empty)
            {
                throw new CondecoEX.Validaciones.ValorNoInfo("User.Id");
            }
            else
            {
                try
                {
                    CondecoDB.Usuario usuario = new CondecoDB.Usuario(Sesion);
                    return usuario.IdUsuarioDisponible(Usuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static int CantidadDeFilas(CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Usuario usuario = new CondecoDB.Usuario(Sesion);
            return usuario.CantidadDeFilas();
        }
        public static void CambiarPassword(CondecoEntidades.Usuario Usuario, string PasswordActual, string PasswordNueva, string ConfirmacionPasswordNueva, CondecoEntidades.Sesion Sesion)
        {
            if (PasswordActual == String.Empty)
            {
                throw new CondecoEX.Validaciones.ValorNoInfo("Password Actual");
            }
            else
            {
                if (PasswordNueva == String.Empty)
                {
                    throw new CondecoEX.Validaciones.ValorNoInfo("Nueva Password");
                }
                else
                {
                    if (ConfirmacionPasswordNueva == String.Empty)
                    {
                        throw new CondecoEX.Validaciones.ValorNoInfo("Reingresar Password");
                    }
                    else
                    {
                        if (Usuario.Password != PasswordActual)
                        {
                            throw new CondecoEX.Usuario.PasswordNoMatch();
                        }
                        else
                        {
                            if (PasswordNueva != ConfirmacionPasswordNueva)
                            {
                                throw new CondecoEX.Usuario.PasswordYConfirmacionNoCoincidente();
                            }
                            else
                            {
                                if (Usuario.Password == PasswordNueva)
                                {
                                    throw new CondecoEX.Usuario.PasswordNuevaIgualAActual();
                                }
                                else
                                {
                                    CondecoDB.Usuario usuario = new CondecoDB.Usuario(Sesion);
                                    usuario.CambiarPassword(Usuario, PasswordNueva);
                                }
                            }
                        }
                    }
                }
            }
        }
        public static string ListaIdUsuariosParaSQLscript(CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Usuario usuario = new CondecoDB.Usuario(Sesion);
            return usuario.ListaIdUsuariosParaSQLscript();
        }
        public static List<CondecoEntidades.Usuario> Lista(string IdUsuario, string Nombre, string Estado, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Usuario usuario = new CondecoDB.Usuario(Sesion);
            return usuario.Lista(IdUsuario, Nombre, Estado);
        }
        public static void CambiarEstado(CondecoEntidades.Usuario Usuario, string Evento, string IdEstadoHst, CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Usuario db = new CondecoDB.Usuario(Sesion);
            db.CambioEstado(Usuario, Evento, IdEstadoHst);
        }
    }
}