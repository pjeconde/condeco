using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    [Serializable]
    public class Sesion : ICloneable
    {
		private string cnnStr;
		private Usuario usuario;
        //private List<Milonga> milongasDelUsuario;
        private List<string> opcionesHabilitadas;
        private DateTime fechaInicio;

        public Sesion()
        {
            usuario = new Usuario();
            //milongasDelUsuario = new List<Milonga>();
            opcionesHabilitadas = new List<string>();
            fechaInicio = DateTime.Now;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

		public string CnnStr
		{
			get
			{
				return cnnStr;
			}
			set
			{
				cnnStr = value;
			}
		}
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }
        //public List<Milonga> MilongasDelUsuario
        //{
        //    get
        //    {
        //        return milongasDelUsuario;
        //    }
        //    set
        //    {
        //        milongasDelUsuario = value;
        //    }
        //}
        public List<string> OpcionesHabilitadas
        {
            get
            {
                return opcionesHabilitadas;
            }
            set
            {
                opcionesHabilitadas = value;
            }
        }
        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }
            set
            {
                fechaInicio = value;
            }
        }
    }
}