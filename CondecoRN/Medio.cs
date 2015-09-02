using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondecoRN
{
    public class Medio
    {
        public static List<CondecoEntidades.Medio> Lista(CondecoEntidades.Sesion Sesion)
        {
            CondecoDB.Medio db = new CondecoDB.Medio(Sesion);
            return db.LeerLista();
        }
    }
}
