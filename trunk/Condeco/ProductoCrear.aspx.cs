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
                        return p.TipoPermiso.Id == "OperProductos" && p.Estado == "Vigente";
                    });
                    if (permisoHabilitado.Count == 0)
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    NombreTextBox.Focus();
                    EstadoDropDownList.DataSource = CondecoEntidades.Estados.ListaEstados.ListaMasSinInformar();
                    Funciones.GenerarTreeTipoProductos(astvMyTree, false);

                    DataBind();

                    this.astvMyTree.ContextMenu.MenuItems.Add(new ASContextMenuItem("Custom Menu", "alert('current value:' + " + this.astvMyTree.ContextMenuClientID + ".getSelectedItem().parentNode.getAttribute('treeNodeValue')" + ");return false;", "text"));
                }
            }
        }

        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
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
                    ValidarCampos();
                    if (MensajeLabel.Text != "") { return; }
                    Producto.Nombre= NombreTextBox.Text.Trim();
                    Producto.Descripcion = DescripcionTextBox.Text.Trim();
                    Producto.DescripcionCorta = DescripcionCortaTextBox.Text.Trim();
                    Producto.PrecioBase = Convert.ToDecimal(PrecioBaseTextBox.Text);
                    Producto.ComentarioPrecioBase = ComentarioPrecioBaseTextBox.Text;
                    Producto.YouTube = YouTubeTextBox.Text;
                    Producto.IdMoneda = "$";
                    string listaTipoProductos = Funciones.TreeViewListaChilds(astvMyTree);
                    if (listaTipoProductos != "")
                    {
                        Producto.TipoProducto.Id = Convert.ToInt32(listaTipoProductos);
                    }
                    Producto.Ranking = 0;
                    Producto.WF.Estado = EstadoDropDownList.SelectedValue;
                    if (CondecoRN.Producto.ComprobarNombreProducto(Producto.Nombre, sesion))
                    {
                        MensajeLabel.Text = "Hay un producto con un nombre similar, modifique parte del texto. ";
                    }
                    else
                    {
                        int IdProducto = 0;
                        CondecoRN.Producto.Crear(out IdProducto, Producto, sesion);

                        NombreTextBox.Enabled = false;
                        DescripcionTextBox.Enabled = false;
                        DescripcionCortaTextBox.Enabled = false;
                        PrecioBaseTextBox.Enabled = false;
                        ComentarioPrecioBaseTextBox.Enabled = false;
                        YouTubeTextBox.Enabled = false;
                        EstadoDropDownList.Enabled = false;
                        AceptarButton.Enabled = false;
                        SalirButton.Text = "Salir";

                        Funciones.PersonalizarControlesMaster(Master, true, sesion);
                        MensajeLabel.Text = "Alta satisfactoria. ";
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
        private void ValidarCampos()
        {
            try
            {
                if (EstadoDropDownList.SelectedValue == "")
                {
                    MensajeLabel.Text = "Seleccione el tipo de producto";
                    return;
                }
                string listaTipoProductosChilds = Funciones.TreeViewListaChilds(astvMyTree);
                if (listaTipoProductosChilds == "")
                {
                    MensajeLabel.Text = "Seleccione el tipo de producto";
                    return;
                }
                else
                {
                    string[] l = listaTipoProductosChilds.Split(Convert.ToChar(","));
                    if (l.Length > 1)
                    {
                        MensajeLabel.Text = "Seleccione solamente un tipo de producto";
                        return;
                    }
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