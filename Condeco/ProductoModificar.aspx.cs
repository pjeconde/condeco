using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Geekees.Common.Utilities.Xml;
using Geekees.Common.Controls;

namespace Condeco
{
    public partial class ProductoModificar : System.Web.UI.Page
    {
        private CondecoEntidades.Producto producto;

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
                        return p.TipoPermiso.Id == "OperProductos" && p.Estado == "Vigente";
                    });
                    if (permisoHabilitado.Count == 0)
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    EstadoDropDownList.DataSource = CondecoEntidades.Estados.ListaEstados.ListaMasSinInformar();
                    
                    NombreTextBox.Focus();
                    DataBind();

                    producto = (CondecoEntidades.Producto)Session["Producto"];

                    IdProductoLabel.Text = producto.Id.ToString();
                    EstadoActualLabel.Text = "Estado actual: " + producto.Estado;
                    
                    NombreTextBox.Text = producto.Nombre;
                    DescripcionTextBox.Text = producto.Descripcion;
                    DescripcionCortaTextBox.Text = producto.DescripcionCorta;
                    PrecioBaseTextBox.Text = producto.PrecioBase.ToString();
                    ComentarioPrecioBaseTextBox.Text = producto.ComentarioPrecioBase;

                    YouTubeTextBox.Text = producto.YouTube;
                    EstadoDropDownList.SelectedValue = producto.Estado;

                    Funciones.GenerarTreeTipoProductos(astvMyTree, false);
 
                    NombreTextBox.Focus();
                    DataBind();
                    this.astvMyTree.ContextMenu.MenuItems.Add(new ASContextMenuItem("Custom Menu", "alert('current value:' + " + this.astvMyTree.ContextMenuClientID + ".getSelectedItem().parentNode.getAttribute('treeNodeValue')" + ");return false;", "text"));

                }
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] a = new string[1];
                a[0] = producto.IdTipoProducto.ToString();
                astvMyTree.CheckNodes(a);
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
                CondecoEntidades.Producto productoDesde = (CondecoEntidades.Producto)Session["Producto"];
                CondecoEntidades.Producto productoHasta = CondecoRN.Producto.ObtenerCopia(productoDesde);
                try
                {
                    productoHasta.Id = Convert.ToInt32(IdProductoLabel.Text);
                    productoHasta.Nombre = NombreTextBox.Text;
                    productoHasta.Descripcion = DescripcionTextBox.Text;
                    productoHasta.DescripcionCorta = DescripcionCortaTextBox.Text;
                    productoHasta.IdMoneda = "$";
                    productoHasta.PrecioBase = Convert.ToDecimal(PrecioBaseTextBox.Text);
                    productoHasta.ComentarioPrecioBase = ComentarioPrecioBaseTextBox.Text;

                    productoHasta.YouTube = YouTubeTextBox.Text;
                    string listaTipoProductos = Funciones.TreeViewListaChilds(astvMyTree);
                    if (listaTipoProductos != "")
                    {
                        productoHasta.TipoProducto.Id = Convert.ToInt32(listaTipoProductos);
                    }
                    CondecoRN.Producto.Modificar(productoDesde, productoHasta, sesion);

                    NombreTextBox.Enabled = false;
                    DescripcionTextBox.Enabled = false;
                    PrecioBaseTextBox.Enabled = false;
                    ComentarioPrecioBaseTextBox.Enabled = false;
                    YouTubeTextBox.Enabled = false;
                    EstadoDropDownList.Enabled = false;
                    astvMyTree.Enabled = false;
                    astvMyTree.EnableNodeSelection = false;
                    TipoProductoPanel.Enabled = false;
                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "Modificación satisfactoria. ";
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