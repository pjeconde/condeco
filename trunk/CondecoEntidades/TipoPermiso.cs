﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoEntidades
{
    [Serializable]
    public class TipoPermiso
    {
        private string id;
        private string descr;

        public TipoPermiso()
        {
        }

        public TipoPermiso(string IdTipoPermiso)
        {
            id = IdTipoPermiso;
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
