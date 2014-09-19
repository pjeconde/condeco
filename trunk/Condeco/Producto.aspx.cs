﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condeco
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VistaRadioButton_CheckedChanged(Vista1RadioButton, new EventArgs());
                DataBind();
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            BindPagingGrid();
        }
        protected void ClearButton_Click(object sender, EventArgs e)
        {
            NombreTextBox.Text = "";
            DescripcionTextBox.Text = "";
        }
        protected void NewButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/UsuarioLogin.aspx");
            }
            else
            {
                Response.Redirect("~/ProductoCrear.aspx");
            }
        }
        private void BindPagingGrid()
        {
            try
            {
                int CantidadFilas = 0;
                List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
                if (Vista1RadioButton.Checked == true)
                {
                    lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                    ProductoPagingGridView.VirtualItemCount = CantidadFilas;
                    ViewState["lista"] = lista;
                    //Grilla
                    ProductoPagingGridView.DataSource = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    ProductoPagingGridView.DataBind();
                }
                else
                {
                    lista = CondecoRN.Producto.ListaCompleta(out CantidadFilas, "", NombreTextBox.Text, DescripcionTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);

                    string[] archivos = LeerImagenesPortada();
                    for (int i = 0; i < archivos.Length; i++)
                    {
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(archivos[i]);
                        string[] resultado = fileName.Split(Convert.ToChar("-"));
                        if (resultado.Length > 1)
                        {
                            try 
                            {
                                int idProducto = Convert.ToInt32(resultado[1].ToString());
                                CondecoEntidades.Producto Producto = lista.Find(delegate(CondecoEntidades.Producto m)
                                {
                                    return m.Id == idProducto;
                                });
                                if (Producto != null)
                                {
                                    Producto.NombreImagenPortada = System.IO.Path.GetFileName(archivos[i]);
                                }
                            }
                            catch { }
                        }
                    }
                    ViewState["lista"] = lista;
                    //ListView
                    ProductoListView.DataSource = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    ProductoListView.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
        }
        private string[] LeerImagenesPortada()
        {
            CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
            CondecoEntidades.Producto Producto = (CondecoEntidades.Producto)Session["Producto"];
            String path = Server.MapPath("~/ImagenesProducto/Portada/");
            string[] archivos = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.TopDirectoryOnly);
            return archivos;
        }
        protected void ProductoPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                ProductoPagingGridView.PageIndex = e.NewPageIndex;
                List<CondecoEntidades.Producto> lista;
                int CantidadFilas = 0;
                lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                ProductoPagingGridView.VirtualItemCount = CantidadFilas;
                ViewState["lista"] = lista;
                ProductoPagingGridView.DataSource = lista;
                ProductoPagingGridView.DataBind();
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
        protected void ProductoPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
                int CantidadFilas = 0;
                lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ProductoPagingGridView.DataSource = (List<CondecoEntidades.Producto>)ViewState["lista"];
                ProductoPagingGridView.DataBind();
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
        protected void ProductoPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.ProductoPagingGridView, "Select$" + e.Row.RowIndex);
            }
        }
        private void DesSeleccionarFilas()
        {
            ProductoPagingGridView.SelectedIndex = -1;
        }

        protected void ProductoPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Detail":
                    int item = Convert.ToInt32(e.CommandArgument);
                    List<CondecoEntidades.Producto> lista = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    CondecoEntidades.Producto Producto = lista[item];
                    Session["Producto"] = Producto;
                    Response.Redirect("~/ProductoConsultaDetallada.aspx");
                    break;
            }
        }

        //protected void Button_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    string CommandName = btn.CommandName;
        //    string CommandArgument = btn.CommandArgument;
        //}

        protected void ProductoPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ProductoPagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void ProductoListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //set current page startindex, max rows and rebind to false
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            ProductoListView.DataSource = (List<CondecoEntidades.Producto>)ViewState["lista"];
            ProductoListView.DataBind();
        }

        protected void VistaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Vista1RadioButton.Checked == true)
            {
                PanelPagingGridView.Visible = true;
                PanelListView.Visible = false;
                BindPagingGrid();
            }
            else
            {
                PanelPagingGridView.Visible = false;
                PanelListView.Visible = true;
                BindPagingGrid();
            }
        }

        protected void lportada_Click(object sender, EventArgs e)
        {

            int item = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            List<CondecoEntidades.Producto> lista = (List<CondecoEntidades.Producto>)ViewState["lista"];
            CondecoEntidades.Producto Producto = lista.Find(delegate(CondecoEntidades.Producto m)
            {
                return m.Id == item;
            });
            Session["Producto"] = Producto;
            Response.Redirect("~/ProductoConsultaDetallada.aspx");
        }
    }
}