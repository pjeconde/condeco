using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    [Serializable]
    public class Usuario
    {
        private string id;
        private string nombre;
        private string telefono;
        private string email;
        private string password;
        private string pregunta;
        private string respuesta;
        private int cantidadEnviosMail;
        private DateTime fechaUltimoReenvioMail;
        private string emailSMS;
        private string idMedio;
        private WF wF;
        private string ultActualiz;
        private List<Permiso> permisos;
        private string pais;                    //Country
        private string provincia;               //State
        private string localidad;               //City
        private string direccion;               //Address
        private string codPost;
        private string facebook;
        private string datoAdicional1;
        private string datoAdicional2;

        public Usuario()
        {
            wF = new WF();
            permisos = new List<Permiso>();
        }

        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public string Telefono
        {
            set
            {
                telefono = value;
            }
            get
            {
                return telefono;
            }
        }
        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        public string Pregunta
        {
            set
            {
                pregunta = value;
            }
            get
            {
                return pregunta;
            }
        }
        public string Respuesta
        {
            set
            {
                respuesta = value;
            }
            get
            {
                return respuesta;
            }
        }
        public int CantidadEnviosMail
        {
            set
            {
                cantidadEnviosMail = value;
            }
            get
            {
                return cantidadEnviosMail;
            }
        }
        public DateTime FechaUltimoReenvioMail
        {
            set
            {
                fechaUltimoReenvioMail = value;
            }
            get
            {
                return fechaUltimoReenvioMail;
            }
        }
        public string EmailSMS
        {
            set
            {
                emailSMS = value;
            }
            get
            {
                return emailSMS;
            }
        }
        public string IdMedio
        {
            set
            {
                idMedio = value;
            }
            get
            {
                return idMedio;
            }
        }
        public WF WF
        {
            set
            {
                wF = value;
            }
            get
            {
                return wF;
            }
        }
        public string UltActualiz
        {
            set
            {
                ultActualiz = value;
            }
            get
            {
                return ultActualiz;
            }
        }
        public List<Permiso> Permisos
        {
            set
            {
                permisos = value;
            }
            get
            {
                return permisos;
            }
        }
        public string Pais
        {
            set
            {
                pais = value;
            }
            get
            {
                return pais;
            }
        }
        public string Provincia
        {
            set
            {
                provincia = value;
            }
            get
            {
                return provincia;
            }
        }
        public string Localidad
        {
            set
            {
                localidad = value;
            }
            get
            {
                return localidad;
            }
        }
        public string Direccion
        {
            set
            {
                direccion = value;
            }
            get
            {
                return direccion;
            }
        }
        public string CodPost
        {
            set
            {
                codPost = value;
            }
            get
            {
                return codPost;
            }
        }
        public string Facebook
        {
            set
            {
                facebook = value;
            }
            get
            {
                return facebook;
            }
        }
        public string DatoAdicional1
        {
            set
            {
                datoAdicional1 = value;
            }
            get
            {
                return datoAdicional1;
            }
        }
        public string DatoAdicional2
        {
            set
            {
                datoAdicional2 = value;
            }
            get
            {
                return datoAdicional2;
            }
        }
        #region Propiedades redundantes
        public string Estado
        {
            get
            {
                return wF.Estado;
            }
        }
        #endregion
    }
}
