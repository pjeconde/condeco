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
    public partial class ProductoConsultaDetallada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CondecoEntidades.Sesion sesion;
            if (!IsPostBack)
            {
                sesion = (CondecoEntidades.Sesion)Session["Sesion"];
               
                CondecoEntidades.Producto Producto = (CondecoEntidades.Producto)Session["Producto"];
                string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
                switch (a)
                {
                    case "Id":
                        TituloPaginaLabel.Text = "Detalle del Producto (Id." + Producto.Id.ToString() + ")";
                        break;
                }

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
                CompletarImagenPortada(archivos);
                
                List<CondecoEntidades.Comentario> c = CondecoRN.Comentario.Lista("Producto", Producto.Id.ToString(), "", sesion);
                ViewState["IdProducto"] = Producto.Id;
                ViewState["lista"] = c;
                ComentarioListView.DataSource = c;


                //<!-- Indicators -->
                //<ol class="carousel-indicators">
                //    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                //    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                //    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                //    <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                //</ol>

                //<div class="item active">
                //    <a id="linkPortada" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg"
                //        target="_blank">
                //        <asp:Image ID="ImagePortadaAmpliada" runat="server" ImageUrl="~/Imagenes/portfolio/1.jpg" />
                //    </a>
                //    <div class="carousel-caption">
                //        <h3></h3>
                //    </div>
                //</div>
                //<div class="item" hidden="hidden">
                //    <a id="linkImage1" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg"
                //        target="_blank">
                //        <asp:Image ID="Image1Ampliada" runat="server" ImageUrl="~/Imagenes/portfolio/2.jpg" />
                //    </a>
                //    <div class="carousel-caption">
                //        <h3></h3>
                //    </div>
                //</div>
                //<div class="item">
                //    <a id="linkImage2" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg"
                //        target="_blank">
                //        <asp:Image ID="Image2Ampliada" runat="server" ImageUrl="~/Imagenes/portfolio/3.jpg" />
                //    </a>
                //    <div class="carousel-caption">
                //        <h3></h3>
                //    </div>
                //</div>
                //<div class="item">
                //    <a id="linkImage3" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg"
                //        target="_blank">
                //        <asp:Image ID="Image3Ampliada" runat="server" ImageUrl="~/Imagenes/Interrogacion.jpg" />
                //    </a>
                //    <div class="carousel-caption">
                //        <h3></h3>
                //    </div>
                //</div>


                pHeader.Visible = false;
                pBody.Visible = false;
                pComentarioCrear.Visible = false;

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
                            carouselInnerHtml.AppendLine("<a class='thumbnail' href='#'>");
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

            //for (int i = 0; i < archivos.Length; i++)
            //{
            //    if (i == 0)
            //    {
            //        linkImage1.HRef = "~/ImagenesProducto/" + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/"), String.Empty);
            //        Image1Ampliada.ImageUrl = "~/ImagenesProducto/" + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/"), String.Empty);
            //    }
            //    else if (i == 1)
            //    {
            //        linkImage2.HRef = "~/ImagenesProducto/" + archivos[1].Replace(Server.MapPath("~/ImagenesProducto/"), String.Empty);
            //        Image2Ampliada.ImageUrl = "~/ImagenesProducto/" + archivos[1].Replace(Server.MapPath("~/ImagenesProducto/"), String.Empty);
            //    }
            //    else if (i == 2)
            //    {
            //        linkImage3.HRef = "~/ImagenesProducto/" + archivos[2].Replace(Server.MapPath("~/ImagenesProducto/"), String.Empty);
            //        Image3Ampliada.ImageUrl = "~/ImagenesProducto/" + archivos[2].Replace(Server.MapPath("~/ImagenesProducto/"), String.Empty);
            //    }
            //}
        }
        private void CompletarImagenPortada(string[] archivos)
        {
            if (archivos.Length >= 1)
            {
                //linkPortada.HRef = "~/ImagenesProducto/Portada/" + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Portada/"), String.Empty);
                //ImagePortadaAmpliada.ImageUrl = "~/ImagenesProducto/Portada/" + archivos[0].Replace(Server.MapPath("~/ImagenesProducto/Portada/"), String.Empty);
            }
        }

        protected void ComentarioListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //set current page startindex, max rows and rebind to false
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            ComentarioListView.DataSource = (List<CondecoEntidades.Comentario>)ViewState["lista"];
            ComentarioListView.DataBind();
        }

        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                MensajeLabel.Text = "Por favor hacer el login.<br/><br/>";
                UpdatePanel2.Update();
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please login.\\n');</script>");
            }
            else
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                CondecoEntidades.Comentario comentario = new CondecoEntidades.Comentario();
                try
                {
                    comentario.IdUsuario = sesion.Usuario.Id;
                    comentario.NombreUsuario = sesion.Usuario.Nombre;
                    comentario.NombreEntidad = "Producto";
                    comentario.IdEntidad = Convert.ToInt32(ViewState["IdProducto"]);
                    comentario.Contenido = txtComentario.Text;
                    comentario.Fecha = DateTime.Now;
                    comentario.Estado = "Vigente";
                    comentario.Url = "";
                    comentario.ManoOk = 0;
                    comentario.ManoNoOk = 0;
                    comentario.AbusoContenido = 0;

                    if (CondecoRN.Comentario.ComprobarComentario(comentario.NombreEntidad, comentario.IdEntidad, comentario.Contenido, sesion))
                    {
                        MensajeLabel.Text = "Hay un comentario similar, cambie el mismo.<br/><br/>";
                        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('There is already a similar comment, change the comment.');</script>");
                    }
                    else
                    {
                        CondecoRN.Comentario.Crear(comentario, sesion);
                        AceptarButton.Enabled = false;

                        Funciones.PersonalizarControlesMaster(Master, true, sesion);
                        MensajeLabel.Text = "El comentario fue ingresado satisfactoriamente.<br/><br/>";
                        //Refrescar yendo a la base de datos.
                        List<CondecoEntidades.Comentario> c = CondecoRN.Comentario.Lista("Producto", comentario.IdEntidad.ToString(), "", sesion);
                        ViewState["lista"] = c;
                        ComentarioListView.DataSource = c;
                        ComentarioListView.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex) + "<br/><br/>";
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problem to register comment.\\n " + CondecoEX.Message + "');</script>");
                }
                finally
                {
                    UpdatePanel2.Update();
                }
            }
        }

        protected void ManoOk_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                MensajeLabel.Text = "Por favor hacer el login.<br/><br/>";
                UpdatePanel2.Update();
            }
            else
            {
                try
                {
                    string[] claves = ((string)((LinkButton)sender).CommandArgument).Split(Convert.ToChar("-"));
                    int idComentario = Convert.ToInt32(claves[0]);
                    int idReplica = Convert.ToInt32(claves[1]);
                    List<CondecoEntidades.Comentario> lista = (List<CondecoEntidades.Comentario>)ViewState["lista"];
                    CondecoEntidades.Comentario comentario = lista.Find(delegate(CondecoEntidades.Comentario m)
                    {
                        return m.Id == idComentario && m.IdReplica == idReplica;
                    });
                    //Grabar ManoOk (una sola vez por usuario, por entidad)
                    CondecoRN.Comentario.GuardarComentarioEstadistica(comentario.NombreEntidad, comentario.IdEntidad, comentario.Id, comentario.IdReplica, "ManoOk", (CondecoEntidades.Sesion)Session["Sesion"]);
                    MensajeLabel.Text = "Voto registrado satisfactoriamente.<br/><br/>";
                    //Refrescar sin ir a base de datos
                    comentario.ManoOk += 1;
                    ComentarioListView.DataSource = lista;
                    ComentarioListView.DataBind();
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                    if (MensajeLabel.Text.IndexOf("PK_ComentarioEstadistica") != -1)
                    {
                        MensajeLabel.Text = "Usted no puede votar dos veces.<br/><br/>";
                    }
                }
                finally
                {
                    UpdatePanel2.Update();
                }
            }
        }

        protected void ManoNoOk_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                MensajeLabel.Text = "Por favor hacer el login.<br/><br/>";
                UpdatePanel2.Update();
            }
            else
            {
                try
                {
                    string[] claves = ((string)((LinkButton)sender).CommandArgument).Split(Convert.ToChar("-"));
                    int idComentario = Convert.ToInt32(claves[0]);
                    int idReplica = Convert.ToInt32(claves[1]);
                    List<CondecoEntidades.Comentario> lista = (List<CondecoEntidades.Comentario>)ViewState["lista"];
                    CondecoEntidades.Comentario comentario = lista.Find(delegate(CondecoEntidades.Comentario m)
                    {
                        return m.Id == idComentario && m.IdReplica == idReplica;
                    });
                    //Grabar ManoNoOk (una sola vez por usuario, por entidad)
                    CondecoRN.Comentario.GuardarComentarioEstadistica(comentario.NombreEntidad, comentario.IdEntidad, comentario.Id, comentario.IdReplica, "ManoNoOk", (CondecoEntidades.Sesion)Session["Sesion"]);
                    MensajeLabel.Text = "Voto registrado satisfactoriamente.<br/><br/>";
                    //Refrescar sin ir a base de datos
                    comentario.ManoNoOk += 1;
                    ComentarioListView.DataSource = lista;
                    ComentarioListView.DataBind();
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                    if (MensajeLabel.Text.IndexOf("PK_ComentarioEstadistica") != -1)
                    {
                        MensajeLabel.Text = "Usted no puede votar dos veces.<br/><br/>";
                    }
                }
                finally
                {
                    UpdatePanel2.Update();
                }
            }
        }

        protected void AbusoContenido_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                MensajeLabel.Text = "Por favor hacer el login.<br/><br/>";
                UpdatePanel2.Update();
            }
            else
            {
                try
                {
                    string[] claves = ((string)((LinkButton)sender).CommandArgument).Split(Convert.ToChar("-"));
                    int idComentario = Convert.ToInt32(claves[0]);
                    int idReplica = Convert.ToInt32(claves[1]);
                    List<CondecoEntidades.Comentario> lista = (List<CondecoEntidades.Comentario>)ViewState["lista"];
                    CondecoEntidades.Comentario comentario = lista.Find(delegate(CondecoEntidades.Comentario m)
                    {
                        return m.Id == idComentario && m.IdReplica == idReplica;
                    });
                    //Grabar AbusoContenido (una sola vez por usuario, por entidad.)
                    CondecoRN.Comentario.GuardarComentarioEstadistica(comentario.NombreEntidad, comentario.IdEntidad, comentario.Id, comentario.IdReplica, "AbusoContenido", (CondecoEntidades.Sesion)Session["Sesion"]);
                    MensajeLabel.Text = "Voto registrado satisfactoriamente.<br/><br/>";
                    //Refrescar sin ir a base de datos
                    comentario.AbusoContenido += 1;
                    ComentarioListView.DataSource = lista;
                    ComentarioListView.DataBind();
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                    if (MensajeLabel.Text.IndexOf("PK_ComentarioEstadistica") != -1)
                    {
                        MensajeLabel.Text = "Usted no puede votar dos veces.<br/><br/>";
                    }
                }
                finally
                {
                    UpdatePanel2.Update();
                }
            }
        }
        
        protected void ReplicarComentario_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                MensajeLabel.Text = "Por favor hacer el login.<br/><br/>";
                UpdatePanel2.Update();
            }
            else
            {
                try
                {
                    string[] claves = ((string)((LinkButton)sender).CommandArgument).Split(Convert.ToChar("-"));
                    int idComentario = Convert.ToInt32(claves[0]);
                    int idReplica = Convert.ToInt32(claves[1]);
                    List<CondecoEntidades.Comentario> lista = (List<CondecoEntidades.Comentario>)ViewState["lista"];
                    CondecoEntidades.Comentario comentario = lista.Find(delegate(CondecoEntidades.Comentario m)
                    {
                        return m.Id == idComentario && m.IdReplica == idReplica;
                    });
                    ViewState["Comentario"] = comentario;
                    //Completar formulario de replica de comentario.
                    IdComentarioReplicaLabel.Text = comentario.Id.ToString();
                    ModalPopupExtender1.Show();
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex);
                    if (MensajeLabel.Text.IndexOf("PK_ComentarioEstadistica") != -1)
                    {
                        MensajeLabel.Text = "Usted no puede votar dos veces.<br/><br/>";
                    }
                }
                finally
                {
                    UpdatePanel2.Update();
                }
            }
        }

        protected void AceptarReplicaComentario_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                MensajeLabel.Text = "Por favor hacer el login.<br/><br/>";
                UpdatePanel2.Update();
            }
            else
            {
                try
                {
                    CondecoEntidades.Comentario comentario = new CondecoEntidades.Comentario();
                    CondecoEntidades.Comentario comentarioOrig = (CondecoEntidades.Comentario)ViewState["Comentario"];
                    CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];

                    comentario.Id = comentarioOrig.Id;
                    comentario.IdUsuario = sesion.Usuario.Id;
                    comentario.NombreUsuario = sesion.Usuario.Nombre;
                    comentario.NombreEntidad = "Producto";
                    comentario.IdEntidad = Convert.ToInt32(ViewState["IdProducto"]);
                    comentario.Contenido = ComentarioReplicaTextBox.Text;
                    comentario.Fecha = DateTime.Now;
                    comentario.Estado = "Vigente";
                    comentario.Url = "";
                    comentario.ManoOk = 0;
                    comentario.ManoNoOk = 0;
                    comentario.AbusoContenido = 0;

                    if (CondecoRN.Comentario.ComprobarComentario(comentario.NombreEntidad, comentario.IdEntidad, comentario.Contenido, sesion))
                    {
                        MensajeLabel.Text = "Hay un comentario similar, cambie el mismo.<br/><br/>";
                    }
                    else
                    {
                        //Grabar replica de comentario (una sola vez por usuario, por entidad.)
                        int NroReplica = CondecoRN.Comentario.Replicar(comentario, sesion);
                        MensajeLabel.Text = "La respuesta al comentario fue ingresado satisfactoriamente.<br/><br/>";
                        //Refrescar yendo a la base de datos.
                        List<CondecoEntidades.Comentario> c = CondecoRN.Comentario.Lista("Producto", comentario.IdEntidad.ToString(), "", sesion);
                        ViewState["lista"] = c;
                        ComentarioListView.DataSource = c;
                        ComentarioListView.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = CondecoEX.Funciones.Detalle(ex) + "<br/><br/>";
                }
                finally
                {
                    UpdatePanel2.Update();
                }
            }
        }


        public string NombreImagen(string value)
        {
            string resp = "~/ImagenesSubidas/SiluetaHombre.jpg";
            if (value != "")
            {
                string path = Server.MapPath("~/ImagenesSubidas/");
                string[] archivos = System.IO.Directory.GetFiles(path, value + ".jpg", System.IO.SearchOption.TopDirectoryOnly);
                if (archivos.Length != 0)
                {
                    resp = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                }
            }
            return resp;
        }

        public bool EsReplica(int value)
        {
            if (value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ComentarioEstado(string comentario, string estado)
        {
            if (estado == "Vigente")
            {
                return comentario;
            }
            else
            {
                return "***** commntario inapropiado *****<br/>eliminado por el administrador";
            }
        }

        public bool EstadoOk(string estado)
        {
            if (estado == "Vigente")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}