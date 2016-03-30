using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Condeco
{
    public partial class ExploradorProducto : System.Web.UI.Page
    {
        List<CondecoEntidades.Producto> producto = new List<CondecoEntidades.Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            CondecoEntidades.Sesion sesion;
            if (!IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    DataBind();
                }
                NombreRadioButton.Checked = true;
                TipoBusquedaRadioButton_CheckedChanged(NombreRadioButton, new EventArgs());
                NombreTextBox.Focus();
            }
            sesion = (CondecoEntidades.Sesion)Session["Sesion"];
            List<CondecoEntidades.Permiso> permisoAdminSITEActive = sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminSITE";
            });
            if (permisoAdminSITEActive.Count == 0)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void ProductosPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                ProductosPagingGridView.PageIndex = e.NewPageIndex;
                List<CondecoEntidades.Producto> lista;
                int CantidadFilas = 0;
                if (IdProductoRadioButton.Checked)
                {
                    lista = CondecoRN.Producto.ListaPorIdProducto(Convert.ToInt32(IdProductoTextBox.Text), (CondecoEntidades.Sesion)Session["Sesion"]);
                    CantidadFilas = lista.Count;
                }
                else
                {
                    lista = CondecoRN.Producto.ListaAdmin(out CantidadFilas, ProductosPagingGridView.PageIndex, ProductosPagingGridView.PageSize, ProductosPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, "", Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                }
                ProductosPagingGridView.VirtualItemCount = CantidadFilas;
                ViewState["lista"] = lista;
                ProductosPagingGridView.DataSource = lista;
                ProductosPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                //CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void ProductosPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
                int CantidadFilas = 0;
                lista = CondecoRN.Producto.ListaAdmin(out CantidadFilas, ProductosPagingGridView.PageIndex, ProductosPagingGridView.PageSize, ProductosPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, "", Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ProductosPagingGridView.DataSource = (List<CondecoEntidades.Producto>)ViewState["lista"];
                ProductosPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                //CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void ProductosPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                
                //Color por estado distinto a Active
                if (e.Row.Cells[7].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                DropDownList ddlTipoDestacado = (DropDownList)e.Row.FindControl("ddlTipoDestacado");
                if (ddlTipoDestacado != null)
                {
                    ddlTipoDestacado.DataSource = CondecoEntidades.TiposDestacado.TipoDestacado.ListaMasSinInformar();
                    ddlTipoDestacado.DataBind();
                    ddlTipoDestacado.SelectedValue = ProductosPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                }
            }
        }
        private void DesSeleccionarFilas()
        {
            ProductosPagingGridView.SelectedIndex = -1;
        }

        protected void ProductosPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = 0;
            try
            {
                item = Convert.ToInt32(e.CommandArgument);
                List<CondecoEntidades.Producto> lista = (List<CondecoEntidades.Producto>)ViewState["lista"];
                CondecoEntidades.Producto producto = lista[item];
                switch (e.CommandName)
                {
                    case "Detalle":
                        Session["Producto"] = producto;
                        Response.Redirect("~/ProductoConsultaDetallada.aspx");
                        break;
                    case "CambiarEstado":
                        Session["Producto"] = producto;
                        CondecoEntidades.Evento Evento;
                        CondecoRN.Producto.EventoPosible(out Evento, producto, (CondecoEntidades.Sesion)Session["Sesion"]);
                        TituloConfirmacionLabel.Text = "Confirmar " + Evento.DescrEvento;
                        NombreLabel.Text = producto.Nombre;
                        DescripcionLabel.Text = producto.Descripcion;
                        EstadoLabel.Text = producto.WF.Estado;
                        ViewState["Producto"] = producto;
                        ModalPopupExtender1.Show();
                        break;
                    case "Modificar":
                        Session["Producto"] = producto;
                        //Response.Redirect("~/ProductoModificar.aspx", false);
                        string script = "window.open('/ProductoModificar.aspx', '');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                        break;
                }
            }
            catch
            {
            }
        }
        protected void ProductosPagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProductosPagingGridView.EditIndex = e.NewEditIndex;
            int IndexAux = ProductosPagingGridView.CurrentPageIndex;
            ProductosPagingGridView.DataSource = ViewState["lista"];
            ProductosPagingGridView.CurrentPageIndex = IndexAux;
            ProductosPagingGridView.DataBind();
        }
        protected void ProductosPagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ProductosPagingGridView.EditIndex = -1;
            int IndexAux = ProductosPagingGridView.CurrentPageIndex;
            ProductosPagingGridView.DataSource = ViewState["lista"];
            ProductosPagingGridView.CurrentPageIndex = IndexAux;
            ProductosPagingGridView.DataBind();
        }
        protected void ProductosPagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                List<CondecoEntidades.Producto> productos = ((List<CondecoEntidades.Producto>)ViewState["lista"]);
                CondecoEntidades.Producto productoActual = CondecoRN.Producto.ObtenerCopia(productos[e.RowIndex]);
                CondecoEntidades.Producto producto = productos[e.RowIndex];

                string ranking = ((TextBox)ProductosPagingGridView.Rows[e.RowIndex].FindControl("txtRanking")).Text;
                string tipoDestacado = ((DropDownList)ProductosPagingGridView.Rows[e.RowIndex].FindControl("ddlTipoDestacado")).SelectedValue;
                if (ranking != string.Empty)
                {
                    producto.Ranking = Convert.ToInt32(ranking);
                }
                else
                {
                    throw new Exception("Debe informar el ranking. No puede estar vacío.");
                }
                producto.TipoDestacado = tipoDestacado;
                CondecoRN.Producto.Modificar(productoActual, producto, (CondecoEntidades.Sesion)Session["Sesion"]);
                ProductosPagingGridView.EditIndex = -1;
                int IndexAux = ProductosPagingGridView.CurrentPageIndex;
                ProductosPagingGridView.DataSource = ViewState["lista"];
                ProductosPagingGridView.CurrentPageIndex = IndexAux;
                ProductosPagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
        protected void ProductosPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ProductosPagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }

        protected void CambiarEstadoButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                try
                {
                    CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    CondecoEntidades.Producto producto = (CondecoEntidades.Producto)ViewState["Producto"];
                    CondecoEntidades.Evento Evento;
                    CondecoRN.Producto.EventoPosible(out Evento, producto, sesion);
                    CondecoRN.Producto.CambiarEstado(producto, Evento.Id, Evento.EstadoHst, sesion);
                    BuscarButton_Click(BuscarButton, new EventArgs());
                    Funciones.PersonalizarControlesMaster(Master, true, sesion);
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = "Problemas al cambiar el estado del Producto." + ex.Message;
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
                MensajeLabel.Text = String.Empty;
                List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
                int CantidadFilas = 0;
                if (IdProductoRadioButton.Checked)
                {
                    if (IdProductoTextBox.Text == string.Empty)
                    {
                        MensajeLabel.Text = "No se han encontrado Productos que satisfagan la busqueda";
                    }
                    else
                    {
                        lista = CondecoRN.Producto.ListaPorIdProducto(Convert.ToInt32(IdProductoTextBox.Text), (CondecoEntidades.Sesion)Session["Sesion"]);
                        CantidadFilas = lista.Count;
                    }
                }
                else
                {
                    lista = CondecoRN.Producto.ListaAdmin(out CantidadFilas, ProductosPagingGridView.PageIndex, ProductosPagingGridView.PageSize, ProductosPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, "", Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                }
                if (MensajeLabel.Text == "")
                {
                    ProductosPagingGridView.VirtualItemCount = CantidadFilas;
                    ViewState["lista"] = lista;
                    //Grilla
                    ProductosPagingGridView.DataSource = lista;
                    ProductosPagingGridView.DataBind();
                    if (lista.Count == 0)
                    {
                        ProductosPagingGridView.DataSource = null;
                        ProductosPagingGridView.DataBind();
                        MensajeLabel.Text = "No se han encontrado Productos que satisfagan la busqueda";
                    }
                }
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ProductosPagingGridView.DataSource = null;
            ProductosPagingGridView.DataBind();
            MensajeLabel.Text = String.Empty;
            if (IdProductoRadioButton.Checked)
            {
                NombreTextBox.Text = String.Empty;
                NombreTextBox.Visible = false;
                DescripcionTextBox.Text = String.Empty;
                DescripcionTextBox.Visible = false;
                IdProductoTextBox.Visible = true;
            }
            else if (NombreRadioButton.Checked)
            {
                IdProductoTextBox.Text = String.Empty;
                IdProductoTextBox.Visible = false;
                DescripcionTextBox.Text = String.Empty;
                DescripcionTextBox.Visible = false;
                NombreTextBox.Visible = true;
            }
            else
            {
                IdProductoTextBox.Text = String.Empty;
                IdProductoTextBox.Visible = false;
                NombreTextBox.Text = String.Empty;
                NombreTextBox.Visible = false;
                DescripcionTextBox.Visible = true;
            }
        }
    }
}