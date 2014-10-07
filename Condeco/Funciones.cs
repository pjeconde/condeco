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

            ContentPlaceHolder menuContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("MenuCPH"));
            Menu menu = ((Menu)menuContentPlaceHolder.FindControl("Menu"));

            ImageButton usuarioImageButton = ((ImageButton)Master.FindControl("UsuarioImageButton"));

            ContentPlaceHolder usuarioContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("UsuarioCPH"));
            Label usuarioLabel = ((Label)usuarioContentPlaceHolder.FindControl("UsuarioLabel"));
            HyperLink usuarioHyperLink = ((HyperLink)usuarioContentPlaceHolder.FindControl("UsuarioHyperLink"));
            //Label cUITLabel = ((Label)usuarioContentPlaceHolder.FindControl("CUITLabel"));
            //DropDownList cUITDropDownList = ((DropDownList)usuarioContentPlaceHolder.FindControl("CUITDropDownList"));
            //Label uNLabel = ((Label)usuarioContentPlaceHolder.FindControl("UNLabel"));
            //DropDownList uNDropDownList = ((DropDownList)usuarioContentPlaceHolder.FindControl("UNDropDownList"));
            
            menu.Items.Clear();
            menu.Orientation = Orientation.Horizontal;
            menu.Enabled = true;
            menu.Visible = true;
            MenuItem mItem;

            //mItem = new MenuItem("Página principal", "Página principal");
            //menu.Items.Add(mItem);
            //menu.Items[menu.Items.Count - 1].Selectable = true;

            //mItem = new MenuItem("Contacto", "Contacto");
            //menu.Items.Add(mItem);
            //menu.Items[menu.Items.Count - 1].Selectable = true;

            mItem = new MenuItem("Portada", "Portada");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Empresa", "Empresa");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Productos", "Productos");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Contacto", "Contacto");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Login", "Login");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Novedades", "Novedades");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Promociones", "Promociones");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;


            mItem = new MenuItem("Configuración", "Configuración");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Cambiar password", "Cambiar password");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Modificar configuración", "Modificar configuración");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            List<CondecoEntidades.Permiso> permisoAdminSITEActive = Sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminSITE" && p.Estado == "Vigente";
            });
            if (permisoAdminSITEActive.Count != 0)
            {
                mItem = new MenuItem("Administración Site", "Administración Site");
                menu.Items.Add(mItem);
                menu.Items[menu.Items.Count - 1].Selectable = false;

                mItem = new MenuItem("Productos", "Productos");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

                MenuItem miProductos = new MenuItem();
                miProductos = menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1];
                mItem = new MenuItem("Crear", "Crear");
                miProductos.ChildItems.Add(mItem);
                miProductos.ChildItems[0].Selectable = false;

                mItem = new MenuItem("Modificar", "Modificar");
                miProductos.ChildItems.Add(mItem);
                
                miProductos.ChildItems[0].Selectable = false;
                mItem = new MenuItem("Imagenes", "Imagenes");
                miProductos.ChildItems.Add(mItem);

                miProductos.ChildItems[0].Selectable = false;
                mItem = new MenuItem("Explorador", "Explorador");
                miProductos.ChildItems.Add(mItem);
                miProductos.ChildItems[0].Selectable = false;

                mItem = new MenuItem("Explorador de Usuarios", "Explorador de Usuarios");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Explorador de Permisos", "Explorador de Permisos");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Explorador de Publicidad", "Explorador de Publicidad");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Explorador de Comentarios", "Explorador de Comentarios");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            }

            mItem = new MenuItem("Close session", "Close session");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            menuContentPlaceHolder.Visible = false;
            usuarioContentPlaceHolder.Visible = false;
            if (Sesion != null)
            {
                foreach (string s in Sesion.OpcionesHabilitadas)
                {
                    MenuItem mItemFind = menu.FindItem(s);
                    if (mItemFind != null)
                    {
                        mItemFind.Selectable = true;
                    }
                }
                menuContentPlaceHolder.Visible = true;
                if (Sesion.Usuario.Id != null)
                {
                    String path = Master.Server.MapPath("~/ImagenesSubidas/");
                    string[] archivos = System.IO.Directory.GetFiles(path, Sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    if (archivos.Length > 0)
                    {
                        usuarioImageButton.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Master.Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                    }
                    else
                    {
                        usuarioImageButton.ImageUrl = "~/Imagenes/SiluetaHombre.jpg";
                    }
                    usuarioImageButton.Visible = true;
                    usuarioContentPlaceHolder.Visible = true;
                    usuarioHyperLink.Text = Sesion.Usuario.Nombre.Replace(" ", "&nbsp;");
                    menu.Items[menu.Items.Count - 1].Selectable = true;
                }
            }
            if (Sesion.Usuario.Id == null)
            {
                for (int i = menu.Items.Count - 1; i > 4; i--)
                {
                    RemoverMenuItem(menu, menu.Items[i]);
                }
            }
            MenuItem menuItem = menu.FindItem("Login");
            if (menuItem != null && !menuItem.Selectable) RemoverMenuItem(menu, menuItem);
        }
        private static void RemoverMenuItem(Menu Menu, MenuItem MenuItem)
        {
            for (int j = MenuItem.ChildItems.Count - 1; j >= 0; j--)
            {
                MenuItem.ChildItems.Remove(MenuItem.ChildItems[0]);
            }
            Menu.Items.Remove(MenuItem);
        }
        public static void RemoverMenuItem(Menu Menu, string IdMenuItem)
        {
            MenuItem menuItem = Menu.FindItem(IdMenuItem);
            if (menuItem != null) RemoverMenuItem(Menu, menuItem);
        }
        public static void GenerarImagenCaptcha(System.Web.SessionState.HttpSessionState Session, System.Web.UI.WebControls.Image CaptchaImage, TextBox CaptchaTextBox)
        {
            string s = RandomText.Generate();
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Session["captcha"] = s.ToLower();
            string color = "#ffffff";
            CaptchaImage.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
            CaptchaTextBox.Text = String.Empty;
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

            astvMyTree.RootNode
                .AppendChild((n100)
                    .AppendChild(new ASTreeViewLinkNode("Madera Pinotea", "Madera Pinotea", "", "frm", "madera maciza", ""))
                    .AppendChild(new ASTreeViewLinkNode("Madera Cedro", "Madera Cedro", "", "frm", "", ""))
                    .AppendChild(new ASTreeViewLinkNode("Vintage", "Vintage", "", "frm", "madera maciza", ""))
                )
                .AppendChild(new ASTreeViewLinkNode("Espejos", "200", "", "frm", "", ""))
                .AppendChild(new ASTreeViewLinkNode("Carteles", "300", "", "frm", "", ""))
                .AppendChild((n400)
                    .AppendChild(new ASTreeViewLinkNode("Mesas Ratonas", "401", "", "frm", "Mesas Ratonas", ""))
                )
                .AppendChild((n500)
                    .AppendChild(new ASTreeViewLinkNode("Bancos Rústicos", "501", "", "frm", "En madera reciclada", ""))
                    .AppendChild(new ASTreeViewLinkNode("Bancos Modernos", "502", "", "frm", "En madera reciclada", ""))
                );
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
    }
}