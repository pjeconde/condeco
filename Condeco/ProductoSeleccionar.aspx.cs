using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Condeco
{
    public partial class ProductoSeleccionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
                    switch (a)
                    {
                        case "Modificar":
                            TituloPaginaLabel.Text = "Modificar Producto";
                            ViewState["IrA"] = "~/ProductoModificar.aspx";
                            break;
                        case "Imagenes":
                            TituloPaginaLabel.Text = "Imagenes Producto";
                            ViewState["IrA"] = "~/ProductoImagenes.aspx";
                            break;
                    }
                    DataBind();
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        NombreRadioButton.Checked = true;
                        TipoBusquedaRadioButton_CheckedChanged(NombreRadioButton, new EventArgs());
                        NombreTextBox.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
                MensajeLabel.Text = String.Empty;
                if (IdProductoRadioButton.Checked)
                {
                    if (IdProductoTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = "No informado " + IdProductoRadioButton.Text + ".";
                        return;
                    }
                    else
                    {
                        try
                        {
                            lista = CondecoRN.Producto.ListaPorIdProducto(Convert.ToInt32(IdProductoTextBox.Text), sesion);
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    if (NombreTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = "No informado " + NombreRadioButton.Text + ".";
                        return;
                    }
                    else
                    {
                        lista = CondecoRN.Producto.ListaPorNombre(NombreTextBox.Text, sesion);
                    }
                }
                if (lista.Count == 0)
                {
                    ProductosGridView.DataSource = null;
                    ProductosGridView.DataBind();
                    MensajeLabel.Text = "No hay registros disponible para la selección. ";
                }
                else if (lista.Count == 1)
                {
                    Session["Producto"] = lista[0];
                    Response.Redirect(ViewState["IrA"].ToString());
                }
                else
                {
                    ProductosGridView.DataSource = lista;
                    ViewState["Productos"] = lista;
                    ProductosGridView.DataBind();
                }
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ProductosGridView.DataSource = null;
            ProductosGridView.DataBind();
            MensajeLabel.Text = String.Empty;
            if (IdProductoRadioButton.Checked)
            {
                NombreTextBox.Text = String.Empty;
                NombreTextBox.Visible = false;
                IdProductoTextBox.Visible = true;
            }
            else
            {
                IdProductoTextBox.Text = String.Empty;
                IdProductoTextBox.Visible = false;
                NombreTextBox.Visible = true;
            }
        }
        protected void ProductosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<CondecoEntidades.Producto> lista = (List<CondecoEntidades.Producto>)ViewState["Productos"];
            CondecoEntidades.Producto producto = lista[item];
            switch (e.CommandName)
            {
                case "Seleccionar":
                    Session["Producto"] = producto;
                    Response.Redirect(ViewState["IrA"].ToString());
                    break;
            }
        }
        protected void ProductosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
    }
}