﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Geekees.Common.Utilities.Xml;
using Geekees.Common.Controls;

namespace Condeco
{
    public partial class Producto : System.Web.UI.Page
    {
        string listaTipoProducto = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateTree();
                VistaRadioButton_CheckedChanged(Vista1RadioButton, new EventArgs());
                DataBind();
                this.astvMyTree.ContextMenu.MenuItems.Add(new ASContextMenuItem("Custom Menu", "alert('current value:' + " + this.astvMyTree.ContextMenuClientID + ".getSelectedItem().parentNode.getAttribute('treeNodeValue')" + ");return false;", "text"));
            }
        }

        private void GenerateTree()
        {

            ASTreeViewLinkNode n = new ASTreeViewLinkNode("Mesas Ratonas", "401", "", "frm", "Mesas Ratonas", "");
            //n.NodeText = "";
            n.EnableChildren = false;
            n.EnableEditContextMenu = false;

            //n.AdditionalAttributes.Add( new KeyValuePair<string, string>( "onclick", "alert(1);return false;" ) );
            //n.AdditionalAttributes.Add( new KeyValuePair<string, string>( "disableChildren1", "true" ) );

            this.astvMyTree.RootNode
                                .AppendChild(new ASTreeViewLinkNode("Marcos", "100", "", "frm", "madera maciza", "")
                                                    .AppendChild(new ASTreeViewLinkNode("Madera Pinotea", "Madera Pinotea", "", "frm", "madera maciza", ""))
                                                    .AppendChild(new ASTreeViewLinkNode("Madera Cedro", "Madera Cedro", "", "frm", "", ""))
                                                    .AppendChild(new ASTreeViewLinkNode("Vintage", "Vintage", "", "frm", "madera maciza", ""))
                                )
                                .AppendChild(new ASTreeViewLinkNode("Espejos", "200", "", "frm", "", ""))
                                .AppendChild(new ASTreeViewLinkNode("Carteles", "300", "", "frm", "", ""))
                                .AppendChild(new ASTreeViewLinkNode("Mesas", "400", "", "frm", "", "")
                                                    .AppendChild(n))
                                .AppendChild(new ASTreeViewLinkNode("Bancos", "500", "", "frm", "", "")
                                                    .AppendChild(new ASTreeViewLinkNode("Bancos Rústicos", "501", "", "frm", "En maderas recicladas", ""))
                                );
                                //.AppendChild(new ASTreeViewLinkNode("<font style='color:blue;font-weight:bold;font-style:italic;' isTreeNodeChild='true'>Novedades</font>", "Novedades", "", "frm", "", "~/Imagenes/Iconos/Punto.jpg")
                                //);
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            BindPagingGrid();
            List<ASTreeViewNode> checkedNodes = this.astvMyTree.GetCheckedNodes(false);
            
            listaTipoProducto = "";
            foreach (ASTreeViewNode node in checkedNodes)
            {
                //Nodos seleccionados
                if (listaTipoProducto == "")
                {
                    listaTipoProducto += node.NodeValue;        //"[" + node.NodeText + "-" + node.NodeValue + "]";
                }
                else
                {
                    listaTipoProducto += ", " + node.NodeValue;
                }
            }
        }
        protected void ClearButton_Click(object sender, EventArgs e)
        {
            NombreTextBox.Text = "";
            DescripcionTextBox.Text = "";
        }
        private void BindPagingGrid()
        {
            try
            {
                int CantidadFilas = 0;
                List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
                if (Vista1RadioButton.Checked == true)
                {
                    lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                    ProductoPagingGridView.VirtualItemCount = CantidadFilas;
                    ViewState["lista"] = lista;
                    //Grilla
                    ProductoPagingGridView.DataSource = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    ProductoPagingGridView.DataBind();
                }
                else
                {
                    lista = CondecoRN.Producto.ListaCompleta(out CantidadFilas, "", NombreTextBox.Text, DescripcionTextBox.Text, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);

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
                lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
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
                lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, NombreTextBox.Text, DescripcionTextBox.Text, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
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