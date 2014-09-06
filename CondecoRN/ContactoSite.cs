using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace CondecoRN
{
    public class ContactoSite
    {
        public static void Validar(CondecoEntidades.ContactoSite ContactoSite, string ClaveCatpcha, string Clave)
        {
            if (ContactoSite.Motivo == String.Empty)
            {
                throw new CondecoEX.Validaciones.ValorNoInfo("Subject");
            }
            else
            {
                if (ContactoSite.Nombre == String.Empty)
                {
                    throw new CondecoEX.Validaciones.ValorNoInfo("Name");
                }
                else
                {
                    if (ContactoSite.Email == String.Empty)
                    {
                        throw new CondecoEX.Validaciones.ValorNoInfo("Email");
                    }
                    else
                    {
                        if (!Funciones.EsEmail(ContactoSite.Email))
                        {
                            throw new CondecoEX.Validaciones.ValorInvalido("Email");
                        }
                        else
                        {
                            if (ContactoSite.Mensaje == String.Empty)
                            {
                                throw new CondecoEX.Validaciones.ValorNoInfo("Message");
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
        public static void Registrar(CondecoEntidades.ContactoSite ContactoSite)
        {
            string cuentaMailCondeco;
            if (ContactoSite.Motivo == "Producto")
            {
                cuentaMailCondeco = System.Configuration.ConfigurationManager.AppSettings["ContactoMailMotivoProdcuto"];
            }
            else
            {
                cuentaMailCondeco = System.Configuration.ConfigurationManager.AppSettings["ContactoMailMotivoOtro"];
            }
            CondecoRN.EnvioCorreo.ContactoSite(ContactoSite, cuentaMailCondeco);
        }
    }
}
