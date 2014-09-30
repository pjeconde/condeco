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
                    GenerateTree();
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
                    
                    //TipoProductoTreeView.Nodes.Add(

                    DataBind();
                    //this.btnExpandAllClient.Attributes.Add("onclick", this.astvMyTree.GetExpandAllScript() + "return false;");
                    //this.btnCollapseAllClient.Attributes.Add("onclick", this.astvMyTree.GetCollapseAllScript() + "return false;");
                    //this.btnToggleExpandCollapseAllClient.Attributes.Add("onclick", this.astvMyTree.GetToggleExpandCollapseAllScript() + "return false;");

                    this.astvMyTree.ContextMenu.MenuItems.Add(new ASContextMenuItem("Custom Menu", "alert('current value:' + " + this.astvMyTree.ContextMenuClientID + ".getSelectedItem().parentNode.getAttribute('treeNodeValue')" + ");return false;", "text"));
                }
            }
        }

        private void GenerateTree()
		{

			ASTreeViewLinkNode n = new ASTreeViewLinkNode( "Picasa", "Picasa", "http://picasaweb.google.com", "frm", "Goto Picasa", "~/Images/demoIcons/picasa.gif" );
			n.NodeText = "The node cannot have children.";
			n.EnableChildren = false;
			n.EnableEditContextMenu = false;

			//n.AdditionalAttributes.Add( new KeyValuePair<string, string>( "onclick", "alert(1);return false;" ) );
			//n.AdditionalAttributes.Add( new KeyValuePair<string, string>( "disableChildren1", "true" ) );

			this.astvMyTree.RootNode
                                .AppendChild(new ASTreeViewLinkNode("Marcos", "Marcos", "", "frm", "madera maciza", "")
													.AppendChild( new ASTreeViewLinkNode( "de Pinotea", "de Madera", "", "frm", "madera maciza", "" ) )
													.AppendChild( new ASTreeViewLinkNode( "de Cedro", "Cedro", "", "frm", "", "" ) )
                                                    .AppendChild(new ASTreeViewLinkNode("vintage", "vintage", "", "frm", "madera maciza", "~/Images/demoIcons/saab.gif"))
								)
                                .AppendChild(new ASTreeViewLinkNode("Espejos", "Espejos", "", "frm", "Goto Google", "~/Images/demoIcons/google.gif")
													.AppendChild( new ASTreeViewLinkNode( "de Cedro", "de Cedro", "", "frm", "", "~/Images/demoIcons/picasa.gif" ) )
								)
								.AppendChild( new ASTreeViewLinkNode( "Amazon", "Amazon", "http://www.amazon.com", "frm", "Goto Amazon", "~/Images/demoIcons/amazon.gif" ).AppendChild( n ) )
								.AppendChild( new ASTreeViewLinkNode( "<font style='color:blue;font-weight:bold;font-style:italic;' isTreeNodeChild='true'>ASTreeView</font>", "Best Free TreeView Control for ASP.Net", "http://www.astreeview.com", "frm", "Html as TreeNode Text", "~/Images/demoIcons/ast.gif" )
								);
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
                        
                        YouTubeTextBox.Enabled = false;
                        EstadoDropDownList.Enabled = false;
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