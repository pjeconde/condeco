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
                    DetalleLabel.Text = "Modificar Producto";
                    break;
                case "Productos":
                    DetalleLabel.Text = "Imagenes Producto";
                    break;
            }
        }
    }
}