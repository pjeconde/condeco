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
    public partial class Producto : System.Web.UI.Page
    {
        string listaTipoProducto = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GenerateTree();
                if (Session["ListaTipoProducto"] != null)
                {
                    listaTipoProducto = Session["ListaTipoProducto"].ToString();
                    Session.Remove("ListaTipoProducto");
                }
                VistaRadioButton_CheckedChanged(Vista1RadioButton, new EventArgs());

                //this.astvMyTree.ContextMenu.MenuItems.Add(new ASContextMenuItem("Custom Menu", "alert('current value:' + " + this.astvMyTree.ContextMenuClientID + ".getSelectedItem().parentNode.getAttribute('treeNodeValue')" + ");return false;", "text"));
                //astvMyTree.ExpandToDepth(0);
                //if (Request.QueryString.Count > 0)
                //{
                //    string v = Request.QueryString["Filtro"].ToString();
                //    string[] buscarNodo = new string[1];
                //    buscarNodo[0] = v;  //400 - Mesas
                //    this.astvMyTree.CheckNodes(buscarNodo, true);
                //    BindPagingGrid();
                //}

                BuscarBtn.ServerClick += new EventHandler(this.BuscarButton_Click);
                if (Funciones.EsUsuarioAdmin(((CondecoEntidades.Sesion)Session["Sesion"])))
                {
                    divVistas.Visible = true;
                    Vista1RadioButton.Visible = true;
                    Vista2RadioButton.Visible = true;
                }
                else
                {
                    divVistas.Visible = false;
                    Vista1RadioButton.Visible = false;
                    Vista2RadioButton.Visible = false;
                }
                DataBind();
            }
        }

        //private void GenerateTree()
        //{
        //    Funciones.GenerarTreeTipoProductos(astvMyTree, true);
        //}

        protected void BuscarDirectoButton_Click(object sender, EventArgs e)
        {
            listaTipoProducto = Funciones.ListaDeProducto(((LinkButton)sender).CommandName);
            BindPagingGrid();
        }
        //protected void ModificarButton_Click(object sender, EventArgs e)
        //{
        //    if (Funciones.SessionTimeOut(Session))
        //    {
        //        Response.Redirect("~/SessionTimeout.aspx");
        //    }
        //    else
        //    {
        //        CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
        //        string codProd = ((LinkButton)sender).CommandName;
        //        if (codProd != "")
        //        {
        //            CondecoEntidades.Producto producto = new CondecoEntidades.Producto();
        //            producto.Id = Convert.ToInt32(codProd);
        //            CondecoRN.Producto.Leer(producto, sesion);
        //            Session["Producto"] = producto;
        //            Response.Redirect("~/ProductoModificar.aspx");
        //        }
        //    }
        //}
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            BindPagingGrid();
            //if (Funciones.EsUsuarioAdmin(((CondecoEntidades.Sesion)Session["Sesion"])))
            //{
            //    string s = "<asp:LinkButton ID='ModificarLink' runat='server' OnClick='ModificarButton_Click' CommandArgument='<%# Eval('Id') %>'><span class='fa fa-1-5x fa-edit' style='padding-right:5px'></span></asp:LinkButton>";
            //    Control c = (Control)this.PanelListView.FindControl("Literal1");
            //    ((Literal)c).Text = s;
            //}
        }
        protected void ClearButton_Click(object sender, EventArgs e)
        {
            DescripcionTextBox.Value = "";
            astvMyTree.ClearNodesCheck();
            astvMyTree.ExpandToDepth(0);
            BindPagingGrid();
        }
        private void BindPagingGrid()
        {
            try
            {
                //List<ASTreeViewNode> checkedNodes = this.astvMyTree.GetCheckedNodes(false);
                //listaTipoProducto = "";
                //foreach (ASTreeViewNode node in checkedNodes)
                //{
                //    //Nodos seleccionados
                //    if (listaTipoProducto == "")
                //    {
                //        listaTipoProducto += node.NodeValue;
                //    }
                //    else
                //    {
                //        listaTipoProducto += ", " + node.NodeValue;
                //    }
                //}

                int CantidadFilas = 0;
                List<CondecoEntidades.Producto> lista = new List<CondecoEntidades.Producto>();
                if (Vista2RadioButton.Checked == true)
                {
                    lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, DescripcionTextBox.Value, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
                    ProductoPagingGridView.VirtualItemCount = CantidadFilas;
                    ViewState["lista"] = lista;
                    //Grilla
                    ProductoPagingGridView.DataSource = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    ProductoPagingGridView.DataBind();
                }
                else
                {
                    lista = CondecoRN.Producto.ListaCompleta(out CantidadFilas, "", DescripcionTextBox.Value, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);

                    string[] archivos = LeerImagenesPortada();
                    for (int i = 0; i < archivos.Length; i++)
                    {
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(archivos[i]);
                        //string[] resultado = fileName.Split(Convert.ToChar("-"));
                        if (fileName != "")
                        {
                            try 
                            {
                                int idProducto = Convert.ToInt32(fileName);
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
                if (DataPager1.TotalRowCount > DataPager1.MaximumRows)
                {
                    DataPager1.Visible = true;
                }
                else
                {
                    DataPager1.Visible = false;
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
                lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, DescripcionTextBox.Value, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
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
                lista = CondecoRN.Producto.Lista(out CantidadFilas, ProductoPagingGridView.PageIndex, ProductoPagingGridView.PageSize, ProductoPagingGridView.OrderBy, DescripcionTextBox.Value, listaTipoProducto, Session.SessionID, (CondecoEntidades.Sesion)Session["Sesion"]);
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
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';";
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
            int item;
            List<CondecoEntidades.Producto> lista;
            CondecoEntidades.Producto Producto;
            switch (e.CommandName)
            {
                case "Detalle":
                    item = Convert.ToInt32(e.CommandArgument);
                    lista = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    Producto = lista[item];
                    Session["Producto"] = Producto;
                    Response.Redirect("~/ProductoConsultaDetallada.aspx");
                    break;
                case "Modificar":
                    item = Convert.ToInt32(e.CommandArgument);
                    lista = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    Producto = lista[item];
                    Session["Producto"] = Producto;
                    Response.Redirect("~/ProductoModificar.aspx");
                    break;
                case "Clonar":
                    item = Convert.ToInt32(e.CommandArgument);
                    lista = (List<CondecoEntidades.Producto>)ViewState["lista"];
                    Producto = lista[item];
                    Session["Producto"] = Producto;
                    Response.Redirect("~/ProductoCrear.aspx");
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
                PanelPagingGridView.Visible = false;
                PanelListView.Visible = true;
                BindPagingGrid();                
            }
            else
            {
                PanelPagingGridView.Visible = true;
                PanelListView.Visible = false;
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
            Response.Redirect("~/ProductoConsultaDetalladaSM.aspx");
        }
    }
}