﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    [Serializable]
    public class Estado
    {
        private string id;
        private string descr;

        public Estado()
        {
        }

        public Estado(string IdEstado, string DescrEstado)
        {
            id = IdEstado;
            descr = DescrEstado;
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
        public string Descr
        {
            set
            {
                descr = value;
            }
            get
            {
                return descr;
            }
        }
    }
}
