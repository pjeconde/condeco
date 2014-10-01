using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    [Serializable]
    public class Producto
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string idMoneda;
        private decimal precioBase;
        private string comentarioPrecioBase;
        private WF wF;
        private TipoProducto tipoProducto;
        private int ranking;
        private string tipoDestacado;
        private string ultActualiz;
        private string youTube;
        private string nombreImagenPortada;

        public Producto()
        {
            wF = new WF();
            TipoProducto = new TipoProducto();
        }

        public int Id
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
        public string Descripcion
        {
            set
            {
                descripcion = value;
            }
            get
            {
                return descripcion;
            }
        }
        public string IdMoneda
        {
            set
            {
                idMoneda = value;
            }
            get
            {
                return idMoneda;
            }
        }
        public decimal PrecioBase
        {
            set
            {
                precioBase = value;
            }
            get
            {
                return precioBase;
            }
        }
        public string ComentarioPrecioBase
        {
            set
            {
                comentarioPrecioBase = value;
            }
            get
            {
                return comentarioPrecioBase;
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
        public TipoProducto TipoProducto
        {
            set
            {
                tipoProducto = value;
            }
            get
            {
                return tipoProducto;
            }
        }
        public int IdTipoProducto
        {
            get
            {
                return tipoProducto.Id;
            }
        }
        public int Ranking
        {
            set
            {
                ranking = value;
            }
            get
            {
                return ranking;
            }
        }
        public string TipoDestacado
        {
            set
            {
                tipoDestacado = value;
            }
            get
            {
                return tipoDestacado;
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
        public string YouTube
        {
            set
            {
                youTube = value;
            }
            get
            {
                return youTube;
            }
        }
        public string NombreImagenPortada
        {
            set
            {
                nombreImagenPortada = value;
            }
            get
            {
                return nombreImagenPortada;
            }
        }

        #region Virtuales
        public string Estado
        {
            get
            {
                return wF.Estado;
            }
        }
        public int IdWF
        {
            get
            {
                return wF.Id;
            }
        }
        #endregion
    }
}
