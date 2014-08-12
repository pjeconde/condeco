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
                throw new CondecoEX.Validaciones.ValorNoInfo("User.Id");
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
                    if (Usuario.WF.Estado != "Active")
                    {
                        throw new CondecoEX.Usuario.LoginRechazadoXEstadoCuenta();
                    }
                }
            }
        }
        public static string TerminosYCondiciones()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("Términos y condiciones.");
            a.AppendLine("");
            a.AppendLine("El presente aviso legal, regula el uso del Portal Sitio Web, www.tangofamilyandguide.com.ar 'TFG' que Sergio Ramos, con domicilio en Argentina, Buenos Aires pone a disposición de los usuarios que deseen publicar sus clasificados en este sitio web.");
            a.AppendLine("Tango Family and Guide no se responsabiliza por la información que se publica en el sitio ni por los desacuerdos que puedan surgir entre las partes, ya que esta pagina es solamente una Guia de Clasificados en la cual  los usuarios publican su información.");
            a.AppendLine("La utilización del sitio TFG por parte del  usuario, implica la aceptación plena y sin reservas de todas y cada una de las disposiciones incluidas en este Aviso Legal, en la versión publicada por TFG en el momento mismo en que el Usuario acceda al Portal. EL USUARIO se abstendrá de realizar cualquier acto suponga cualquier tipo de perjuicio a la pagina web de Tango Family and Guide  y/o al resto de usuarios del mismo. En caso de incumplimiento de las obligaciones anteriores, Tango Family and Guide se reserva el derecho de denegar el acceso al Portal a dicho usuario.");
            a.AppendLine("");
            a.AppendLine("");
            a.AppendLine("Ley aplicable y jurisdicción competente");
            a.AppendLine("");
            a.AppendLine("El usuario acepta que la legislación aplicable al funcionamiento de este servicio es la Argentina y se somete a la jurisdicción de los juzgados y Tribunales de C.A.B.A para la resolución de las divergencias que se deriven de la interpretación o aplicación.");
            a.AppendLine("");
            a.AppendLine("");
            a.AppendLine("Propiedad intelectual");
            a.AppendLine("");
            a.AppendLine("Sergio Ramos es propietario del nombre de dominio Tango Family and Guide ");
            a.AppendLine("El sitio web Tango Family and Guide en su totalidad, incluyendo, su diseño, estructura y distribución, así como todos los derechos de propiedad  intelectual.");
            a.AppendLine("La violación de los derechos será penada con la legislación vigente.");
            a.AppendLine("Copyright Tango Family and Guide 2013");
            return a.ToString();
        }
        public static string TerminosYCondicionesHTML()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("<b>Términos y condiciones.</b>");
            a.AppendLine("<br/>");
            a.AppendLine("El presente aviso legal, regula el uso del Portal Sitio Web, www.tangofamilyandguide.com.ar 'TFG' que Sergio Ramos, con domicilio en Argentina, Buenos Aires pone a disposición de los usuarios que deseen publicar sus clasificados en este sitio web.");
            a.AppendLine("Tango Family and Guide no se responsabiliza por la información que se publica en el sitio ni por los desacuerdos que puedan surgir entre las partes, ya que esta pagina es solamente una Guia de Clasificados en la cual  los usuarios publican su información.");
            a.AppendLine("La utilización del sitio TFG por parte del  usuario, implica la aceptación plena y sin reservas de todas y cada una de las disposiciones incluidas en este Aviso Legal, en la versión publicada por TFG en el momento mismo en que el Usuario acceda al Portal. EL USUARIO se abstendrá de realizar cualquier acto suponga cualquier tipo de perjuicio a la pagina web de Tango Family and Guide  y/o al resto de usuarios del mismo. En caso de incumplimiento de las obligaciones anteriores, Tango Family and Guide se reserva el derecho de denegar el acceso al Portal a dicho usuario.");
            a.AppendLine("<br/>");
            a.AppendLine("<br/>");
            a.AppendLine("<b>Ley aplicable y jurisdicción competente</b>");
            a.AppendLine("<br/>");
            a.AppendLine("El usuario acepta que la legislación aplicable al funcionamiento de este servicio es la Argentina y se somete a la jurisdicción de los juzgados y Tribunales de C.A.B.A para la resolución de las divergencias que se deriven de la interpretación o aplicación.");
            a.AppendLine("<br/>");
            a.AppendLine("<br/>");
            a.AppendLine("<b>Propiedad intelectual</b>");
            a.AppendLine("<br/>");
            a.AppendLine("Sergio Ramos es propietario del nombre de dominio Tango Family and Guide ");
            a.AppendLine("El sitio web Tango Family and Guide en su totalidad, incluyendo, su diseño, estructura y distribución, así como todos los derechos de propiedad  intelectual.");
            a.AppendLine("La violación de los derechos será penada con la legislación vigente.");
            a.AppendLine("Copyright Tango Family and Guide 2013");
            return a.ToString();
        }
        public static void Validar(CondecoEntidades.Usuario Usuario, string ConfirmacionPassword, string ClaveCatpcha, string Clave, CondecoEntidades.Sesion Sesion)
        {
            if (Usuario.Nombre == String.Empty)
            {
                throw new CondecoEX.Validaciones.ValorNoInfo("First and Last Name");
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
                            throw new CondecoEX.Validaciones.ValorNoInfo("User.Id");
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
                                        throw new CondecoEX.Validaciones.ValorNoInfo("Re-enter Password");
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
                                                throw new CondecoEX.Validaciones.ValorNoInfo("Question");
                                            }
                                            else
                                            {
                                                if (Usuario.Respuesta == String.Empty)
                                                {
                                                    throw new CondecoEX.Validaciones.ValorNoInfo("Answer");
                                                }
                                                else
                                                {
                                                    if (!ClaveCatpcha.Equals(Clave.ToLower()))
                                                    {
                                                        throw new CondecoEX.Validaciones.ValorInvalido("Code");
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
            if (EnviarCorreo) CondecoRN.EnvioSMS.Enviar("New account " + CantidadDeFilas((CondecoEntidades.Sesion)Sesion).ToString(), Usuario.Nombre, usuario.DestinatariosAvisoAltaUsuario());
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
                throw new CondecoEX.Validaciones.ValorNoInfo("Current Password");
            }
            else
            {
                if (PasswordNueva == String.Empty)
                {
                    throw new CondecoEX.Validaciones.ValorNoInfo("New Password");
                }
                else
                {
                    if (ConfirmacionPasswordNueva == String.Empty)
                    {
                        throw new CondecoEX.Validaciones.ValorNoInfo("Re-enter Password");
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