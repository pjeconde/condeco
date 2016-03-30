using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuscarDirectoButton_Click(object sender, EventArgs e)
        {
            Session["ListaTipoProducto"] = Funciones.ListaDeProducto(((LinkButton)sender).CommandName);
            Response.Redirect("Producto.aspx");
        }
    }
}
