﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Condeco
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                Funciones.PersonalizarControlesMaster(this, true, sesion);
            }
        }
        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
            switch (Menu.SelectedItem.ValuePath)
            {
                case "Portada":
                    Response.Redirect("~/Default.aspx");
                    break;
                case "Empresa":
                    Response.Redirect("~/Empresa.aspx");
                    break;
                case "Productos":
                    Response.Redirect("~/Producto.aspx");
                    break;
                case "Contacto":
                    Response.Redirect("~/Contacto.aspx");
                    break;
                case "Novedades":
                    Response.Redirect("~/Novedades.aspx");
                    break;
                case "Promociones":
                    Response.Redirect("~/Promociones.aspx");
                    break;
                case "Configuración":
                    Response.Redirect("~/Default.aspx");
                    break;
                case "Configuración|Cambiar password":
                    Response.Redirect("~/UsuarioCambiarPassword.aspx");
                    break;
                case "Configuración|Mofificar configuración":
                    Response.Redirect("~/Default.aspx");
                    break;
                case "Login":
                    Response.Redirect("~/UsuarioLogin.aspx");
                    break;
                case "Administración Site|Productos|Crear":
                    Response.Redirect("~/ProductoCrear.aspx");
                    break;
                case "Administración Site|Productos|Modificar":
                    Response.Redirect("~/ProductoSeleccionar.aspx?Modificar");
                    break;
                case "Administración Site|Productos|Imagenes":
                    Response.Redirect("~/ProductoSeleccionar.aspx?Imagenes");
                    break;
                case "Administración Site|Productos|Explorador":
                    Response.Redirect("~/ExploradorProducto.aspx");
                    break;
                case "Administración Site|Explorador de Usuarios":
                    Response.Redirect("~/ExploradorUsuarios.aspx");
                    break;
                case "Administración Site|Explorador de Permisos":
                    Response.Redirect("~/ExploradorPermiso.aspx");
                    break;
                 case "Administración Site|Explorador de Publicidad":
                    Response.Redirect("~/ExploradorPublicidad.aspx");
                    break;
                case "Administración Site|Explorador de Comentarios":
                    Response.Redirect("~/ExploradorComentario.aspx");
                    break;
                case "Acerca":
                    Response.Redirect("~/About.aspx");
                    break;
                case "Close session":
                    CondecoRN.Sesion.Cerrar(sesion);
                    Response.Redirect("~/UsuarioLogin.aspx");
                    break;
            }
        }
        public Color GetItemColor(MenuItemTemplateContainer container)
        {
            MenuItem item = (MenuItem)container.DataItem;
            if (item.Selectable || item.ChildItems.Count > 0)
                return Color.White;
            else
                return Color.Red;
        }
        protected void EmpresaImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Empresa.aspx");
        }
        protected void UsuarioImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UsuarioConsulta.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Visible = false;
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
}