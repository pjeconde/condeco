using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaDotNet2.Security.Cryptography;
using System.Drawing;
using Geekees.Common.Controls;

namespace Condeco
{
    public static class Funciones
    {
        public static void PersonalizarControlesMaster(MasterPage Master, bool RefrescaDatosUsuario, CondecoEntidades.Sesion Sesion)
        {
            if (RefrescaDatosUsuario) CondecoRN.Sesion.RefrescarDatosUsuario(Sesion.Usuario, Sesion);

            if (Sesion.Ambiente != "PROD")
            {
                //ContentPlaceHolder cedeiraContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("CedeiraContentPlaceHolder"));
                Label ambienteLabel = ((Label)Master.FindControl("AmbienteLabel"));
                ambienteLabel.Text = Sesion.Ambiente;
                Label baseDeDatos = ((Label)Master.FindControl("BaseDeDatosLabel"));
                baseDeDatos.Text = Sesion.BaseDeDatos;
            }

            Control btnUsuarioLogin = (Control)Master.FindControl("btnUsuarioLogin");
            btnUsuarioLogin.Visible = false;
            Control btnAdmin = (Control)Master.FindControl("btnAdmin");
            btnAdmin.Visible = false;
            Control btnCerrarLogin = (Control)Master.FindControl("btnCerrarLogin");
            btnCerrarLogin.Visible = false;
            Control btnUsuario = (Control)Master.FindControl("btnUsuario");
            btnUsuario.Visible = false;

            //ImageButton usuarioImageButton = ((ImageButton)Master.FindControl("UsuarioImageButton"));
            //ContentPlaceHolder usuarioContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("UsuarioCPH"));
            //Label usuarioLabel = ((Label)usuarioContentPlaceHolder.FindControl("UsuarioLabel"));
            //HyperLink usuarioHyperLink = ((HyperLink)usuarioContentPlaceHolder.FindControl("UsuarioHyperLink"));

            List<CondecoEntidades.Permiso> permisoAdminSITEActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Vigente";
            });
            if (permisoAdminSITEActive.Count != 0)
            {
                btnAdmin.Visible = true;
            }

            //mItem = new MenuItem("Close session", "Close session");
            //menu.Items.Add(mItem);
            //menu.Items[menu.Items.Count - 1].Selectable = false;

            if (Sesion != null)
            {
                foreach (string s in Sesion.OpcionesHabilitadas)
                {
                    Control c = (Control)Master.FindControl("btn" + s);
                    if (c != null)
                    {
                        c.Visible = true;
                    }
                }
                if (Sesion.Usuario.Id != null)
                {
                    Control c = (Control)Master.FindControl("btnUsuario");
                    if (c != null)
                    {
                        c.Visible = true;
                    }
                    c = (Control)Master.FindControl("btnCerrarLogin");
                    if (c != null)
                    {
                        c.Visible = true;
                    }
                    Label usrNombre = (Label)Master.FindControl("lblUsuario");
                    if (usrNombre != null)
                    {
                        usrNombre.Text = Sesion.Usuario.Id + " - " + Sesion.Usuario.Nombre;
                    }
                    
                    //String path = Master.Server.MapPath("~/ImagenesSubidas/");
                    //string[] archivos = System.IO.Directory.GetFiles(path, Sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    //if (archivos.Length > 0)
                    //{
                    //    usuarioImageButton.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Master.Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                    //}
                    //else
                    //{
                    //    usuarioImageButton.ImageUrl = "~/Imagenes/SiluetaHombre.jpg";
                    //}
                    //usuarioImageButton.Visible = true;
                    //usuarioContentPlaceHolder.Visible = true;
                    //usuarioHyperLink.Text = Sesion.Usuario.Nombre.Replace(" ", "&nbsp;");
                    //usuarioLabel.Text = "User: ";
                    //menu.Items[menu.Items.Count - 1].Selectable = true;
                }
            }
            if (Sesion.Usuario.Id == null)
            {
                Control c = (Control)Master.FindControl("btnUsuarioLogin");
                if (c != null)
                {
                    c.Visible = true;
                }
            }
        }
        public static void OcultarItem(MasterPage Master, string Item)
        {
            Control control = (Control)Master.FindControl(Item);
            if (control != null)
            {
                control.Visible = false;
            }
        }

        public static void GenerarImagenCaptcha(System.Web.SessionState.HttpSessionState Session, System.Web.UI.WebControls.Image CaptchaImage)
        {
            string s = RandomText.Generate();
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Session["captcha"] = s.ToLower();
            string color = "#ffffff";
            CaptchaImage.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
        }
        public static bool SessionTimeOut(System.Web.SessionState.HttpSessionState Session)
        {
            return ((CondecoEntidades.Sesion)Session["Sesion"]).Usuario.Id == null;
        }

        public static void GenerarTreeTipoProductos(ASTreeView astvMyTree, bool Buscador)
        {
            ASTreeViewLinkNode n100 = new ASTreeViewLinkNode("Marcos", "100", "", "frm", "madera maciza", "");
            n100.EnableCheckbox = Buscador;
            n100.EnableChildren = false;
            n100.EnableEditContextMenu = false;

            ASTreeViewLinkNode n400 = new ASTreeViewLinkNode("Mesas", "400", "", "frm", "", "");
            n400.EnableCheckbox = Buscador;
            n400.EnableChildren = false;
            n400.EnableEditContextMenu = false;

            ASTreeViewLinkNode n500 = new ASTreeViewLinkNode("Sillas y Bancos", "500", "", "frm", "", "");
            n500.EnableCheckbox = Buscador;
            n500.EnableChildren = false;
            n500.EnableEditContextMenu = false;

            ASTreeViewLinkNode n600 = new ASTreeViewLinkNode("Decoración", "600", "", "frm", "objetos decorativos", "");
            n600.EnableCheckbox = Buscador;
            n600.EnableChildren = false;
            n600.EnableEditContextMenu = false;

            astvMyTree.RootNode
                .AppendChild((n100)
                    .AppendChild(new ASTreeViewLinkNode("Madera Pinotea", "101", "", "frm", "madera maciza", ""))
                    .AppendChild(new ASTreeViewLinkNode("Madera Cedro", "102", "", "frm", "", ""))
                    .AppendChild(new ASTreeViewLinkNode("Vintage", "103", "", "frm", "madera maciza", ""))
                )
                .AppendChild(new ASTreeViewLinkNode("Espejos", "200", "", "frm", "", ""))
                .AppendChild(new ASTreeViewLinkNode("Carteles", "300", "", "frm", "", ""))
                .AppendChild((n400)
                    .AppendChild(new ASTreeViewLinkNode("Mesas Ratonas", "401", "", "frm", "Mesas Ratonas", ""))
                )
                .AppendChild((n500)
                    .AppendChild(new ASTreeViewLinkNode("Bancos Rústicos", "501", "", "frm", "En madera reciclada", ""))
                    .AppendChild(new ASTreeViewLinkNode("Bancos Modernos", "502", "", "frm", "En madera reciclada", ""))
                )
                .AppendChild((n600)
                    .AppendChild(new ASTreeViewLinkNode("Peces", "601", "", "frm", "madera y metal", ""))
                    .AppendChild(new ASTreeViewLinkNode("Barcos", "602", "", "frm", "madera y metal", ""))
                    .AppendChild(new ASTreeViewLinkNode("Caras", "603", "", "frm", "madera y metal", ""))
                    .AppendChild(new ASTreeViewLinkNode("Cuadros", "604", "", "frm", "madera y metal", ""))
                    .AppendChild(new ASTreeViewLinkNode("Objetos Varios", "650", "", "frm", "madera y metal", ""))
                );
        }
        public static string ListaDeProducto(string l)
        {
            string listaTipoProducto = "";
            switch (l)
            {
                case "Marcos":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "101, 102, 103, 200";
                    }
                    break;
                case "Carteles":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "300";
                    }
                    break;
                case "Mesas":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "401";
                    }
                    break;
                case "Peces":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "601";
                    }
                    break;
                case "Barcos":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "602";
                    }
                    break;
                case "Caras":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "603";
                    }
                    break;
                case "Cuadros":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "604";
                    }
                    break;
                case "Otros Objetos":
                    if (listaTipoProducto == "")
                    {
                        listaTipoProducto = "650";
                    }
                    break;
            }
            return l;
        }
        public static string TreeViewLista(ASTreeView astvMyTree)
        {
            List<ASTreeViewNode> checkedNodes = astvMyTree.GetCheckedNodes(false);

            string lista = "";
            foreach (ASTreeViewNode node in checkedNodes)
            {
                //Nodos seleccionados
                if (lista == "")
                {
                    lista += node.NodeValue;        //"[" + node.NodeText + "-" + node.NodeValue + "]";
                }
                else
                {
                    lista += ", " + node.NodeValue;
                }
            }
            return lista;
        }
        public static string TreeViewListaChilds(ASTreeView astvMyTree)
        {
            List<ASTreeViewNode> checkedNodes = astvMyTree.GetCheckedNodes(false);

            string lista = "";
            foreach (ASTreeViewNode node in checkedNodes)
            {
                if (node.ChildNodes.Count == 0)
                {
                    if (lista == "")
                    {
                        lista += node.NodeValue;
                    }
                    else
                    {
                        lista += ", " + node.NodeValue;
                    }
                }
            }
            return lista;
        }
        public static bool EsUsuarioAdmin(CondecoEntidades.Sesion Sesion)
        {
            List<CondecoEntidades.Permiso> permisoAdminSITEActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Vigente";
            });
            if (permisoAdminSITEActive.Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}