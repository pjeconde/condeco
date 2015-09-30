using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Condeco
{
    public partial class ExploradorPermisos : System.Web.UI.Page
    {
        List<CondecoEntidades.Usuario> usuario = new List<CondecoEntidades.Usuario>();
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
        protected void UsuariosPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                UsuariosPagingGridView.PageIndex = e.NewPageIndex;
                List<CondecoEntidades.Usuario> lista;
                int CantidadFilas = 0;
                if (IdUsuarioRadioButton.Checked)
                {
                    lista = CondecoRN.Usuario.ListaPorIdUsuario(IdUsuarioTextBox.Text, (CondecoEntidades.Sesion)Session["Sesion"]);
                    CantidadFilas = lista.Count;
                }
                else
                {
                    lista = CondecoRN.Usuario.Lista(out CantidadFilas, UsuariosPagingGridView.PageIndex, UsuariosPagingGridView.PageSize, UsuariosPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                }
                UsuariosPagingGridView.VirtualItemCount = CantidadFilas;
                ViewState["lista"] = lista;
                UsuariosPagingGridView.DataSource = lista;
                UsuariosPagingGridView.DataBind();
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
        protected void UsuariosPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<CondecoEntidades.Usuario> lista = new List<CondecoEntidades.Usuario>();
                int CantidadFilas = 0;
                lista = CondecoRN.Usuario.Lista(out CantidadFilas, UsuariosPagingGridView.PageIndex, UsuariosPagingGridView.PageSize, UsuariosPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                UsuariosPagingGridView.DataSource = (List<CondecoEntidades.Usuario>)ViewState["lista"];
                UsuariosPagingGridView.DataBind();
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
        protected void UsuariosPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                
                //Color por estado distinto a Active
                if (e.Row.Cells[4].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                DropDownList ddlTipoDestacado = (DropDownList)e.Row.FindControl("ddlTipoDestacado");
                if (ddlTipoDestacado != null)
                {
                    ddlTipoDestacado.DataSource = CondecoEntidades.TiposDestacado.TipoDestacado.ListaMasSinInformar();
                    ddlTipoDestacado.DataBind();
                    ddlTipoDestacado.SelectedValue = UsuariosPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                }
            }
        }
        private void DesSeleccionarFilas()
        {
            UsuariosPagingGridView.SelectedIndex = -1;
        }

        protected void UsuariosPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<CondecoEntidades.Usuario> lista = (List<CondecoEntidades.Usuario>)ViewState["lista"];
            CondecoEntidades.Usuario usuario = lista[item];
            switch (e.CommandName)
            {
                case "Detalle":
                    Session["Usuario"] = usuario;
                    Response.Redirect("~/UsuarioConsultaDetallada.aspx");
                    break;
                case "CambiarEstado":
                    //Session["Usuario"] = usuario;
                    //CondecoEntidades.Evento Evento;
                    //CondecoRN.Usuario.EventoPosible(out Evento, usuario, (CondecoEntidades.Sesion)Session["Sesion"]);
                    //TituloConfirmacionLabel.Text = "Confirmar " + Evento.DescrEvento;
                    //NombreLabel.Text = usuario.Nombre;
                    //DescripcionLabel.Text = usuario.Email;
                    //EstadoLabel.Text = usuario.WF.Estado;
                    //ViewState["Usuario"] = usuario;
                    //ModalPopupExtender1.Show();
                    break;
                case "Modificar":
                    Session["Usuario"] = usuario;
                    string script = "window.open('/UsuarioModificar.aspx', '');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
            }
        }
        protected void UsuariosPagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UsuariosPagingGridView.EditIndex = e.NewEditIndex;
            UsuariosPagingGridView.DataSource = ViewState["lista"];
            UsuariosPagingGridView.DataBind();
        }
        protected void UsuariosPagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UsuariosPagingGridView.EditIndex = -1;
            UsuariosPagingGridView.DataSource = ViewState["lista"];
            UsuariosPagingGridView.DataBind();
        }
        protected void UsuariosPagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //List<CondecoEntidades.Usuario> usuarios = ((List<CondecoEntidades.Usuario>)ViewState["lista"]);
                //CondecoEntidades.Usuario usuarioActual = CondecoRN.Usuario.ObtenerCopia(usuarios[e.RowIndex]);
                //CondecoEntidades.Usuario usuario = usuarios[e.RowIndex];

                //string ranking = ((TextBox)UsuariosPagingGridView.Rows[e.RowIndex].FindControl("txtRanking")).Text;
                //string tipoDestacado = ((DropDownList)UsuariosPagingGridView.Rows[e.RowIndex].FindControl("ddlTipoDestacado")).SelectedValue;
                //if (ranking != string.Empty)
                //{
                //    usuario.Ranking = Convert.ToInt32(ranking);
                //}
                //else
                //{
                //    throw new Exception("Debe informar el ranking. No puede estar vacío.");
                //}
                //usuario.TipoDestacado = tipoDestacado;
                //CondecoRN.Usuario.Modificar(usuarioActual, usuario, (CondecoEntidades.Sesion)Session["Sesion"]);
                //UsuariosPagingGridView.EditIndex = -1;
                //UsuariosPagingGridView.DataSource = ViewState["lista"];
                //UsuariosPagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
        protected void UsuariosPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void UsuariosPagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
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
                    //CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    //CondecoEntidades.Usuario usuario = (CondecoEntidades.Usuario)ViewState["Usuario"];
                    //CondecoEntidades.Evento Evento;
                    //CondecoRN.Usuario.EventoPosible(out Evento, usuario, sesion);
                    //CondecoRN.Usuario.CambiarEstado(usuario, Evento.Id, Evento.EstadoHst, sesion);
                    //BuscarButton_Click(BuscarButton, new EventArgs());
                    //Funciones.PersonalizarControlesMaster(Master, true, sesion);
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = "Problemas al cambiar el estado del Usuario." + ex.Message;
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
                List<CondecoEntidades.Usuario> lista = new List<CondecoEntidades.Usuario>();
                int CantidadFilas = 0;
                if (IdUsuarioRadioButton.Checked)
                {
                    if (IdUsuarioTextBox.Text == string.Empty)
                    {
                        MensajeLabel.Text = "No se han encontrado Usuarios que satisfagan la busqueda";
                    }
                    else
                    {
                        lista = CondecoRN.Usuario.ListaPorIdUsuario(IdUsuarioTextBox.Text, (CondecoEntidades.Sesion)Session["Sesion"]);
                        CantidadFilas = lista.Count;
                    }
                }
                else
                {
                    lista = CondecoRN.Usuario.Lista(out CantidadFilas, UsuariosPagingGridView.PageIndex, UsuariosPagingGridView.PageSize, UsuariosPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                }
                if (MensajeLabel.Text == "")
                {
                    UsuariosPagingGridView.VirtualItemCount = CantidadFilas;
                    ViewState["lista"] = lista;
                    //Grilla
                    UsuariosPagingGridView.DataSource = lista;
                    UsuariosPagingGridView.DataBind();
                    if (lista.Count == 0)
                    {
                        UsuariosPagingGridView.DataSource = null;
                        UsuariosPagingGridView.DataBind();
                        MensajeLabel.Text = "No se han encontrado Usuarios que satisfagan la busqueda";
                    }
                }
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UsuariosPagingGridView.DataSource = null;
            UsuariosPagingGridView.DataBind();
            MensajeLabel.Text = String.Empty;
            if (IdUsuarioRadioButton.Checked)
            {
                NombreTextBox.Text = String.Empty;
                NombreTextBox.Visible = false;
                DescripcionTextBox.Text = String.Empty;
                DescripcionTextBox.Visible = false;
                IdUsuarioTextBox.Visible = true;
            }
            else if (NombreRadioButton.Checked)
            {
                IdUsuarioTextBox.Text = String.Empty;
                IdUsuarioTextBox.Visible = false;
                DescripcionTextBox.Text = String.Empty;
                DescripcionTextBox.Visible = false;
                NombreTextBox.Visible = true;
            }
            else
            {
                IdUsuarioTextBox.Text = String.Empty;
                IdUsuarioTextBox.Visible = false;
                NombreTextBox.Text = String.Empty;
                NombreTextBox.Visible = false;
                DescripcionTextBox.Visible = true;
            }
        }
    }
}