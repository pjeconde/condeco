using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class ProductoCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    List<CondecoEntidades.Permiso> permisoHabilitado = sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "OperProducto" && p.Estado == "Active";
                    });
                    if (permisoHabilitado.Count == 0)
                    {
                        Response.Redirect("~/Home.aspx");
                    }

                    NombreTextBox.Focus();
                    //TipoProductoDropDownList.DataSource = CondecoEntidades.TiposProducto.TipoProducto.ListaMasSinInformar();

                    DataBind();
                }
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                CondecoEntidades.Producto Producto = new CondecoEntidades.Producto();
                try
                {
                    Producto.Nombre= NombreTextBox.Text.Trim();
                    Producto.Descripcion = DescripcionTextBox.Text.Trim();
                    Producto.PrecioBase = Convert.ToDecimal(PrecioBaseTextBox.Text);
                    //Producto.TipoProducto = TipoProductoDropDownList.Text;
                    Producto.Ranking = 0;
                    if (CondecoRN.Producto.ComprobarNombreProducto(Producto.Nombre, sesion))
                    {
                        MensajeLabel.Text = "There is already a Producto with a same name, modify the data. ";
                    }
                    else
                    {
                        int IdProducto = 0;
                        CondecoRN.Producto.Crear(out IdProducto, Producto, sesion);

                        NombreTextBox.Enabled = false;
                        DescripcionTextBox.Enabled = false;
                        PrecioBaseTextBox.Enabled = false;
                        ComentarioPrecioBaseTextBox.Enabled = false;
                        EmailTextBox.Enabled = false;
                        WebSiteTextBox.Enabled = false;
                        FacebookTextBox.Enabled = false;
                        GoogleMapTextBox.Enabled = false;
                        TipoProductoDropDownList.Enabled = false;
                        TipoMusicaDropDownList.Enabled = false;
                        TipoPisoDropDownList.Enabled = false;
                        ComentariosTextBox.Enabled = false;
                        AceptarButton.Enabled = false;
                        SalirButton.Text = "Salir";

                        Funciones.PersonalizarControlesMaster(Master, true, sesion);
                        MensajeLabel.Text = "There was successfully. ";
                        if (IdProducto != 0)
                        {
                            MensajeLabel.Text = MensajeLabel.Text + "Id: " + IdProducto;
                        }
                        Producto.Id = IdProducto;
                        Session["Producto"] = Producto;
                        Response.Redirect("~/ProductoImagenes.aspx");
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                    return;
                }
            }
        }
    }
}