using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace Condeco
{
    public partial class Pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CondecoEntidades.Sesion sesion;
            if (!IsPostBack)
            {
                sesion = (CondecoEntidades.Sesion)Session["Sesion"];
            }
        }
    }
}