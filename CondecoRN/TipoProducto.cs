using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoRN
{
    public class TipoProducto
    {
        public static List<CondecoEntidades.TipoProducto> Lista(CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.TipoProducto db = new CondecoDB.TipoProducto(Sesion);
            return db.LeerLista();
        }
    }
}
