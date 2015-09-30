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
        List<CondecoEntidades.Permiso> permiso = new List<CondecoEntidades.Permiso>();
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
                TipoPermisoRadioButton.Checked = true;
                TipoBusquedaRadioButton_CheckedChanged(TipoPermisoRadioButton, new EventArgs());
                TipoPermisoTextBox.Focus();
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
        protected void PermisosPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                PermisosPagingGridView.PageIndex = e.NewPageIndex;
                List<CondecoEntidades.Permiso> lista;
                int CantidadFilas = 0;
                if (IdUsuarioRadioButton.Checked)
                {
                    CondecoEntidades.Usuario usr = new CondecoEntidades.Usuario();
                    usr.Id = IdUsuarioTextBox.Text;
                    lista = CondecoRN.Permiso.LeerListaPermisosPorUsuario(usr, (CondecoEntidades.Sesion)Session["Sesion"]);
                    CantidadFilas = lista.Count;
                }
                else
                {
                    lista = new List<CondecoEntidades.Permiso>();
                    //lista = CondecoRN.Permiso.Lista(out CantidadFilas, PermisosPagingGridView.PageIndex, PermisosPagingGridView.PageSize, PermisosPagingGridView.OrderBy, TipoPermisoTextBox.Text, EsatdoTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                }
                PermisosPagingGridView.VirtualItemCount = CantidadFilas;
                ViewState["lista"] = lista;
                PermisosPagingGridView.DataSource = lista;
                PermisosPagingGridView.DataBind();
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
        protected void PermisosPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<CondecoEntidades.Permiso> lista = new List<CondecoEntidades.Permiso>();
                int CantidadFilas = 0;
                //lista = CondecoRN.Permiso.Lista(out CantidadFilas, PermisosPagingGridView.PageIndex, PermisosPagingGridView.PageSize, PermisosPagingGridView.OrderBy, TipoPermisoTextBox.Text, EsatdoTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                PermisosPagingGridView.DataSource = (List<CondecoEntidades.Permiso>)ViewState["lista"];
                PermisosPagingGridView.DataBind();
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
        protected void PermisosPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                
                //Color por estado distinto a Active
                if (e.Row.Cells[5].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                DropDownList ddlTipoDestacado = (DropDownList)e.Row.FindControl("ddlTipoDestacado");
                if (ddlTipoDestacado != null)
                {
                    ddlTipoDestacado.DataSource = CondecoEntidades.TiposDestacado.TipoDestacado.ListaMasSinInformar();
                    ddlTipoDestacado.DataBind();
                    ddlTipoDestacado.SelectedValue = PermisosPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                }
            }
        }
        private void DesSeleccionarFilas()
        {
            PermisosPagingGridView.SelectedIndex = -1;
        }

        protected void PermisosPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<CondecoEntidades.Permiso> lista = (List<CondecoEntidades.Permiso>)ViewState["lista"];
            CondecoEntidades.Permiso permiso = lista[item];
            switch (e.CommandName)
            {
                case "Detalle":
                    Session["Permiso"] = permiso;
                    Response.Redirect("~/PermisoConsultaDetallada.aspx");
                    break;
                case "CambiarEstado":
                    //Session["Permiso"] = permiso;
                    //CondecoEntidades.Evento Evento;
                    //CondecoRN.Permiso.EventoPosible(out Evento, permiso, (CondecoEntidades.Sesion)Session["Sesion"]);
                    //TituloConfirmacionLabel.Text = "Confirmar " + Evento.DescrEvento;
                    //NombreLabel.Text = permiso.Nombre;
                    //DescripcionLabel.Text = permiso.Email;
                    //EstadoLabel.Text = permiso.WF.Estado;
                    //ViewState["Permiso"] = permiso;
                    //ModalPopupExtender1.Show();
                    break;
                case "Modificar":
                    Session["Permiso"] = permiso;
                    string script = "window.open('/PermisoModificar.aspx', '');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
            }
        }
        protected void PermisosPagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PermisosPagingGridView.EditIndex = e.NewEditIndex;
            PermisosPagingGridView.DataSource = ViewState["lista"];
            PermisosPagingGridView.DataBind();
        }
        protected void PermisosPagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PermisosPagingGridView.EditIndex = -1;
            PermisosPagingGridView.DataSource = ViewState["lista"];
            PermisosPagingGridView.DataBind();
        }
        protected void PermisosPagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //List<CondecoEntidades.Permiso> permisos = ((List<CondecoEntidades.Permiso>)ViewState["lista"]);
                //CondecoEntidades.Permiso permisoActual = CondecoRN.Permiso.ObtenerCopia(permisos[e.RowIndex]);
                //CondecoEntidades.Permiso permiso = permisos[e.RowIndex];

                //string ranking = ((TextBox)PermisosPagingGridView.Rows[e.RowIndex].FindControl("txtRanking")).Text;
                //string tipoDestacado = ((DropDownList)PermisosPagingGridView.Rows[e.RowIndex].FindControl("ddlTipoDestacado")).SelectedValue;
                //if (ranking != string.Empty)
                //{
                //    permiso.Ranking = Convert.ToInt32(ranking);
                //}
                //else
                //{
                //    throw new Exception("Debe informar el ranking. No puede estar vacío.");
                //}
                //permiso.TipoDestacado = tipoDestacado;
                //CondecoRN.Permiso.Modificar(permisoActual, permiso, (CondecoEntidades.Sesion)Session["Sesion"]);
                //PermisosPagingGridView.EditIndex = -1;
                //PermisosPagingGridView.DataSource = ViewState["lista"];
                //PermisosPagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
        protected void PermisosPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void PermisosPagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
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
                    //CondecoEntidades.Permiso permiso = (CondecoEntidades.Permiso)ViewState["Permiso"];
                    //CondecoEntidades.Evento Evento;
                    //CondecoRN.Permiso.EventoPosible(out Evento, permiso, sesion);
                    //CondecoRN.Permiso.CambiarEstado(permiso, Evento.Id, Evento.EstadoHst, sesion);
                    //BuscarButton_Click(BuscarButton, new EventArgs());
                    //Funciones.PersonalizarControlesMaster(Master, true, sesion);
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = "Problemas al cambiar el estado del Permiso." + ex.Message;
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
                List<CondecoEntidades.Permiso> lista = new List<CondecoEntidades.Permiso>();
                int CantidadFilas = 0;
                if (IdUsuarioRadioButton.Checked)
                {
                    CondecoEntidades.Usuario usr = new CondecoEntidades.Usuario();
                    usr.Id = IdUsuarioTextBox.Text;
                    if (IdUsuarioTextBox.Text == string.Empty)
                    {
                        MensajeLabel.Text = "No se han encontrado Permisos que satisfagan la busqueda";
                    }
                    else
                    {
                        lista = CondecoRN.Permiso.LeerListaPermisosPorUsuario(usr, (CondecoEntidades.Sesion)Session["Sesion"]);
                        CantidadFilas = lista.Count;
                    }
                }
                else
                {
                    //lista = CondecoRN.Permiso.Lista(out CantidadFilas, PermisosPagingGridView.PageIndex, PermisosPagingGridView.PageSize, PermisosPagingGridView.OrderBy, TipoPermisoTextBox.Text, EsatdoTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                }
                if (MensajeLabel.Text == "")
                {
                    PermisosPagingGridView.VirtualItemCount = CantidadFilas;
                    ViewState["lista"] = lista;
                    //Grilla
                    PermisosPagingGridView.DataSource = lista;
                    PermisosPagingGridView.DataBind();
                    if (lista.Count == 0)
                    {
                        PermisosPagingGridView.DataSource = null;
                        PermisosPagingGridView.DataBind();
                        MensajeLabel.Text = "No se han encontrado Permisos que satisfagan la busqueda";
                    }
                }
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PermisosPagingGridView.DataSource = null;
            PermisosPagingGridView.DataBind();
            MensajeLabel.Text = String.Empty;
            if (IdUsuarioRadioButton.Checked)
            {
                TipoPermisoTextBox.Text = String.Empty;
                TipoPermisoTextBox.Visible = false;
                EstadoTextBox.Text = String.Empty;
                EstadoTextBox.Visible = false;
                IdUsuarioTextBox.Visible = true;
            }
            else if (TipoPermisoRadioButton.Checked)
            {
                IdUsuarioTextBox.Text = String.Empty;
                IdUsuarioTextBox.Visible = false;
                EstadoTextBox.Text = String.Empty;
                EstadoTextBox.Visible = false;
                TipoPermisoTextBox.Visible = true;
            }
            else
            {
                IdUsuarioTextBox.Text = String.Empty;
                IdUsuarioTextBox.Visible = false;
                TipoPermisoTextBox.Text = String.Empty;
                TipoPermisoTextBox.Visible = false;
                EstadoTextBox.Visible = true;
            }
        }
    }
}