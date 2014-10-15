using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class Mensaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
            switch (a)
            {
                case "Login":
                    DetalleLabel.Text = "Próximamente esta página le permitirá a usted ser usuario de nuestro sitio web y acceder a las novedades y promociones vigentes.";
                    break;
                case "Productos":
                    DetalleLabel.Text = "Próximamente esta página le permitirá a usted buscar y visualizar los productos que ofrecemos.";
                    break;
            }
        }
    }
}