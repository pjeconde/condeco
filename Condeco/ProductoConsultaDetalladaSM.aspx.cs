using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace Condeco
{
    public partial class ProductoConsultaDetalladaSM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CondecoEntidades.Sesion sesion;
            if (!IsPostBack)
            {
                sesion = (CondecoEntidades.Sesion)Session["Sesion"];
               
                CondecoEntidades.Producto Producto = (CondecoEntidades.Producto)Session["Producto"];
                //string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
                //switch (a)
                //{
                //    case "Id":
                //        TituloPaginaLabel.Text = "Detalle del Producto (cod." + Producto.Id.ToString() + ")";
                //        break;
                //}

                IdProductoTextBox.Text = Producto.Id.ToString();
                NombreLabel.Text = Producto.Nombre;
                DescripcionLabel.Text = Producto.Descripcion;

                PrecioBaseLabel.Text = Producto.PrecioBase.ToString();
                ComentarioPrecioBaseLabel.Text = Producto.ComentarioPrecioBase;

                List<CondecoEntidades.TipoProducto> tp = sesion.TiposProducto.FindAll(delegate(CondecoEntidades.TipoProducto p)
                {
                    return p.Id == Producto.TipoProducto.Id;
                });
                if (tp.Count != 0)
                {
                    TipoProductoLabel.Text = tp[0].Descr;
                }
                else
                {
                    TipoProductoLabel.Text = "";
                }
                IdProductoTextBox.Enabled = false;

                String path = Server.MapPath("~/ImagenesProducto/");
                string[] archivos = System.IO.Directory.GetFiles(path, Producto.Id.ToString() + "-*.*", System.IO.SearchOption.TopDirectoryOnly);
                CompletarImagenesActuales(archivos);

                path = Server.MapPath("~/ImagenesProducto/Portada/");
                archivos = System.IO.Directory.GetFiles(path, Producto.Id.ToString() + ".*", System.IO.SearchOption.TopDirectoryOnly);
                
                List<CondecoEntidades.Comentario> c = CondecoRN.Comentario.Lista("Producto", Producto.Id.ToString(), "", sesion);
                ViewState["IdProducto"] = Producto.Id;

                SalirButton.Focus();
                DataBind();
            }
            MensajeLabel.Text = "";
            MensajeLabel.Focus();
        }
        private void CompletarImagenesActuales(string[] archivos)
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
                            //carouselInnerHtml.AppendLine("<a class='thumbnail' href='#'>");
                            carouselInnerHtml.AppendLine("<img src='ImagenesProducto/" + fileName + "' alt='Slide #" + (i + 1) + "'>");
                            //carouselInnerHtml.AppendLine("</a>");
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
    }
}