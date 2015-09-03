using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    [Serializable]
    public class Permiso
    {
        private Usuario usuario;
        private TipoPermiso tipoPermiso;
        private DateTime fechaFinVigencia;
        private WF wF;

        public Permiso()
        {
            usuario = new Usuario();
            tipoPermiso = new TipoPermiso();
            wF = new WF();
        }

        public Usuario Usuario
        {
            set
            {
                usuario = value;
            }
            get
            {
                return usuario;
            }
        }
        public TipoPermiso TipoPermiso
        {
            set
            {
                tipoPermiso = value;
            }
            get
            {
                return tipoPermiso;
            }
        }
        public DateTime FechaFinVigencia
        {
            set
            {
                fechaFinVigencia = value;
            }
            get
            {
                return fechaFinVigencia;
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
        #region Propiedades redundantes
        public string Estado
        {
            get
            {
                return wF.Estado;
            }
        }
        public string IdTipoPermiso
        {
            get
            {
                return tipoPermiso.Id;
            }
        }
        public string DescrTipoPermiso
        {
            get
            {
                return tipoPermiso.Descr;
            }
        }
        public string IdUsuario
        {
            get
            {
                return usuario.Id;
            }
        }
        public string NombreUsuario
        {
            get
            {
                return usuario.Nombre;
            }
        }
        #endregion
    }
}