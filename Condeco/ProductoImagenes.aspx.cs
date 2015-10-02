using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Collections;

namespace Condeco
{
    public partial class ProductoImagenes : System.Web.UI.Page
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
                    CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    List<CondecoEntidades.Permiso> permisoHabilitado = sesion.Usuario.Permisos.FindAll(delegate(CondecoEntidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "OperProductos" && p.Estado == "Vigente";
                    });
                    if (permisoHabilitado.Count == 0)
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    //Buscar si quedo una imagen (usuario - idProducto ) en el Temp pendiente de agregar.
                    CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
                    string path = Server.MapPath("~/ImagenesProducto/Temp/");
                    string[] archivos = System.IO.Directory.GetFiles(path, producto.Id.ToString() + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    if (archivos.Length != 0)
                    {
                        ImageParaAgregar.ImageUrl = "~/ImagenesProducto/Temp/" + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Temp/"), String.Empty);
                    }
                    //Mostrar imagenes actuales.
                    TituloPaginaLabel.Text = "Imagenes (id." + producto.Id.ToString() + ")";
                    archivos = LeerImagenesActuales();
                    CompletarImagenesActuales(archivos, false);
                    archivos = LeerImagenPortada();
                    CompletarImagenPortada(archivos);
                }
            }
        }
        protected void SubirImagenButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                Boolean fileOK = false;
                String fileExtension = String.Empty;
                String path = Server.MapPath("~/ImagenesProducto/Temp/");
                if (FileUpload1.HasFile)
                {
                    fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    String[] allowedExtensions = { ".jpg", ".png", ".jpeg", ".gif" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                            break;
                        }
                    }
                }
                if (fileOK)
                {
                    try
                    {
                        if (FileUpload1.FileBytes.Length > 2097152)
                        {
                            MensajeLabel.Text = "El archivo seleccionado excede los 2Mb de tamaño.";
                        }
                        else
                        {
                            CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
                            FileUpload1.PostedFile.SaveAs(path + producto.Id.ToString() + fileExtension);
                            string[] archivos = System.IO.Directory.GetFiles(path, producto.Id.ToString() + ".*", System.IO.SearchOption.TopDirectoryOnly);
                            if (archivos.Length != 0)
                            {
                                ImageParaAgregar.ImageUrl = "~/ImagenesProducto/Temp/" + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Temp/"), String.Empty);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeLabel.Text = "Problemas subiendo el archivo.<br />" + CondecoEX.Funciones.Detalle(ex);
                    }
                }
                else
                {
                    MensajeLabel.Text = "Tipo de archivo no permitido.";
                }
            }
        }
        private string[] LeerImagenesActuales()
        {
            CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
            CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
            String path = Server.MapPath("~/ImagenesProducto/");
            string[] archivos = System.IO.Directory.GetFiles(path, producto.Id.ToString() + "-*.*", System.IO.SearchOption.TopDirectoryOnly);
            ArrayList al = new ArrayList();
            al.Add("");
            for (int i = 0; i < archivos.Length; i++)
            {
                al.Add(System.IO.Path.GetFileName(archivos[i]));
            }
            EliminarImagenDropDownList.DataSource = al;
            EliminarImagenDropDownList.DataBind();
            return archivos;
        }
        private void CompletarImagenesActuales(string[] archivos, bool ControlarMaxArch)
        {

            //ObjectCache cache = MemoryCache.Default;
            try
            {
                CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
                if (Session["CarouselInnerHtml"] != null && Session["CarouselIndicatorsHtml"] != null && Session["CarouselIdProducto"] != null && Session["CarouselIdProducto"].ToString() == producto.Id.ToString())
                {
                    //use the cached html
                    ltlCarouselImages.Text = Session["CarouselInnerHtml"].ToString();
                    ltlCarouselIndicators.Text = Session["CarouselIndicatorsHtml"].ToString();
                }
                else
                {
                    TituloImagenes.Text = "No hay imagenes";
                    if (archivos.Length > 0)
                    {
                        TituloImagenes.Text = "Imagenes";
                        var carouselInnerHtml = new StringBuilder();
                        var indicatorsHtml = new StringBuilder(@"<ol class='carousel-indicators'>");
                        //loop through and build up the html for indicators + images
                        for (int i = 0; i < archivos.Length; i++)
                        {
                            var fileName = archivos[i].Replace(Server.MapPath("~/ImagenesProducto/"), String.Empty);
                            carouselInnerHtml.AppendLine(i == 0 ? "<div class='item active'>" : "<div class='item'>");
                            carouselInnerHtml.AppendLine("<a runat='server' id='NombreImagenSelect" + i.ToString() + "' href='#' title='" + fileName + "'>");
                            carouselInnerHtml.AppendLine("<img src='ImagenesProducto/" + fileName + "' alt='Slide #" + (i + 1) + "'>");
                            carouselInnerHtml.AppendLine("</a>");
                            carouselInnerHtml.AppendLine("</div>");
                            indicatorsHtml.AppendLine(i == 0 ? @"<li data-target='#myCarousel' data-slide-to='" + i + "' class='active'></li>" : @"<li data-target='#myCarousel' data-slide-to='" + i + "' class=''></li>");
                        }
                        //close tag
                        indicatorsHtml.AppendLine("</ol>");
                        //stick the html in the literal tags and the cache
                        Session["CarouselInnerHtml"] = ltlCarouselImages.Text = carouselInnerHtml.ToString();
                        Session["CarouselIndicatorsHtml"] = ltlCarouselIndicators.Text = indicatorsHtml.ToString();
                        Session["CarouselIdProducto"] = producto.Id.ToString();
                    }
                }
                ViewState["archivos"] = archivos;
                if (archivos.Length >= 10)
                {
                    if (ControlarMaxArch)
                    {
                        MensajeLabel.Text = "Imposible subir más imagenes al catálogo (máximo permitido 10 imagenes). Deberá eliminar alguna de las imagenes actuales, para poder incorporar otra nueva.";
                    }
                    else
                    {
                        MensajeLabel.Text = "";
                    }
                }
                else
                {
                    MensajeLabel.Text = "";
                }
            }
            catch (Exception)
            {
                //something is dodgy so flush the cache
                if (Session["CarouselInnerHtml"] != null)
                {
                    Session.Remove("CarouselInnerHtml");
                }
                if (Session["CarouselIndicatorsHtml"] != null)
                {
                    Session.Remove("CarouselIndicatorsHtml");
                }
                if (Session["CarouselIdProducto"] != null)
                {
                    Session.Remove("CarouselIdProducto");
                }
            }
        }
        protected void BorrarImagenButton_Click(object sender, EventArgs e)
        {
            //Borra la imagen del temporal.
            MensajeLabel.Text = "";
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                String path = Server.MapPath("~/ImagenesProducto/Temp/");
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
                string[] archivos = System.IO.Directory.GetFiles(path, producto.Id.ToString() + ".*", System.IO.SearchOption.TopDirectoryOnly);
                for (int i = 0; i < archivos.Length; i++)
                {
                    System.IO.File.Delete(archivos[i]);
                    ImageParaAgregar.ImageUrl = "~/Imagenes/Interrogacion.jpg";
                    ImageParaAgregar.DataBind();
                }
            }
        }
        protected void AgregarImagenButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                //Verifico si tiene que borrar alguna imagen antes de subir.
                Boolean CantArchivosOK = true;
                if (ViewState["archivos"] != null)
                {
                    string[] archivos = (string[])ViewState["archivos"];
                    if (archivos.Length >= 10)
                    {
                        MensajeLabel.Text = "Imposible subir más imagenes al catálogo (máximo permitido 10 imagenes). Deberá eliminar alguna de las imagenes actuales, para poder incorporar otra nueva.";
                        CantArchivosOK = false;
                    }
                }
                if (CantArchivosOK)
                {
                    CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    string path = Server.MapPath("~/ImagenesProducto/");
                    string pathTemp = Server.MapPath("~/ImagenesProducto/Temp/");
                    CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
                    string[] archivos = System.IO.Directory.GetFiles(pathTemp, producto.Id.ToString() + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    if (archivos.Length > 0)
                    {
                        string archivoImagen = "";
                        string fechahora = DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("hhmmss");
                        string extension = System.IO.Path.GetExtension(archivos[0]);
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(archivos[0]);
                        archivoImagen = fileName + "-" + fechahora + extension;
                        System.IO.File.Copy(pathTemp + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Temp/"), String.Empty), path + archivoImagen, true);
                        System.IO.File.Delete(archivos[0]);
                        ImageParaAgregar.ImageUrl = "~/Imagenes/Interrogacion.jpg";
                    }
                    Session.Remove("CarouselInnerHtml");
                    Session.Remove("CarouselIndicatorsHtml");
                    archivos = LeerImagenesActuales();
                    CompletarImagenesActuales(archivos, true);
                }
            }
        }
        protected void MostrarImagenAEliminar_Click(object sender, EventArgs e)
        {
            //Control c = (Control)this.FindControl("NombreImgAliminar");
            //NombreImagenAEliminar.Text = ((LinkButton)c).ToolTip;
            //ImagenAEliminar.ImageUrl = "~/Imagenes/" + NombreImagenAEliminar.Text;
        }

        protected void EliminarImagenButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            string[] archivos;
            try
            {
                string imagenAEliminar = EliminarImagenDropDownList.SelectedValue;
                if (imagenAEliminar != "")
                {
                    String path = Server.MapPath("~/ImagenesProducto/");
                    System.IO.File.Delete(path + imagenAEliminar);

                    //Volver a leer las imagenes para ver cuantas quedaron y 
                    //reordenar en el formulario de Imagenes actuales. 
                    CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
                    archivos = System.IO.Directory.GetFiles(path, producto.Id.ToString() + "-*.*", System.IO.SearchOption.TopDirectoryOnly);
                    Session.Remove("CarouselInnerHtml");
                    Session.Remove("CarouselIndicatorsHtml");
                    archivos = LeerImagenesActuales();
                    CompletarImagenesActuales(archivos, true);
                    MensajeLabel.Text = "Imagen eliminada satisfactoriamente del catálogo.";
                }
                else
                {
                    MensajeLabel.Text = "Usted no ha seleccionado ninguna imagen.";
                }
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = "Error al tratar de eliminar la imagen. " + ex.Message;
            }
        }

        #region Portada
        private string[] LeerImagenPortada()
        {
            CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
            CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
            String path = Server.MapPath("~/ImagenesProducto/Portada/");
            string[] archivos = System.IO.Directory.GetFiles(path, producto.Id.ToString() + ".*", System.IO.SearchOption.TopDirectoryOnly);
            return archivos;
        }
        protected void BorrarPortadaButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
            ImagePortada.ImageUrl = "~/Imagenes/Interrogacion.jpg";
            string[] archivos = (string[])ViewState["archivosPortada"];
            if (archivos.Length >= 1)
            {
                System.IO.File.Delete(archivos[0]);
            }
            archivos = LeerImagenPortada();
            CompletarImagenPortada(archivos);
        }
        protected void AgregarPortadaImagenButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                //Verifico si tiene que borrar la imagen antes de subir.
                Boolean CantArchivosOK = true;
                if (ViewState["archivosPortada"] != null)
                {
                    string[] archivosPortada = (string[])ViewState["archivosPortada"];
                    if (archivosPortada.Length >= 1)
                    {
                        MensajeLabel.Text = "Imposible subir la foto principal (máximo permitido 1 imagen). Deberá eliminar la foto principal actual, para poder incorporar otra nueva.";
                        CantArchivosOK = false;
                    }
                }
                if (CantArchivosOK)
                {
                    CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                    string path = Server.MapPath("~/ImagenesProducto/Portada/");
                    string pathTemp = Server.MapPath("~/ImagenesProducto/Temp/");
                    CondecoEntidades.Producto producto = (CondecoEntidades.Producto)Session["Producto"];
                    string[] archivos = System.IO.Directory.GetFiles(pathTemp, producto.Id.ToString() + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    if (archivos.Length > 0)
                    {
                        System.IO.File.Copy(pathTemp + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Temp/"), String.Empty), path + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Temp/"), String.Empty), true);
                        System.IO.File.Delete(archivos[0]);
                        ImageParaAgregar.ImageUrl = "~/Imagenes/Interrogacion.jpg";
                    }
                    archivos = LeerImagenPortada();
                    CompletarImagenPortada(archivos);
                }
            }
        }
        private void CompletarImagenPortada(string[] archivos)
        {
            ImagePortada.ImageUrl = "~/Imagenes/Interrogacion.jpg";
            if (archivos.Length >= 1)
            {
                ImagePortada.ImageUrl = "~/ImagenesProducto/Portada/" + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Portada/"), String.Empty);
            }
            ViewState["archivosPortada"] = archivos;
        }
        #endregion
    }
}